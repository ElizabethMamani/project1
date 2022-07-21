
namespace Models.Exceptions
{
    public class NotFoundException:ApiException
    {
        public NotFoundException(int id)
        {
            this.ErrorCode = 404;
            this.ErrorMessage = $"Subject with this id: {id} not exist.";
        }
    }
}
