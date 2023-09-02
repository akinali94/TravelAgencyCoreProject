using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname can not be empty");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail can not be empty");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username can not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password can not be empty");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Enter at least 5 character");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("It cannot more than 20 characters");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Passwords are not same with each other");
        }
    }
}
