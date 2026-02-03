namespace Backend.Shared.Api.Endpoints;

public static partial class ApiEndpoints {
    public static class YsqForms {
        private const string YsqFormsBase = $"{ApiBase}/forms/ysq";
        public const  string YsqFormsTag  = ApiTags.YsqForms;

        public static readonly ApiRoute CreateYsqForm = new() {
            Tag     = YsqFormsTag,
            Name    = nameof(CreateYsqForm),
            Method  = ApiHttpMethod.Post,
            Path    = YsqFormsBase,
            Summary = "Create new Young schema questionnaire form"
        };

        public static readonly ApiRoute ListYsqForms = new() {
            Tag     = YsqFormsTag,
            Name    = nameof(ListYsqForms),
            Method  = ApiHttpMethod.Get,
            Path    = YsqFormsBase,
            Summary = "List Young schema questionnaire forms"
        };

        public static readonly ApiRoute GetYsqFormById = new() {
            Tag     = YsqFormsTag,
            Name    = nameof(GetYsqFormById),
            Method  = ApiHttpMethod.Get,
            Path    = $"{YsqFormsBase}/{{ysqFormId:guid}}",
            Summary = "Get a Young schema questionnaire form by ID"
        };
    }
}
