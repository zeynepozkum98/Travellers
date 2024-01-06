using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => _categoryService=categoryService;

        
      
        public async Task<IActionResult> Get(int id)
        {
            CategoryDto categoryDto= await _categoryService.GetCategoryAsync(id);
            return View(categoryDto);
        }

      
        public async Task<IActionResult> GetList()
        {
            List<CategoryDto> categoryDtos= await _categoryService.GetAllCategoryAsync();
            return View(categoryDtos);
        }

        [HttpGet]

        public async Task<IActionResult> Add() => View();

        [HttpPost]

        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            bool isTrue= await _categoryService.AddCategoryAsync(categoryDto);
            return isTrue ? RedirectToAction("GetList") : View();
        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            CategoryDto categoryDto= await _categoryService.GetCategoryAsync(id);
            return View(categoryDto);
        }

        [HttpPost]

        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            bool isTrue= await _categoryService.UpdateCategoryAsync(categoryDto);
            return isTrue ? RedirectToAction("GetList") : View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool isTrue= await _categoryService.DeleteCategoryAsync((await _categoryService.GetCategoryAsync(id)));
            return isTrue ? RedirectToAction("GetList") : View();
        }


        
       
        
    }
}
