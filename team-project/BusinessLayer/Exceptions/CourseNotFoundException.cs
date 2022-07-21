namespace BusinessLayer.Exceptions
{
    public class CourseNotFoundException : CourseException
    {
        public CourseNotFoundException()
        {
            this.ErrorCode = 2;
            this.ErrorMessage = "The course id doesn't exist.";
        }
    }
}
