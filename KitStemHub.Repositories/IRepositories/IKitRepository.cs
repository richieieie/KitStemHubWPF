using KitStemHub.Repositories.Models;

namespace KitStemHub.Repositories.IRepositories
{
    public interface IKitRepository : IGenericRepository<Kit>
    {
        bool DeleteOrRestoreById(int id);
    }
}
