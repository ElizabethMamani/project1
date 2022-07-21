
namespace Models.Exceptions
{
    public class ValidationException:Exception
    {
        private string message;
        private int errorCode;
        public int ErrorCode
        {
            get { return errorCode; }
            private protected set { errorCode = value; }
        }
        public string ErrorMessage
        {
            get { return message; }
            private protected set { message = value; }
        }
    }
}
