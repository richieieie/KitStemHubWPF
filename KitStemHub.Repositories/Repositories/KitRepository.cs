using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;

namespace KitStemHub.Repositories.Repositories
{
    public class KitRepository : GenericRepository<Kit>, IKitRepository
    {
        public KitRepository(KitStemHubWpfContext context) : base(context)
        {
        }

        public bool DeleteOrRestoreById(int id)
        {
            var kit = GetById(id);
            if (kit != null)
            {
                kit.Status = !kit.Status; 
            }

            return _dbContext.SaveChanges() > 0;
        }
    }
}
