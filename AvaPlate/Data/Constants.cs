using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SkiaSharp;
using static System.IO.Path;

namespace AvaPlate.Data;

public static class Constants
{
    public const string DatabaseFilename = "AppSQLite.db3";

    public static readonly string AppDirectory =
        Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Plate",
            "com.plate.ava","Data");

    public static string DatabasePath =>
        $"Data Source={Combine(AppDirectory,DatabaseFilename)}";

    public static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true,
        NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
    };
}