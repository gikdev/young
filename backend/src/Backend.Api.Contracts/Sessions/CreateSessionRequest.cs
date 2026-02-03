namespace Backend.Api.Contracts.Sessions;

public record CreateSessionRequest {
    public required string Passcode { get; init; }
}
