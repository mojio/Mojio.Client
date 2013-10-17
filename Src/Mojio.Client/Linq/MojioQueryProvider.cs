using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;
using RestSharp;
using System.Reflection;
using System.Threading.Tasks;

namespace Mojio.Client.Linq
{
	public class MojioQueryProvider : IQueryProvider  
	{
        String _action;
        MojioClient _client;

        IDictionary<string, string> _criteria;
        int _offset = 0;
        int _limit = 20;
        string _order = null;
        bool _desc = true;

        public MojioQueryProvider(MojioClient client, string action)
        {
            _action = action;
            _client = client;
        }

        IQueryable<S> IQueryProvider.CreateQuery<S>(Expression expression)
        {
            Type elementType = TypeHelper.GetElementType(typeof(S));

            if (typeof(S).IsSubclassOf(typeof(BaseEntity)))
                return (IQueryable<S>)Activator.CreateInstance(typeof(MojioQueryable<>).MakeGenericType(elementType), new object[] { this, expression });
            else
                return (IQueryable<S>)Activator.CreateInstance(typeof(IQueryable<>).MakeGenericType(elementType), new object[] { this, expression });
        }

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            Type elementType = TypeHelper.GetElementType(expression.Type);
            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(MojioQueryable<>).MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        S IQueryProvider.Execute<S>(Expression expression)
        {
            _criteria = null;

            return (S)this.Execute(expression);
        }

        public object Execute(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var callExpression = expression as MethodCallExpression;
            if (callExpression != null)
            {
                if( callExpression.Method.Name != "Where")
                    Execute(callExpression.Arguments[0]);

                switch (callExpression.Method.Name)
                {
                    case "Skip":
                        _offset = (int) ((ConstantExpression) callExpression.Arguments[1]).Value;
                        break;
                    case "Take":
                        _limit = (int) ((ConstantExpression) callExpression.Arguments[1]).Value;
                        break;
                    case "Where":
                        if (_criteria == null)
                            _criteria = new Dictionary<string, string>();

                        var criteria = new MojioCriteriaTranslator().Translate(callExpression);

                        foreach (var pair in criteria)
                            _criteria.Add(pair);
                        break;
                    case "Any":
                        return Count() > 0;
                    case "Count":
                        return Count();
                    case "OrderByDescending":
                        _order = MojioTranslate.GetMemberName(callExpression.Arguments[1]);
                        _desc = true;
                        break;
                    case "OrderByAscending":
                    case "OrderBy":
                        _order = MojioTranslate.GetMemberName(callExpression.Arguments[1]);
                        _desc = false;
                        break;
                }
            }

            return this;
        }

        private int Count()
        {
            var request = _client.GetRequest(_action, Method.GET);

            request.AddParameter("offset", 0);
            request.AddParameter("limit", 0);
            request.AddParameter("criteria", BuildCriteriaString());

			var task = _client.RequestAsync<Results> (request);
			task.Wait ();
			var response = task.Result;

			if (response.Data == null)
				throw new Exception ("Error loading count.");

			return response.Data.TotalRows;
        }

		public IEnumerable<T> Fetch<T>(Expression expression = null)
			where T : BaseEntity, new()
		{
			return FetchAsync<T> (expression).Result;
		}

        public async Task<IEnumerable<T>> FetchAsync<T>(Expression expression = null)
            where T : BaseEntity, new()
        {
            _limit = 20;
            _offset = 0;
            _criteria = null;

            Execute(expression);

            var request = _client.GetRequest(_action, Method.GET);

            request.AddParameter("offset", _offset);
            request.AddParameter("limit", _limit);
            request.AddParameter("criteria", BuildCriteriaString());

            if( _order != null )
                request.AddParameter("sortBy", _order);

            request.AddParameter("desc", _desc);

            var response = await _client.RequestAsync<Results<T>>(request);

			if (response.Data == null)
				throw new Exception ("Invalid request response [" + response.StatusCode.ToString () + "]");

            return response.Data.Data;
        }

        public string BuildCriteriaString()
        {
            string criteria = "";

            if (_criteria != null)
                foreach (var f in _criteria)
                    criteria += f.Key + "=" + f.Value + ";";

            return criteria;
        }
    }
}