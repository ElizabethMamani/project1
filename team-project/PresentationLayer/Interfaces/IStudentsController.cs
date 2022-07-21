namespace PresentationLayer.Interfaces
{
    using Microsoft.AspNetCore.Mvc;

    using Models;

    public interface IStudentsController
    {
        public IActionResult GetAllStudents();

        public IActionResult GetStudent(int studentId);

        public IActionResult CreateStudent([FromBody] Student student);

        public IActionResult CreateRelationWithCourse(int studentId, int courseId);
    }
}
