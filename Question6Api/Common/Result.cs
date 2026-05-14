using TechnicalTest.Question6.Models;

namespace TechnicalTest.Question6.Common;

public class Result<T>
{
    public bool IsSuccess { get; }
    public string Message { get; }
    public T? Data { get; }

    private Result(bool isSuccess, string message, T? data)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public static Result<T> Success(T data, string message = "")
        => new(true, message, data);

    public static Result<T> Failure(string message)
        => new(false, message, default);

    internal Result<OrcamentoItem> Success(Orcamento orcamentoItem)
    {
        throw new NotImplementedException();
    }
}