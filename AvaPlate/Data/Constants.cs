using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.IO.Path;

namespace AvaPlate.Data;

public static class Constants
{
    public const string DatabaseFilename = "AppSQLite.db3";

    public static string DatabasePath =>
        $"Data Source={Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DatabaseFilename)}";
    
    public static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true,
        NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
    };
}