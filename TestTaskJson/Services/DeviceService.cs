using TestTaskJson.Models;
using TestTaskJson.ResultPattern;

namespace TestTaskJson.Services;

/// <summary>
/// Служба для приборов
/// </summary>
public static class DeviceService
{
    /// <summary>
    /// Гурппирует коды бригады с конфликтующими приборами
    /// </summary>
    /// <param name="devicesInfo">Информация о приборе</param>
    /// <returns></returns>
    public static IEnumerable<Conflict> GroupBrigadeCodeWithConflictDevices(IEnumerable<DeviceInfo> devicesInfo)
    {
        ArgumentNullException.ThrowIfNull(devicesInfo);

        var conflictGroups = devicesInfo
            .GroupBy(device => device.Brigade.Code)
            .Where(group => group.Count() > 1 && group.Any(deviceInfo => deviceInfo.Device.IsOnline))
            .Select(group => new Conflict
            {
                BrigadeCode = group.Key,
                DevicesSerials = group.Select(deviceInfo => deviceInfo.Device.SerialNumber).ToArray()
            })
            .ToList();

        return conflictGroups;
    }

    /// <summary>
    /// Записывает в хранилище сгруппированные коды бригады с конфликтующими приборами
    /// </summary>
    /// <param name="repository">Репозиторий для работы с данными</param>
    /// <returns></returns>
    public static async Task<Result> StoreConflictBrigadeDevicesGroups(IRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);

        var devicesInfoFromStorage = await repository.GetDevicesInfo();
        var devicesInfo = devicesInfoFromStorage?.ToList();

        if (devicesInfo is null || !devicesInfo.Any())
        {
            return Result.Failure(DeviceErrors.NoDevicesInfo);
        }

        var conflictingDeviceGroups = GroupBrigadeCodeWithConflictDevices(devicesInfo.ToList());

        await repository.InsertConflicts(conflictingDeviceGroups);

        return Result.Success();
    }
}
