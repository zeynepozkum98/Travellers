using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.DataAccess.Abstract;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.Business.Abstract
{
    public interface ICategoryService
    {
        public ICategoryDal _categoryDal { get; set; }
        public IMapper _mapper { get; set; }

        public Category CategoryDtoConvert(CategoryDto categoryDto)
        {
            return _mapper.Map<Category>(categoryDto);
        }

        async Task<CategoryDto> GetCategoryAsync(int id)
        {
            Category category= await _categoryDal.GetAsync(x=>x.Id == id);
            return _mapper.Map<CategoryDto>(category);
        }
        async Task<List<CategoryDto>> GetAllCategoryAsync()
        {
           List<Category> categories= await  _categoryDal.GetAllAsync();
            List<CategoryDto> categoryDtos= new List<CategoryDto>();
            foreach (Category category in categories) 
            {
                CategoryDto categoryDto=_mapper.Map<CategoryDto>(category);
                categoryDtos.Add(categoryDto);
            }

            return categoryDtos;
        }
        async Task<bool> AddCategoryAsync(CategoryDto categoryDto)
        {
            Category category = CategoryDtoConvert(categoryDto);
            int response = await _categoryDal.AddAsync(category);
            return response > 0;
        }

        async Task<bool> UpdateCategoryAsync(CategoryDto categoryDto) 
        {
            Category category=CategoryDtoConvert(categoryDto);
            int response= await _categoryDal.UpdateAsync(category);
            return response > 0;
        }

        async Task<bool> DeleteCategoryAsync(CategoryDto categoryDto)
        {
            Category category = CategoryDtoConvert(categoryDto);
            int response = await _categoryDal.DeleteAsync(category);
            return response > 0;
        }

      
    }
}
