using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tellkoStories.API.Data;
using tellkoStories.API.Models.Domain;
using tellkoStories.API.Models.DTO;
using tellkoStories.API.Repositories.Interface;

namespace tellkoStories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var category = new Category()
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await categoryRepository.CreateAsync(category);

            var response = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);

        }
    }
}
