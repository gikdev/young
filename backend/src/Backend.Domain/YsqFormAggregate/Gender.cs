using Ardalis.SmartEnum;

namespace Backend.Domain.YsqFormAggregate;

public class Gender : SmartEnum<Gender, byte> {
    public static readonly Gender Male   = new(nameof(Male), 1);
    public static readonly Gender Female = new(nameof(Female), 2);

    private Gender(string name, byte value) : base(name, value) { }
}
