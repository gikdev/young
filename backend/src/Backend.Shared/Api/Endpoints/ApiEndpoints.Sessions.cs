namespace Backend.Shared.Api.Endpoints;

public static partial class ApiEndpoints {
    public static class Sessions {
        private const string SessionsBase = $"{ApiBase}/sessions";
        public const  string SessionsTag  = ApiTags.Sessions;

        public static readonly ApiRoute CreateSession = new() {
            Tag     = SessionsTag,
            Name    = nameof(CreateSession),
            Method  = ApiHttpMethod.Post,
            Path    = SessionsBase,
            Summary = "Create new session (sign-in / login)"
        };
    }
}
