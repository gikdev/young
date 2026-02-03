// ReSharper disable MemberHidesStaticFromOuterClass

namespace Backend.Shared.Api;

public record ApiRoute {
    public required string Tag  { get; init; }
    public required string Name { get; init; }

    public required ApiHttpMethod       Method  { private get; init; }
    public          IEnumerable<string> Methods => [Method.Value];
    public required string              Path    { get; init; }

    public required string Summary { get;         init; }
    public          string Notes   { private get; init; } = "";

    public string Description => $"""
        Notes:
        - {Notes}
        """;
}
