using System;

namespace ErrorDemo.Models.Exceptions
{
    public class ErrorDto
    {
        private ErrorDto()
        {
            
        }

        public string Error { get; private set; } = "Unknown error";
        public string Reason { get; private set; } = "Unknown";
        public string Type { get; private set; }
        public int Code { get; private set; } = int.MinValue;
        public string HelpLink { get; private set; }

        public static ErrorDto FromException(Exception exception)
        {
            var dto = new ErrorDto();

            if (exception == null) {
                return dto;
            }
            dto.Error = exception.Message;
            dto.Code = exception.HResult;
            dto.HelpLink = exception.HelpLink;
            dto.Type = exception.GetType().Name;

            var baseException = exception as BaseException;
            if (baseException != null)
            {
                dto.Reason = baseException.Reason.ToString();
            }

            return dto;
        }
    }
}