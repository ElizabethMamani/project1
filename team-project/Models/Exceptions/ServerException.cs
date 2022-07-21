

namespace Models.Exceptions
{
    public class ServerException : ApiException
    {
        public ServerException()
        {
            this.ErrorCode = 500;
            this.ErrorMessage = "Error de 500";
        }
    }
}
