using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;

namespace KitStemHub.Repositories.Repositories
{
    public class KitRepository : GenericRepository<Kit>, IKitRepository
    {
        public KitRepository(KitStemHubWpfContext context) : base(context)
        {
        }
    }
}
