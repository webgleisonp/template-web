using System.Text.Json;

namespace Template.Web.API.Domain.Shared;

public class Result
{
    private readonly bool _isSuccess;
    private readonly Error? _error;

    protected internal Result(bool isSuccess, Error? error = null)
    {
        _isSuccess = isSuccess;
        _error = error;
    }

    public bool IsSuccess => _isSuccess;
    public Error? Error => _error;

    public static Result Success() => new(true);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default!, false, error);
}

public partial class Result<TValue> : Result
{
    private readonly TValue _value;

    protected internal Result(TValue value, bool isSuccess, Error? error = null) : base(isSuccess, error) => _value = value;

    public TValue Value => _value;

    public override string ToString()
    {
        return JsonSerializer.Serialize(_value);
    }
}

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
}