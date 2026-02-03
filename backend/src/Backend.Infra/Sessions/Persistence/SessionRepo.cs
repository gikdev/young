using Backend.App.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Backend.Infra.Sessions.Persistence;

public class SessionRepo(
    IConfiguration config
) : ISessionRepo {
    public Task<string> GetPasscodeAsync() {
        var passcode = config.GetValue<string>("PASSCODE") ??
                       throw new InvalidOperationException("PASSCODE not set in environment variables");

        return Task.FromResult(passcode);
    }
}
