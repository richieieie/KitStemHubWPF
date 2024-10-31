using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;

namespace KitStemHub.Services.IServices
{
    public interface IKitService
    {
        IEnumerable<KitResponseDTO> Get(int page, int pageSize, string kitName, int categoryId);
        bool Create(KitCreateDTO kitCreateDTO);
    }
}
