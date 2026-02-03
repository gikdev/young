using Ardalis.SmartEnum;

namespace Backend.Domain.YsqFormAggregate;

public class YsqResponse : SmartEnum<YsqResponse, byte> {
    public static readonly YsqResponse CompletelyFalse =
        new(nameof(CompletelyFalse), "Completely false", "کاملا غلط", 1);

    public static readonly YsqResponse MostlyFalse    = new(nameof(MostlyFalse), "Mostly false", "تقریبا غلط", 2);
    public static readonly YsqResponse SlightlyFalse  = new(nameof(SlightlyFalse), "Slightly false", "اندکی غلط", 3);
    public static readonly YsqResponse SlightlyTrue   = new(nameof(SlightlyTrue), "Slightly true", "اندکی درست", 4);
    public static readonly YsqResponse MostlyTrue     = new(nameof(MostlyTrue), "Mostly true", "تقریبا درست", 5);
    public static readonly YsqResponse CompletelyTrue = new(nameof(CompletelyTrue), "Completely true", "کاملا درست", 6);

    private YsqResponse(
        string name,
        string displayNameEn,
        string displayNameFa,
        byte   value
    ) : base(name, value) {
        DisplayNameEn = displayNameEn;
        DisplayNameFa = displayNameFa;
    }

    public string DisplayNameEn { get; private set; }
    public string DisplayNameFa { get; private set; }
}
