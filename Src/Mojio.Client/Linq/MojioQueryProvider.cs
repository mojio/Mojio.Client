using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;
using RestSharp;
using System.Reflection;

namespace Mojio.Client.Linq
{/*
	public class MojioQueryProvider : IQueryProvider 
	{
        RestRequest _request;
        MojioClient _client;
        public MojioQueryProvider(MojioClient client, RestRequest request)
        {
            _request = request;
            _client = client;
        }

		#region IQueryProvider implementation

		public IQueryable CreateQuery (Expression expression)
		{
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            
            var elementType = TypeHelper.GetElementType(expression.Type);
            try
            {
                var queryableType = typeof(MojioQueryable<>).MakeGenericType(elementType);
                return (IQueryable)Activator.CreateInstance(queryableType, new object[] { this, expression });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            return null;
		}

		public IQueryable<TElement> CreateQuery<TElement> (Expression expression)
		{
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if (!typeof(IQueryable<TElement>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }

            return new MojioQueryable<TElement>(this, expression);
		}

		public object Execute (Expression expression)
		{
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var callExpression = expression as MethodCallExpression;
            if (callExpression != null)
            {
                switch (callExpression.Method.Name)
                {
                    case "Skip":

                        var pageSize = 5;
                        var skip = callExpression.Arguments.First<int>();
                        _request.AddParameter("Page", skip / PageSize);
                }
            }

            var translatedQuery = MongoQueryTranslator.Translate(this, expression);
            return translatedQuery.Execute();
		}

		public TResult Execute<TResult> (Expression expression)
		{
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if (!typeof(TResult).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentException("Argument expression is not valid.");
            }

            var result = Execute(expression);
            if (result == null)
            {
                return default(TResult);
            }
            else
            {
                return (TResult)result;
            }
		}

		#endregion
	}*/
}