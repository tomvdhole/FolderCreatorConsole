namespace SharedKernel;

public interface IError { }

public sealed record class Error<T> : IError
    where T : Enum
{
    public Error(T errorType)
        => ErrorType = errorType;

    public T ErrorType { get; }
}













