using Backend.App.Common.Interfaces;
using Backend.Domain.YsqFormAggregate;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.App.YsqForms.Queries.GetYsqFormById;

public class GetYsqFormByIdQueryHandler(
    ILogger<GetYsqFormByIdQueryHandler> logger,
    IYsqFormRepo                        ysqFormRepo
) : IRequestHandler<GetYsqFormByIdQuery, ErrorOr<YsqForm>> {
    public async Task<ErrorOr<YsqForm>> Handle(
        GetYsqFormByIdQuery request,
        CancellationToken   cancellationToken
    ) {
        var ysqForm = await ysqFormRepo.GetOneByIdAsync(request.Id);
        if (ysqForm is null) return Error.NotFound("YsqForm not found.");

        logger.LogInformation("Request got successfully executed.");

        return ysqForm;
    }
}
