using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorDemo.Models;
using ErrorDemo.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ErrorDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<CourseDto> Get()
        {
            var random = new Random();
            //Simulo il fatto che alcune volte si possono generare delle eccezioni non gestite
            switch(random.Next(3))
            {
                case 0:
                    throw new CourseListFetchException();
                case 1:
                    throw new CoursePagingException();
            }

            return new CourseDto[] {
                 new CourseDto { Id = 1, Title = "Corso 1" },
                 new CourseDto { Id = 2, Title = "Corso 2" }
            };
        }  

        [HttpGet("{id}")]
        public CourseDto Get(int id)
        {
            var random = new Random();
            //Simulo il fatto che alcune volte si possono generare delle eccezioni non gestite
            switch(random.Next(3))
            {
                case 0:
                    throw new CourseDetailFetchException(id);
                case 1:
                    throw new CourseNotFoundException(id);
            }

            return new CourseDto { Id = id, Title = $"Corso {id}" };
        }        
    }
}
