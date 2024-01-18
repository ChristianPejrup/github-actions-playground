namespace Api.Core
{
    public class CustomArgumentException : BaseException
    {
        public CustomArgumentException(string message)
            : base(message) { }

        public CustomArgumentException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
