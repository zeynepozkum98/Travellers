using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Entities.Concrete;

namespace Travellers.Business.ValidationRules.FluentValidation
{
    public class CityValidator:AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x=>x.CityName).NotNull();
            RuleFor(x => x.CityName).MaximumLength(100);
        }
    }
}
