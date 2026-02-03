namespace Backend.Api.Contracts.YsqForms;

public record YsqFormAnswerRequest {
    public required int         QuestionIndex { get; init; }
    public required YsqResponse YsqResponse   { get; init; }
}
