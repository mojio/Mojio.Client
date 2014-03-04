using System;
using System.Net;

namespace Mojio.Client
{
	public class MojioResponse
	{
		public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

		public string Content { get; set; }
	}

	public class MojioResponse<T> : MojioResponse
	{
		public T Data { get; set; }
	}
}

