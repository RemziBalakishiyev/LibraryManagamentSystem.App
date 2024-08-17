using Lms.Entity.Books;

namespace Lms.DataAccessLayer.Abstract;

public interface ICategoryRepository : IGenericRepository<Category>
{
    public Task<IDictionary<int, string>> GetCategoryDictionaryAsync();
}
