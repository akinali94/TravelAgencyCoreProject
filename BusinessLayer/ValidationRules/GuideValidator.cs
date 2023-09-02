using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator :AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter name of Guide");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter the description");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Please write the url of image");
            RuleFor(x => x.Name).MaximumLength(45).WithMessage("Name and surname should be less than 45 character");
            RuleFor(x => x.Name).MinimumLength(8).WithMessage("Name and surname should be less than 8 character");
        }
    }
}
