using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Entities.Concrete;

namespace Travellers.Business.ValidationRules.FluentValidation
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(x => x.HotelName).NotNull();
            RuleFor(x => x.HotelName).MaximumLength(500);
            RuleFor(x => x.Image).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Description).MaximumLength(1000);
            RuleFor(x => x.DateOfEntry).NotNull();
            RuleFor(x => x.ReleaseDate).NotNull();
            RuleFor(x => x.NumberOfRooms).NotNull();
            RuleFor(x => x.NumberOfRooms).MaximumLength(500);
            RuleFor(x => x.Price).NotNull();

        }
    }
}
