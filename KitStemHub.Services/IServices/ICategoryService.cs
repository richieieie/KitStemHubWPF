using KitStemHub.Repositories.Models;

namespace KitStemHub.Services.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
    }
}