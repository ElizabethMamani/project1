

namespace Models.Exceptions
{
    public class subjectExeption : ValidationException
    {
        public subjectExeption(string message) {
            this.ErrorCode = 11;
            this.ErrorMessage = message;
        }
    }
}
