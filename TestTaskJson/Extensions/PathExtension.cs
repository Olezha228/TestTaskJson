﻿namespace TestTaskJson.Extensions;

/// <summary>
/// Класс-расширение для путей в файловой системе
/// </summary>
public static class PathExtension
{
    public static string? GetCurrentProjectDirectory()
    {
        var workingDirectory = Environment.CurrentDirectory;

        // This will get the current PROJECT directory
        return Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;
    }
}
