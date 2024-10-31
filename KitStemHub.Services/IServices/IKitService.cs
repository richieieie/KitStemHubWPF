using KitStemHub.Services.DTOs.Requests;

namespace KitStemHub.Services.IServices
{
    public interface IKitService
    {
        bool Create(KitCreateDTO kitCreateDTO);
    }
}
