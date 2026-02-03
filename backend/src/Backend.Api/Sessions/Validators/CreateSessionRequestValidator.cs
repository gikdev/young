using Backend.Api.Contracts.Sessions;
using FluentValidation;

namespace Backend.Api.Sessions.Validators;

public class CreateSessionRequestValidator : AbstractValidator<CreateSessionRequest>;
