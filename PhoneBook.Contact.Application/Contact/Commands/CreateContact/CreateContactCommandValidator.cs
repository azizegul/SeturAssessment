using FluentValidation;
using PhoneBook.Contact.Application.Contact.Commands.CreateContact;

namespace PhoneBook.Contact.Application.Contact.Commands;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(v => v.PersonId)
            .NotEmpty();

        RuleFor(v => v.Info)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(v => v.InfoType)
            .NotEmpty();
    }
}