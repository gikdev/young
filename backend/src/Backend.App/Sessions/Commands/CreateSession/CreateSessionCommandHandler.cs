using Backend.App.Common.Interfaces;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.App.Sessions.Commands.CreateSession;

public class CreateSessionCommandHandler(
    ILogger<CreateSessionCommandHandler> logger,
    ISessionRepo                         sessionRepo
) : IRequestHandler<CreateSessionCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>> Handle(
        CreateSessionCommand request,
        CancellationToken    cancellationToken
    ) {
        var passcode = await sessionRepo.GetPasscodeAsync();

        if (request.Passcode != passcode) return Error.Unauthorized("رمز اشتباه هست.");

        logger.LogInformation("Request got successfully executed.");

        return Result.Success;
    }
}
