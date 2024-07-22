using System.Text.Json.Serialization;

namespace backend.types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CubeType
{
    Card,
    
}