using TestTaskJson.Models;

namespace TestTaskJson.Services;

public interface IRepository
{
    /// <summary>
    /// Получить информацию о приборах
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<DeviceInfo>?> GetDevicesInfo();

    /// <summary>
    /// Записать в хранилище конфликтующие группы код-приборы
    /// </summary>
    /// <param name="conflicts"></param>
    /// <returns></returns>
    public Task InsertConflicts(IEnumerable<Conflict> conflicts);
}
