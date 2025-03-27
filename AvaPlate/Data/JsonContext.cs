using System.Text.Json.Serialization;
using AvaPlate.Models;

namespace AvaPlate.Data;

[JsonSerializable(typeof(User))]
public partial class JsonContext : JsonSerializerContext
{
}