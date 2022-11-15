using Domain.Dto;
using FluentValidation;

namespace Simple.Client.MEI.API.FluentValidation
{
    public class ClientInputDtoValidator : AbstractValidator<ClientInputDto>
    {
        public ClientInputDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Please, fill in your first name.")
                .NotNull().WithMessage("please fill in your first name.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Please, fill in your last name.")
                .NotNull().WithMessage("Please, fill in your last name.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("Please, fill in your Cpf.")
                .NotNull().WithMessage("Please, fill in your Cpf.");

            //RuleFor(x => x.BirthDate)
            //    .NotEmpty().WithMessage("Please, fill in your birth date.")
            //    .NotNull().WithMessage("Please, fill in your birth date.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please, fill in your e-mail")
                .NotNull().WithMessage("Please, fill in your e-mail");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Please, fill in your Phone number")
                .NotNull().WithMessage("Please, fill in your Phone number");
        }
    }
}
