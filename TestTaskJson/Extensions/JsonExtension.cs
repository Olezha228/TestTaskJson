using Newtonsoft.Json;

namespace TestTaskJson.Extensions;

internal static class JsonExtension
{
    /// <summary>
    /// Десериализирует json файл в объект T
    /// </summary>
    /// <typeparam name="T">Тип десериализируемого объекта</typeparam>
    /// <param name="filePath">Путь к json-файлу</param>
    /// <returns></returns>
    public static async Task<T?> DeserializeJsonFromFile<T>(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);

        await using var openStream = File.OpenRead(filePath);

        var jsonValue = await File.ReadAllTextAsync(filePath);

        _ = TryDeserializeObject<T?>(jsonValue, out var objectResult);

        return objectResult;
    }

    /// <summary>
    /// Десериализирует json-строку в объект T
    /// </summary>
    /// <typeparam name="T">Тип десериализируемого объекта</typeparam>
    /// <param name="value">Десериализируемая строка</param>
    /// <param name="result">Результирующий объект</param>
    /// <returns></returns>
    public static bool TryDeserializeObject<T>(string value, out T result)
    {
        ArgumentNullException.ThrowIfNull(value);

        try
        {
            result = JsonConvert.DeserializeObject<T?>(value)!;

            return true;
        }
        catch
        {
            result = default!;

            return false;
        }
    }

    /// <summary>
    /// Сериализирует объект
    /// </summary>
    /// <param name="value">Сериализируемый объект</param>
    /// <returns></returns>
    public static string SerializeObject(object value)
    {
        ArgumentNullException.ThrowIfNull(value);

        return JsonConvert.SerializeObject(value, Formatting.Indented);
    }

    /// <summary>
    /// Сериализирует объект в json файл
    /// </summary>
    /// <param name="value"></param>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static async Task SerializeObjectToFile(object value, string filePath)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(filePath);

        var jsonValue = SerializeObject(value);

        await File.WriteAllTextAsync(filePath, jsonValue);
    }
}
