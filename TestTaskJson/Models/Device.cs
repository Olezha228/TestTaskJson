namespace TestTaskJson.Models;

/// <summary>
/// Прибор
/// </summary>
public class Device
{
    /// <summary>
    /// Серийный номер прибора
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    /// Используется ли прибор в данный момент
    /// </summary>
    public bool IsOnline { get; set; }
}
