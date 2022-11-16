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
                .NotNull().WithMessage("please fill in your first name.")
                .MinimumLength(3).WithMessage("First name is too short, minimum is 3 characters.")
                .MaximumLength(15).WithMessage("First name is too long, maximum is 15 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Please, fill in your last name.")
                .NotNull().WithMessage("Please, fill in your last name.")
                .MinimumLength(3).WithMessage("Last name is too short, minimum is 3 characters.")
                .MaximumLength(50).WithMessage("Last name is too long, maximum is 50 characters."); 

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("Please, fill in your Cpf.")
                .NotNull().WithMessage("Please, fill in your Cpf.")
                .Length(11).WithMessage("Cpf is wrong, check!");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Please, fill in your birth date.")
                .NotNull().WithMessage("Please, fill in your birth date.")
                .Must(BeAValidDate).WithMessage("Birth date invalid.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please, fill in your e-mail")
                .NotNull().WithMessage("Please, fill in your e-mail")
                .EmailAddress().WithMessage("E-mail is wrong, pleases check!");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Please, fill in your Phone number")
                .NotNull().WithMessage("Please, fill in your Phone number")
                .Length(11).WithMessage("Phone number is wrong, check!");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default);
        }
    }
}
