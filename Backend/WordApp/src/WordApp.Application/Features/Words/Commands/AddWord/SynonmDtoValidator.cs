using FluentValidation;

namespace WordApp.Application.Features.Words.Commands.AddWord;

public sealed class SynonmDtoValidator : AbstractValidator<SynonmDto>
{
    public SynonmDtoValidator()
    {
        RuleFor(p => p.TranslatedWord).NotEmpty();
        RuleFor(p => p.ForeignWord).NotEmpty();
    }
}
