using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.Linq
{
    public interface IMojioQueryable<TData> : IQueryable<TData>, IOrderedQueryable<TData>
    {
        Task<int> CountAsync();

        Task<IEnumerable<TData>> FetchAsync();
    }
}
