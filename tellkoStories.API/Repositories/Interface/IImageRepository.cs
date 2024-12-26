using tellkoStories.API.Models.Domain;

namespace tellkoStories.API.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);
    }
}
