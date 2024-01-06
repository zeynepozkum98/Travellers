using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Entities.Concrete;

namespace Travellers.Business.ValidationRules.FluentValidation
{
    public class FlightToTicketValidator:AbstractValidator<FlightToTicket>
    {
        public FlightToTicketValidator()
        {
            RuleFor(x => x.FlightCompany).NotNull();
            RuleFor(x => x.FlightCompany).MaximumLength(500);
            RuleFor(x=>x.DepartureTime).NotNull();
            RuleFor(x=>x.FlightTime).NotNull();
            RuleFor(x => x.FlightTime).MaximumLength(100);
            RuleFor(x=>x.TransferStatus).NotNull();
            RuleFor(x=>x.TransferStatus).MaximumLength(100);
            RuleFor(x=>x.LuggageStatus).NotNull();
            RuleFor(x => x.LuggageStatus).MaximumLength(100);
            RuleFor(x=>x.Price).NotNull();
           
        }
    }
}
