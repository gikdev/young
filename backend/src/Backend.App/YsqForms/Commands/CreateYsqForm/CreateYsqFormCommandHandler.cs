using Backend.App.Common.Interfaces;
using Backend.Domain.YsqFormAggregate;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.App.YsqForms.Commands.CreateYsqForm;

public class CreateYsqFormCommandHandler(
    ILogger<CreateYsqFormCommandHandler> logger,
    IYsqFormRepo                         ysqFormRepo
) : IRequestHandler<CreateYsqFormCommand, ErrorOr<YsqForm>> {
    public async Task<ErrorOr<YsqForm>> Handle(
        CreateYsqFormCommand request,
        CancellationToken    cancellationToken
    ) {
        var result = YsqForm.Create(
            answers: request.Answers,
            gender: request.Gender,
            jobTitle: request.JobTitle,
            educationMajor: request.EducationMajor,
            degree: request.Degree,
            age: request.Age,
            phone: request.Phone,
            fullName: request.FullName
        );

        if (result.IsError) return result.Errors;

        var ysqForm = result.Value;

        await ysqFormRepo.AddAsync(ysqForm);
        await ysqFormRepo.SaveChangesAsync();

        logger.LogInformation("Request got successfully executed.");

        return ysqForm;
    }
}
