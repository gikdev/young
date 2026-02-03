namespace Backend.App.YsqForms.Dto;

public class YsqFormSummaryDto {
    public required Guid   Id       { get; init; }
    public required string FullName { get; init; }
    public required string Phone    { get; init; }
}
