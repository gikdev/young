using Backend.Api.Contracts.YsqForms;
using FluentValidation;

namespace Backend.Api.YsqForms.Validators;

public class CreateYsqFormRequestValidator : AbstractValidator<CreateYsqFormRequest> {
    public CreateYsqFormRequestValidator() {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required.")
            .MaximumLength(100).WithMessage("FullName must be at most 100 characters.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone is required.");

        RuleFor(x => x.Age)
            .InclusiveBetween(1, 120).WithMessage("Age must be between 1 and 120.");

        RuleFor(x => x.Degree)
            .NotEmpty().WithMessage("Degree is required.");

        RuleFor(x => x.EducationMajor)
            .NotEmpty().WithMessage("EducationMajor is required.");

        RuleFor(x => x.JobTitle)
            .NotEmpty().WithMessage("JobTitle is required.");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required.");

        RuleFor(x => x.Answers)
            .NotEmpty().WithMessage("Answers must have at least one item.")
            .ForEach(answer => answer.SetValidator(new YsqFormAnswerRequestValidator()));
    }
}

public class YsqFormAnswerRequestValidator : AbstractValidator<YsqFormAnswerRequest> {
    public YsqFormAnswerRequestValidator() {
        RuleFor(x => x.QuestionIndex)
            .GreaterThanOrEqualTo(1)
            .WithMessage("QuestionIndex must NOT be NEGATIVE or ZERO.");

        RuleFor(x => x.YsqResponse)
            .IsInEnum()
            .WithMessage("YsqResponse must be a valid value.");
    }
}
