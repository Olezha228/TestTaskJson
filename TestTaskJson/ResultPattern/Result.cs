namespace TestTaskJson.ResultPattern;

/// <summary>
/// Результат
/// </summary>
public class Result
{
    private Result(bool isSuccess, Error error)
    {
        if ((isSuccess && error != Error.None) ||
            (!isSuccess && error == Error.None))
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Успешно
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Неуспешно
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Ошибка
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Создает успешный результат
    /// </summary>
    /// <returns></returns>
    public static Result Success() => new(true, Error.None);

    /// <summary>
    /// Создает ошибочный результат
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static Result Failure(Error error) => new(false, error);

}
