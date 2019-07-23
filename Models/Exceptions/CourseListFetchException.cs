using System;

namespace ErrorDemo.Models.Exceptions
{
    public class CourseListFetchException : BaseException
    {
        public CourseListFetchException(Exception innerException = null) : base(innerException, "Non è stato possibile ottenere l'elenco dei corsi, riprova più tardi")
        {
            HResult = 102; //Un codice identificativo del problema
            HelpLink = "https://example.org/documentation/course-list-fetch-exception"; //Link alla documentazione che spiega a cosa è dovuto il problema e cosa fare quando si verifica
            Reason = ExceptionReason.ServerError; //Ragione per cui è stata sollevata l'eccezione
        }
    }
}