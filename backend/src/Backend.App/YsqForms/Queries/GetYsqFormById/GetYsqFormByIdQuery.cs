using Backend.Domain.YsqFormAggregate;
using ErrorOr;
using MediatR;

namespace Backend.App.YsqForms.Queries.GetYsqFormById;

public record GetYsqFormByIdQuery(
    Guid Id
) : IRequest<ErrorOr<YsqForm>>;
