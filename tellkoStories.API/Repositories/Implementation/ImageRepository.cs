using Microsoft.EntityFrameworkCore;
using tellkoStories.API.Data;
using tellkoStories.API.Models.Domain;
using tellkoStories.API.Repositories.Interface;

namespace tellkoStories.API.Repositories.Implementation
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext dbContext;
        public ImageRepository(IWebHostEnvironment _webHostEnvironment, IHttpContextAccessor _httpContextAccessor, ApplicationDbContext _dbContext) 
        { 
            this.webHostEnvironment = _webHostEnvironment;
            this.httpContextAccessor = _httpContextAccessor;
            this.dbContext = _dbContext;
        }

        public async Task<IEnumerable<BlogImage>> GetAllImages()
        {
            return await dbContext.BlogImages.ToListAsync();
        }

        public async Task<BlogImage> Upload(IFormFile file, BlogImage blogImage)
        {
            // Uploading Image to API/Images
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{blogImage.FileName}{blogImage.FileExtension}");

            using var stream = new FileStream(localPath, FileMode.Create);

            await file.CopyToAsync(stream);

            // Updating the database
            var httpRequest = httpContextAccessor.HttpContext.Request;

            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{blogImage.FileName}{blogImage.FileExtension}";

            blogImage.Url = urlPath;

            await dbContext.BlogImages.AddAsync(blogImage);
            await dbContext.SaveChangesAsync();

            return blogImage;
        }
    }
}
