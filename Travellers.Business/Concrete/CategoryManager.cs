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
    public class CategoryManager : ICategoryService
    {
        public ICategoryDal _categoryDal { get; set; }
        public IMapper _mapper { get; set; }

        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
    }
}
