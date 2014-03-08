using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;
using RestSharp;
using System.Threading.Tasks;

namespace Mojio.Client.Linq
{
	public class MojioQueryable<TData> : IMojioQueryable<TData>, IQueryable<TData>, IOrderedQueryable<TData>
        where TData : BaseEntity, new()
    {
        // private fields
        private MojioQueryProvider<TData> _provider;
        private Expression _expression;

		public MojioQueryProvider<TData> Provider {
			get {
				return _provider;
			}
		}

		public Expression Expression {
			get {
				return _expression;
			}
		}

		public MojioQueryable(MojioQueryProvider<TData> provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            _provider = provider;
            _expression = Expression.Constant(this);
        }

		public MojioQueryable(MojioQueryProvider<TData> provider, Expression expression)
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

		public Task<int> CountAsync()
		{
			return this.Provider.CountAsync (_expression);
		}

		public Task<IEnumerable<TData>> FetchAsync()
		{
			return this.Provider.FetchAsync(_expression);
		}

        #region IEnumerable implementation

        public IEnumerator<TData> GetEnumerator()
        {
			return this.Provider.Fetch(_expression).GetEnumerator();
        }
        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Provider.Fetch(_expression).GetEnumerator();
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