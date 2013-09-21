using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;
using RestSharp;

namespace Mojio.Client.Linq
{
    public class MojioQueryable<TData> : IQueryable<TData>, IOrderedQueryable<TData>
        where TData : BaseEntity, new()
    {
        // private fields
        private MojioQueryProvider _provider;
        private Expression _expression;

        public MojioQueryable(MojioQueryProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            _provider = provider;
            _expression = Expression.Constant(this);
        }

        public MojioQueryable(MojioQueryProvider provider, Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            _provider = provider;
            _expression = expression;
        }

        #region IEnumerable implementation

        public IEnumerator<TData> GetEnumerator()
        {
            return _provider.Fetch<TData>(_expression).GetEnumerator();
        }
        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _provider.Fetch<TData>(_expression).GetEnumerator();
        }

        Type IQueryable.ElementType
        {
            get
            {
                return typeof(TData);
            }
        }

        Expression IQueryable.Expression
        {
            get
            {
                return _expression;
            }
        }

        IQueryProvider IQueryable.Provider
        {
            get
            {
                return _provider;
            }
        }
    }
}