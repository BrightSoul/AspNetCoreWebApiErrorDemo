using System;
using System.Net;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging.Internal;

namespace ErrorDemo.Models.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException(string message) : this(null, message)
        {
        }

        public BaseException(Exception innerException, string message) : this(innerException, message, null)
        {
        }

        public BaseException(string messageFormat, params object[] arguments) : this(null, messageFormat, arguments)
        {
        }

        public BaseException(Exception innerException, string messageFormat, params object[] arguments) : base(MergeFormatAndArguments(messageFormat, arguments), innerException)
        {
            MessageFormat = messageFormat;
            MessageArguments = arguments ?? new object[0];
        }

        public ExceptionReason Reason { get; protected set; } = ExceptionReason.ServerError;
        public string MessageFormat { get; }
        public object[] MessageArguments { get; }

        private static string MergeFormatAndArguments(string messageFormat, object[] arguments)
        {
            return new LogValuesFormatter(messageFormat).Format(arguments);
        }
    }

    public enum ExceptionReason
    {
        NotFound,
        BadInput,
        ServerError
    }
}