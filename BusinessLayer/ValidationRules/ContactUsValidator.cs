using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public ContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail can not be empty.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject can not be empty.");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Subject should have minimum 5 characters!");
            RuleFor(x => x.Subject).MaximumLength(250).WithMessage("Subject should have maximum 250 characters!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty.");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Body can not be empty.");

        }
    }
}
