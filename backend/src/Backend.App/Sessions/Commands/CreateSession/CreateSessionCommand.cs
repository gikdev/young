using ErrorOr;
using MediatR;

namespace Backend.App.Sessions.Commands.CreateSession;

public record CreateSessionCommand : IRequest<ErrorOr<Success>> {
    public required string Passcode { get; init; }
}
