using KitStemHub.Repositories.Models;

namespace KitStemHub.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}