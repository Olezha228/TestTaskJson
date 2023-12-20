namespace TestTaskJson.ResultPattern;

/// <summary>
/// Документирование ошибок, связанных с приборами
/// </summary>
public static class DeviceErrors
{
    public static readonly Error NoDevicesInfo = new("DeviceInfo.NoDevicesInfo", "No devices info found");
}
