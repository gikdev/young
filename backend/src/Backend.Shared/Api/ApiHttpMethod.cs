using Ardalis.SmartEnum;

namespace Backend.Shared.Api;

public class ApiHttpMethod : SmartEnum<ApiHttpMethod, string> {
    public static readonly ApiHttpMethod Get    = new(nameof(Get), "GET");
    public static readonly ApiHttpMethod Post   = new(nameof(Post), "POST");
    public static readonly ApiHttpMethod Put    = new(nameof(Put), "PUT");
    public static readonly ApiHttpMethod Patch  = new(nameof(Patch), "PATCH");
    public static readonly ApiHttpMethod Delete = new(nameof(Delete), "DELETE");

    private ApiHttpMethod(string name, string? value = null) : base(name, value ?? name) { }
}
