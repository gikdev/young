using Backend.App.YsqForms.Dto;
using ErrorOr;
using MediatR;

namespace Backend.App.YsqForms.Queries.ListYsqForms;

public record ListYsqFormsQuery : IRequest<ErrorOr<List<YsqFormSummaryDto>>>;
