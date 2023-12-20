using TestTaskJson.Extensions;
using TestTaskJson.Models;

namespace TestTaskJson.Services;

/// <summary>
/// Репозиторий для работы с приборами с хранилищем в файловой системе
/// </summary>
public class FileRepository : IRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<DeviceInfo>?> GetDevicesInfo()
    {
        var filePath = Path.Combine(PathExtension.GetCurrentProjectDirectory()!, "Source", "Devices.json");

        var devicesInfo = await JsonExtension.DeserializeJsonFromFile<IEnumerable<DeviceInfo>>(filePath);

        return devicesInfo;
    }

    /// <inheritdoc />
    public async Task InsertConflicts(IEnumerable<Conflict> conflicts)
    {
        ArgumentNullException.ThrowIfNull(conflicts);

        var filePath = Path.Combine(PathExtension.GetCurrentProjectDirectory()!, "Source", "Conflicts.json");

        await JsonExtension.SerializeObjectToFile(conflicts, filePath);
    }
}
