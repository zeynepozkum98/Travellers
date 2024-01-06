using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Entities.Concrete;

namespace Travellers.Business.ValidationRules.FluentValidation
{
	public class WinterHolidayValidator:AbstractValidator<WinterHoliday>
	{
        public WinterHolidayValidator()
        {
            RuleFor(x => x.HotelName).NotNull();
            RuleFor(x => x.HotelName).MaximumLength(1000);
            RuleFor(x => x.Region).NotNull();
            RuleFor(x => x.Region).MaximumLength(1000);
            RuleFor(x=>x.AccommodationType).NotNull();
            RuleFor(x => x.AccommodationType).MaximumLength(1000);
            RuleFor(x => x.FacilityAmenities).NotNull();
            RuleFor(x => x.FacilityAmenities).MaximumLength(2000);
            RuleFor(x=>x.Price).NotNull();
            RuleFor(x=>x.Image).NotNull();
        }
    }
}
