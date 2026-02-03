namespace Backend.Api.Contracts.YsqForms;

public record YsqFormSummariesResponse {
    public required List<YsqFormSummaryResponse> Items { get; init; }
}
