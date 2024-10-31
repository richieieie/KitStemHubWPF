using AutoMapper;
using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.IServices;
namespace KitStemHub.Services.Services
{
    public class KitService : IKitService
    {
        private readonly IKitRepository _kitRepository;
        private readonly IMapper _mapper;
        public KitService(IKitRepository kitRepository, IMapper mapper)
        {
            _kitRepository = kitRepository;
            _mapper = mapper;
        }
        public bool Create(KitCreateDTO kitCreateDTO)
        {
            try
            {
                var kit = _mapper.Map<Kit>(kitCreateDTO);
                var isSuccess = _kitRepository.Create(kit);
                if (isSuccess)
                {
                    var imageFilePath = Path.GetFileName(kitCreateDTO.ImageUrl);
                    var storeFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Kits", $"{kit.Id}{Path.GetExtension(imageFilePath)}");

                    // Ensure the directory exists
                    if (!Directory.Exists(storeFilePath))
                    {
                        Directory.CreateDirectory(storeFilePath);
                    }

                    using var sourceStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
                    using var destinationStream = new FileStream(Path.Combine(storeFilePath, imageFilePath), FileMode.Create, FileAccess.Write);
                    sourceStream.CopyTo(destinationStream);

                    kit.ImageUrl = storeFilePath;
                    _kitRepository.Update(kit);
                }

                return isSuccess;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
