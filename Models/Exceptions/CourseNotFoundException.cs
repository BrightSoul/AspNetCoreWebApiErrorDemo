using System;

namespace ErrorDemo.Models.Exceptions
{
    public class CourseNotFoundException : BaseException
    {
        public CourseNotFoundException(int courseId) : base("Il corso {id} non è stato trovato", courseId)
        {
            HResult = 103; //Un codice identificativo del problema
            HelpLink = "https://example.org/documentation/course-not-found-exception"; //Link alla documentazione che spiega a cosa è dovuto il problema e cosa fare quando si verifica
            Reason = ExceptionReason.NotFound; //Ragione per cui è stata sollevata l'eccezione
        }
    }
}