using Backend.App.Common.Interfaces;
using Backend.App.YsqForms.Dto;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.App.YsqForms.Queries.ListYsqForms;

public class ListYsqFormsQueryHandler(
    ILogger<ListYsqFormsQueryHandler> logger,
    IYsqFormRepo                      YsqFormRepo
) : IRequestHandler<ListYsqFormsQuery, ErrorOr<List<YsqFormSummaryDto>>> {
    public async Task<ErrorOr<List<YsqFormSummaryDto>>> Handle(
        ListYsqFormsQuery request,
        CancellationToken cancellationToken
    ) {
        var ysqForms = await YsqFormRepo.ListAsync();

        logger.LogInformation("Request got successfully executed.");

        return ysqForms;
    }
}
