using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Entities.Concrete;

namespace Travellers.Business.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).MaximumLength(500);
            RuleFor(x=>x.Email).NotNull();
            RuleFor(x=>x.Message).NotNull();
            RuleFor(x => x.Message).MaximumLength(1000);
        }
    }
}
