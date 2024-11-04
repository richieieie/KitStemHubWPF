using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;

namespace KitStemHub.Services.IServices
{
    public interface IKitService
    {
        (IEnumerable<KitResponseDTO>, int) Get(int page, int pageSize, string kitName, int categoryId);
        KitResponseDTO GetById(int id);
        bool Create(KitCreateDTO kitCreateDTO);
        bool Update(KitUpdateDTO kitUpdateDTO);
        bool DeleteOrRestoreById(int id);
    }
}
