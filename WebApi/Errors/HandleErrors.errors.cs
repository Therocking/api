
namespace WebApi.Errors
{
    public class HandleErrors : Exception
    {
        public readonly string Msg;
        public readonly int StatusCode;
        private HandleErrors(string error, int statusCode): base(error)
        {
            StatusCode = statusCode;
            Msg = error;
        }

        public static HandleErrors BadRequest(string msg)
        {
            return new HandleErrors(msg, 400);
        }        
        
        public static HandleErrors NotFound(string msg)
        {
            return new HandleErrors(msg, 404);
        }        
        
        public static HandleErrors InternalError(string msg)
        {
            return new HandleErrors(msg, 500);
        }
    }
}
