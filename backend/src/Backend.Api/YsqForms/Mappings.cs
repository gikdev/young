using Backend.Api.Contracts.YsqForms;
using Backend.App.YsqForms.Commands.CreateYsqForm;
using Backend.App.YsqForms.Dto;
using Backend.App.YsqForms.Queries.GetYsqFormById;
using Backend.App.YsqForms.Queries.ListYsqForms;
using Backend.Domain.YsqFormAggregate;
using ErrorOr;
using DomainYsqResponse = Backend.Domain.YsqFormAggregate.YsqResponse;
using ContractYsqResponse = Backend.Api.Contracts.YsqForms.YsqResponse;

namespace Backend.Api.YsqForms;

internal static class Mappings {
    internal static ErrorOr<CreateYsqFormCommand> MapToCommand(this CreateYsqFormRequest request) {
        var answersResult = request.Answers.Select(MapToDomain).ToList();

        if (answersResult.Any(x => x.IsError)) return answersResult.First(x => x.IsError).Errors;

        var answers = answersResult.Select(x => x.Value).ToList();

        return new CreateYsqFormCommand {
            Age            = request.Age,
            Answers        = answers,
            Degree         = request.Degree,
            EducationMajor = request.EducationMajor,
            FullName       = request.FullName,
            Gender         = request.Gender,
            JobTitle       = request.JobTitle,
            Phone          = request.Phone
        };
    }

    internal static ErrorOr<YsqFormAnswer> MapToDomain(this YsqFormAnswerRequest request) {
        var domainResponse = DomainYsqResponse.FromValue((byte)request.YsqResponse);

        var result = YsqFormAnswer.Create(
            response: domainResponse,
            questionIndex: request.QuestionIndex
        );

        return result;
    }

    internal static YsqFormSummaryResponse MapToSummaryResponse(this YsqFormSummaryDto ysqFormSummaryDto) {
        return new YsqFormSummaryResponse {
            FullName = ysqFormSummaryDto.FullName,
            Id       = ysqFormSummaryDto.Id,
            Phone    = ysqFormSummaryDto.Phone
        };
    }

    internal static YsqFormFullResponse MapToFullResponse(this YsqForm ysqForm) {
        return new YsqFormFullResponse {
            FullName       = ysqForm.FullName,
            Id             = ysqForm.Id,
            Phone          = ysqForm.Phone,
            Age            = ysqForm.Age,
            Answers        = ysqForm.Answers.Select(MapToResponse).ToList(),
            Degree         = ysqForm.Degree,
            EducationMajor = ysqForm.EducationMajor,
            Gender         = ysqForm.Gender,
            JobTitle       = ysqForm.JobTitle
        };
    }

    internal static YsqFormAnswerResponse MapToResponse(this YsqFormAnswer ysqFormAnswer) {
        if (ysqFormAnswer.Response is null) throw new NullReferenceException("YSQ Form Answer should not be null!");

        var contractResponse = Enum.Parse<ContractYsqResponse>(ysqFormAnswer.Response.Name);

        return new YsqFormAnswerResponse {
            QuestionIndex = ysqFormAnswer.QuestionIndex,
            YsqResponse   = contractResponse
        };
    }

    internal static YsqFormSummariesResponse MapToSummariesResponse(this List<YsqFormSummaryDto> ysqFormSummaryDtos) {
        return new YsqFormSummariesResponse {
            Items = ysqFormSummaryDtos.Select(MapToSummaryResponse).ToList()
        };
    }

    internal static ListYsqFormsQuery CreateListYsqFormsQuery() {
        return new ListYsqFormsQuery();
    }

    internal static GetYsqFormByIdQuery CreateGetYsqFormByIdQuery(Guid ysqFormId) {
        return new GetYsqFormByIdQuery(ysqFormId);
    }
}
