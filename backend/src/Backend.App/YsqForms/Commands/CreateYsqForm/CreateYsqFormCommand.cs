using Backend.Domain.YsqFormAggregate;
using ErrorOr;
using MediatR;

namespace Backend.App.YsqForms.Commands.CreateYsqForm;

public record CreateYsqFormCommand : IRequest<ErrorOr<YsqForm>> {
    public required string              FullName       { get; init; }
    public required string              Phone          { get; init; }
    public required int                 Age            { get; init; }
    public required string              Degree         { get; init; }
    public required string              EducationMajor { get; init; }
    public required string              JobTitle       { get; init; }
    public required string              Gender         { get; init; }
    public required List<YsqFormAnswer> Answers        { get; init; }
}
