using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.Business.ValidationRules.FluentValidation
{
    public class PlaceToVisitValidator:AbstractValidator<PlaceToVisit>
    {
        public PlaceToVisitValidator()
        {
            RuleFor(x => x.PlaceToVisitName).NotNull();
            RuleFor(x => x.PlaceToVisitName).MaximumLength(500);
            RuleFor(x=>x.Price).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Description).MaximumLength(1000);
            RuleFor(x => x.TypeOfTransportation).NotNull();
            RuleFor(x => x.TypeOfTransportation).MaximumLength(500);
            RuleFor(x=>x.TourDuration).NotNull();
            RuleFor(x => x.TourDuration).MaximumLength(500);
            RuleFor(x=>x.StartingPoint).NotNull();
            RuleFor(x=>x.StartingPoint).MaximumLength(500);
            RuleFor(x=>x.Period).NotNull();
            RuleFor(x => x.Period).MaximumLength(500);
            RuleFor(x=>x.Image).NotNull();


        }

        public ValidationResult Validate(PlaceToVisitDto placeToVisitDto)
        {
            throw new NotImplementedException();
        }
    }
}
