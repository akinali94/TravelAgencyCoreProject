using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
  
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not be empty");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content can not be empty");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("At least 5 character");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("At least 5 character");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("No more than 50 character");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("No more than 500 character");
        }
    }
}
