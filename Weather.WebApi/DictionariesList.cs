using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DictionariesList
    {
        [EnumMember(Value = "location-types")]
        LocationTypes,

        [EnumMember(Value = "locations")]
        Locations,

        [EnumMember(Value = "positions")]
        Positions,

        [EnumMember(Value = "permissions")]
        Permissions
    }
}
