using Backend.Api.Contracts.Sessions;
using Backend.App.Sessions.Commands.CreateSession;

namespace Backend.Api.Sessions;

internal static class Mappings {
    internal static CreateSessionCommand MapToCommand(this CreateSessionRequest request) {
        return new CreateSessionCommand {
            Passcode = request.Passcode
        };
    }
}
