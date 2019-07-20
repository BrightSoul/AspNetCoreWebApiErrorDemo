using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ErrorDemo.Models;
using ErrorDemo.Models.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ErrorDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ErrorDto Get()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            LogException(feature.Error);
            Response.StatusCode = (int) GetStatusCodeFromException(feature.Error);
            return ErrorDto.FromException(feature.Error);
        }

        private void LogException(Exception exception)
        {
            var baseException = exception as BaseException;
            string message;
            object[] arguments;

            //Se era una BaseException, sfrutto il logging strutturato
            if (baseException != null) {
                message = baseException.MessageFormat;
                arguments = baseException.MessageArguments;
            } else {
                message = exception.Message;
                arguments = new object[0];
            }

            logger.LogError(exception, message, arguments);
        }

        private HttpStatusCode GetStatusCodeFromException(Exception exception)
        {
            switch ((exception as BaseException)?.Reason)
            {
                case ExceptionReason.BadInput:
                    return HttpStatusCode.BadRequest;
                case ExceptionReason.NotFound:
                    return HttpStatusCode.NotFound;
            }
            return HttpStatusCode.InternalServerError;
        }
    }
}
