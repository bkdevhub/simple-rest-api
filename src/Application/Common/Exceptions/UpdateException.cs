namespace src.Application.Common.Exceptions;

public class UpdateException : Exception
{
    public UpdateException(string message) : base(message) { }
}