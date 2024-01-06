using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Entities.Concrete;

namespace Travellers.Business.ValidationRules.FluentValidation
{
    public class ShipValidator:AbstractValidator<Ship>
    {
        public ShipValidator()
        {
            RuleFor(x => x.ShipCompany).NotNull();
            RuleFor(x => x.ShipCompany).MaximumLength(500);
            RuleFor(x => x.ShipName).NotNull();
            RuleFor(x => x.ShipName).MaximumLength(500);
            RuleFor(x=>x.Region).NotNull();
            RuleFor(x=>x.Region).MaximumLength(500);
            RuleFor(x => x.TourDuration).NotNull();
            RuleFor(x=>x.TourDuration).MaximumLength(500);
            RuleFor(x=>x.Period).NotNull();
            RuleFor(x=>x.Price).NotNull();
            RuleFor(x=>x.Image).NotNull();

        }
    }
}
