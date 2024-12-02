using System.Collections.Immutable;

namespace SharedKernel;

public record Result
{
    protected Result(bool isSuccess, IEnumerable<IError> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors.ToImmutableList();
    }

    public bool IsSuccess { get; }
    public ImmutableList<IError> Errors { get; }
    public static Result Succeed()
        => new(true, []);

    public static Result Failed(IList<IError> errors)
        => new(false, errors);
}

public sealed record Result<T> : Result
{
    private readonly T? _value;
    private Result(T? value, bool isSuccess, IEnumerable<IError> errors)
        : base(isSuccess, errors)
        => _value = value;

    public T? Value
    {
        get
        {
            if (IsSuccess)
                return _value;
            else
                throw new InvalidOperationException(nameof(Value));
        }
    }

    public static Result<T> Succeed(T? value)
        => new(value, true, []);

    public static new Result<T> Failed(IList<IError> errors)
        => new(default, false, errors);
}
