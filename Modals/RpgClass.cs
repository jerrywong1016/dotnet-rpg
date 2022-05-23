using System.Text.Json.Serialization;

namespace dotnet_rpg.Modals
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight,
        Mage,
        Cleric
    }
}