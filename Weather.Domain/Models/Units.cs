using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Weather.Domain.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Units
    {
        [EnumMember(Value = "I")]
        Imperial,

        [EnumMember(Value = "M")]
        Metric 
    }
}
