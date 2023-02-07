namespace ProductTracking.Core.Exceptions.AuthExceptions;
internal class InvalidLoginException : Exception
{
    public InvalidLoginException() : base("Invalid Login")
    {
    }
    public InvalidLoginException(Exception ex) : base("Invalid Login", ex)
    {
    }
}
