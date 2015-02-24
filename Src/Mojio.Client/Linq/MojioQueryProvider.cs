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
	public class MojioQueryProvider<TData> : IQueryProvider  
		where TData : BaseEntity,new()
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
			return (IQueryable<S>) new MojioQueryable<TData> (this, expression);
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

			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}

			return (S) Execute (expression);
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
                        _criteria = new MojioCriteriaTranslator().Translate(callExpression, _criteria);
                        break;
                    case "OrderByDescending":
                        _order = MojioTranslate.GetMemberName(callExpression.Arguments[1]);
                        _desc = true;
                        break;
                    case "OrderByAscending":
                    case "OrderBy":
                        _order = MojioTranslate.GetMemberName(callExpression.Arguments[1]);
                        _desc = false;
                        break;

					case "First":
						_offset = 0;
						_limit = 1;
						return Fetch ().First ();
					case "FirstOrDefault":
						_offset = 0;
						_limit = 1;
						return Fetch ().FirstOrDefault ();
					case "Count":
						return Count ();
					case "Any":
						return Count () > 0;
                }
            }

            return this;
        }

        private int Count()
		{
			var request = MojioClient.AvoidAsyncDeadlock(() => CountAsync ());
			request.Wait ();
			return request.Result;
		}

		public Task<int> CountAsync(Expression expression = null)
		{
			if (expression != null) {
				_limit = 20;
				_offset = 0;
				_criteria = null;

				Execute (expression);
			}

            var request = _client.GetRequest(_action, Method.GET);

            request.AddParameter("offset", 0);
            request.AddParameter("limit", 0);
            request.AddParameter("criteria", BuildCriteriaString());

			var task = _client.RequestAsync<Results> (request);

			return task.ContinueWith (r => { 
				var response = r.Result;

				if (response.Data == null)
					throw new Exception ("Error loading count.");

				return response.Data.TotalRows;
			});
        }

		public IEnumerable<TData> Fetch(Expression expression = null)
		{
            return MojioClient.AvoidAsyncDeadlock(() => FetchAsync(expression)).Result;
		}

        public Task<IEnumerable<TData>> FetchAsync(Expression expression = null)
		{
			if (expression != null) {
				_limit = 20;
				_offset = 0;
				_criteria = null;

				Execute (expression);
			}

            var request = _client.GetRequest(_action, Method.GET);

            request.AddParameter("offset", _offset);
            request.AddParameter("limit", _limit);
            request.AddParameter("criteria", BuildCriteriaString());

            if( _order != null )
                request.AddParameter("sortBy", _order);

            request.AddParameter("desc", _desc);

            var task = _client.RequestAsync<Results<TData>>(request);

            return task.ContinueWith<IEnumerable<TData>>(r =>
            {
                var response = r.Result;

                if (response.Data == null)
                    throw new Exception("Invalid request response [" + response.StatusCode.ToString() + "]");

                return response.Data.Data ?? new TData[] {};
            });
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