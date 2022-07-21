using Microsoft.AspNetCore.Mvc;
using Models;

namespace PresentationLayer.Interfaces
{
    public interface ISubjectController
    {
        public IActionResult GetAll();
        public IActionResult Get(int id);

        public IActionResult GetByIdCourse(int id);

        public IActionResult Post([FromBody] Subject value);
    }
}
