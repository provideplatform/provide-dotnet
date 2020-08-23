using System;
using System.Net;

namespace provide.Model.Client.ProvideError
{
    public class ProvideException: Exception
    {
        public ProvideError ProvideError { get; }
        public HttpStatusCode StatusCode { get; }

        public ProvideException(string message)
            : base(message)
        {
        }

        public ProvideException(HttpStatusCode statusCode, ProvideError apiError = null)
            : this(apiError == null ? statusCode.ToString() : apiError.Errors[0].Message)
        {
            StatusCode = statusCode;
            ProvideError = apiError;
        }


        public static ProvideException CreateException(string content, HttpStatusCode statusCode)
        {
            return new ProvideException(statusCode, ProvideError.FormatError(content));
        }
    }
}