using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService) => _categoryService = categoryService;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CategoryDto categoryDto = await  _categoryService.GetCategoryAsync(id);
            return categoryDto is not null ? Ok(categoryDto) : BadRequest("Kategori bulunamadı.");
        }


        [HttpGet]

        public async Task<IActionResult> GetList()
        {
            List<CategoryDto> categoryDtos = await _categoryService.GetAllCategoryAsync();
            return Ok(categoryDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            bool response = await _categoryService.AddCategoryAsync(categoryDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            bool response = await _categoryService.UpdateCategoryAsync(categoryDto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(CategoryDto categoryDto)
        {
            bool response = await _categoryService.DeleteCategoryAsync(categoryDto);
            return Ok(response);
        }
    }
}
