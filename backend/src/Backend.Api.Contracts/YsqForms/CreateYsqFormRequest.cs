namespace Backend.Api.Contracts.YsqForms;

public record CreateYsqFormRequest {
    public required string                     FullName       { get; init; }
    public required string                     Phone          { get; init; }
    public required int                        Age            { get; init; }
    public required string                     Degree         { get; init; }
    public required string                     EducationMajor { get; init; }
    public required string                     JobTitle       { get; init; }
    public required string                     Gender         { get; init; }
    public required List<YsqFormAnswerRequest> Answers        { get; init; }
}
