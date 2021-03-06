using System;
using System.Net;

namespace BookmarkManager.Application.Common.Exceptions
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, object message = default)
        {
            Code = code;
            Message = message;
        }

        public HttpStatusCode Code { get; init; }

        public new object Message { get; init; }
    }
}
