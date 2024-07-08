using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tellkoStories.API.Data;
using tellkoStories.API.Models.Domain;
using tellkoStories.API.Models.DTO;

namespace tellkoStories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var category = new Category()
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

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
