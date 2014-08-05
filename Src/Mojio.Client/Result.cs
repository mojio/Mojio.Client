using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Client
{
    public class Result
    {
        public const int Success = 0;
        public int Status { get; set; }
        public string Error { get; set; }

        public static implicit operator bool(Result result)
        {
            return result.Status == Success;
        }
    }
    public class Result<T> : Result
    {
        public T Item { get; set; }
    }
}
