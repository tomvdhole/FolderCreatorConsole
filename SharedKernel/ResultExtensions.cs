namespace SharedKernel;

public static class ResultExtensions
{
    public static Result<T> Bind<T>(this Result<T> result, Func<T?, Result<T>> method)
        => result.IsSuccess
            ? method(result.Value)
            : Result<T>.Failed(result.Errors);

    public static Result<U> Map<T, U>(this Result<T> result, Func<T?, Result<U>> method)
        => result.IsSuccess
            ? method(result.Value)
            : Result<U>.Failed(result.Errors);

    public static Result<U> Switch<T, U>(this Result<T> result, Func<Result<T>, Result<U>> methodSucces,
                                                                Func<Result<T>, Result<U>> methodFailure)
        => result.IsSuccess
            ? methodSucces(result)
            : methodFailure(result);
}

