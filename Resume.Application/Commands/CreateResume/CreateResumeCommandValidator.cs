using FluentValidation;

namespace Resume.Application.Commands.CreateResume;

public class CreateResumeCommandValidator : AbstractValidator<CreateResumeCommand>
{
    public CreateResumeCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Summary).NotEmpty().MaximumLength(500);
    }
    
}