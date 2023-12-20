namespace TestTaskJson.Models;

/// <summary>
/// Информация о использовании прибора
/// </summary>
public class DeviceInfo
{
    /// <summary>
    /// Прибор
    /// </summary>
    public Device Device { get; set; }

    /// <summary>
    /// Бригада
    /// </summary>
    public Brigade Brigade { get; set; }
}