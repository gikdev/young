namespace Backend.Api.Contracts.YsqForms;

public record YsqFormAnswerResponse {
    public required int         QuestionIndex { get; init; }
    public required YsqResponse YsqResponse   { get; init; }
}
