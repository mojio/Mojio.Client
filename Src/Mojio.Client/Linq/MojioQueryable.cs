using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;

namespace Mojio.Client.Linq
{
    /*
    public class MojioQueryable<TData> : IQueryable<TData>
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
            return ((IEnumerable<TData>)_provider.Execute(_expression)).GetEnumerator();
        }
        #endregion

        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_provider.Execute(_expression)).GetEnumerator();
        }
        #endregion

        #region IQueryable implementation
        public Expression Expression
        {
            get
            {
                return _expression;
            }
        }
        public Type ElementType
        {
            get
            {
                return typeof(TData);
            }
        }
        public IQueryProvider Provider
        {
            get
            {
                return _provider;
            }
        }
        #endregion
    }
     */
}