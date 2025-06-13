namespace Shared.Results;

public class Result
{
    public bool IsSuccess { get; }
    public string? Message { get; }

    protected Result(bool isSuccess, string? message = null)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result Success(string? message = null) => new(true, message);
    public static Result Failure(string message) => new(false, message);
}
public class Result<T> : Result
{
    public T? Value { get; }

    private Result(bool isSuccess, T? value, string? message = null)
        : base(isSuccess, message)
    {
        Value = value;
    }

    public static Result<T> Success(T value, string? message = null) => new(true, value, message);
    public static new Result<T> Failure(string message) => new(false, default, message);
}