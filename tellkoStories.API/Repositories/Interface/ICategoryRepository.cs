using tellkoStories.API.Models.Domain;

namespace tellkoStories.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>>GetAllAsync(string? query = null);
        Task<Category?>GetById(Guid id);
        Task<Category?>UpdateAsync(Category category);
        Task<Category?>DeleteAsync(Guid id);
    }
}
