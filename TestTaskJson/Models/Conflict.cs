// ReSharper disable CommentTypo
namespace TestTaskJson.Models;

/// <summary>
/// Конфликт в использовании приборов
/// </summary>
public class Conflict
{
    /// <summary>
    /// Код бригады
    /// </summary>
    public string BrigadeCode { get; set; }

    /// <summary>
    /// Массив серийных номеров приборов в конфликте
    /// </summary>
    public string[] DevicesSerials { get; set; }
}