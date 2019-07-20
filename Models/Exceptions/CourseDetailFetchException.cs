using System;

namespace ErrorDemo.Models.Exceptions
{
    public class CourseDetailFetchException : BaseException
    {
        public CourseDetailFetchException(int courseId, Exception innerException = null) : base($"Non è stato possibile ottenere il corso {courseId}", innerException)
        {
            HResult = 100; //Un codice identificativo del problema
            HelpLink = "https://example.org/documentation/course-detail-fetch-exception"; //Link alla documentazione che spiega a cosa è dovuto il problema e cosa fare quando si verifica
            Reason = ExceptionReason.ServerError; //Ragione per cui è stata sollevata l'eccezione
        }
    }
}