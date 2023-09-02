using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be empty");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("You should upload an image");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Description consists of at least 50 character!");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Maximum Description length is 1500 character! ");
        }
    }
}
