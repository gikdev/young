namespace Backend.Api.Contracts.YsqForms;

public record YsqFormSummaryResponse {
    public required Guid   Id       { get; init; }
    public required string FullName { get; init; }
    public required string Phone    { get; init; }
}
