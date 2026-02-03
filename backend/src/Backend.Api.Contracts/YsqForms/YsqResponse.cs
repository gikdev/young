using System.Text.Json.Serialization;

namespace Backend.Api.Contracts.YsqForms;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum YsqResponse : byte {
    CompletelyFalse = 1,
    MostlyFalse     = 2,
    SlightlyFalse   = 3,
    SlightlyTrue    = 4,
    MostlyTrue      = 5,
    CompletelyTrue  = 6
}
