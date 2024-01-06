using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Entities.Concrete;

namespace Travellers.Business.ValidationRules.FluentValidation
{
    public class TourValidator:AbstractValidator<Tour>
    {
        public TourValidator()
        {
            RuleFor(x => x.TourName).NotNull();
            RuleFor(x => x.TourName).MaximumLength(500);
            RuleFor(x => x.Image).NotNull();
        }
    }
}
