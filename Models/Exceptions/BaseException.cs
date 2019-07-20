using System;
using System.Net;

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

        public BaseException(Exception innerException, string messageFormat, params object[] arguments) : base(messageFormat, innerException) //TODO: Al costruttore base dovrebbe essere fornita l'unione del formato con i parametri
        {
            MessageFormat = messageFormat;
            MessageArguments = arguments ?? new object[0];
        }

        public ExceptionReason Reason { get; protected set; } = ExceptionReason.ServerError;
        public string MessageFormat { get; }
        public object[] MessageArguments { get; }
    }

    public enum ExceptionReason
    {
        NotFound,
        BadInput,
        ServerError
    }
}