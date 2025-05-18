using FluentValidation;

namespace WordApp.Application.Features.Words.Commands.AddWord;

public sealed class AddWordCommandValidator : AbstractValidator<AddWordCommandRequest>
{
    public AddWordCommandValidator()
    {
        RuleFor(p => p.ForeignWord).NotEmpty();
        RuleFor(p => p.TranslatedWord).NotEmpty();
    }
}
