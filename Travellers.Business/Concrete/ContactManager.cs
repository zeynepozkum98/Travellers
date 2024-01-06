using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Business.Abstract;
using Travellers.DataAccess.Abstract;

namespace Travellers.Business.Concrete
{
    public class ContactManager : IContactService
    {
        public IContactDal _contactDal { get; set; }
        public IMapper _mapper { get; set; }

        public ContactManager(IContactDal contactDal, IMapper mapper)
        {
            _contactDal = contactDal;
            _mapper = mapper;
        }
    }
}
