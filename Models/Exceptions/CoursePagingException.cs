using System;

namespace ErrorDemo.Models.Exceptions
{
    public class CoursePagingException : BaseException
    {
        public CoursePagingException(Exception innerException = null) : base($"Devi fornire un numero di pagina quando recuperi i corsi", innerException)
        {
            HResult = 104; //Un codice identificativo del problema
            HelpLink = "https://example.org/documentation/course-paging-exception"; //Link alla documentazione che spiega a cosa è dovuto il problema e cosa fare quando si verifica
            Reason = ExceptionReason.BadInput; //Ragione per cui è stata sollevata l'eccezione
        }
    }
}