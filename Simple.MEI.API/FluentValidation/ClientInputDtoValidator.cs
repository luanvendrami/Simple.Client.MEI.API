using Domain.Dto;
using FluentValidation;

namespace Simple.Client.MEI.API.FluentValidation
{
    public class ClientInputDtoValidator : AbstractValidator<ClientInputDto>
    {
        public ClientInputDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("\r\nPlease, fill in your first name.")
                .NotNull().WithMessage("\r\nplease fill in your first name.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("\r\nPlease, fill in your last name.")
                .NotNull().WithMessage("\r\nPlease, fill in your last name.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("\r\nPlease, fill in your Cpf.")
                .NotNull().WithMessage("\r\nPlease, fill in your Cpf.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("\r\nPlease, fill in your birth date.")
                .NotNull().WithMessage("\r\nPlease, fill in your birth date.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("\r\nPlease, fill in your e-mail")
                .NotNull().WithMessage("\r\nPlease, fill in your e-mail");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("\r\nPlease, fill in your Phone number")
                .NotNull().WithMessage("\r\nPlease, fill in your Phone number");
        }
    }
}
