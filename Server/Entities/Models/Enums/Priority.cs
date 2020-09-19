using System.Text.Json.Serialization;

namespace Entities.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Priority
    {
        Low,
        Intermediate,
        High
    }
}