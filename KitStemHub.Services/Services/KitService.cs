using AutoMapper;
using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.DTOs.Requests;
using KitStemHub.Services.DTOs.Responses;
using KitStemHub.Services.IServices;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<KitResponseDTO> Get(int page, int pageSize, string kitName, int categoryId)
        {
            var (kits, _) = _kitRepository.GetFilter(k => k.Name!.Contains(kitName ?? "") && (categoryId == 0 || k.CategoryId == categoryId),
                                                       query => query.OrderBy(k => k.Id),
                                                       page * pageSize,
                                                       pageSize,
                                                       query => query.Include(k => k.Category));
            return _mapper.Map<IEnumerable<KitResponseDTO>>(kits);
        }

        public bool Create(KitCreateDTO kitCreateDTO)
        {
            try
            {
                var kit = _mapper.Map<Kit>(kitCreateDTO);
                var isSuccess = _kitRepository.Create(kit);
                if (isSuccess)
                {
                    var fileExtension = Path.GetExtension(kitCreateDTO.ImageUrl);

                    var assetsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "Kits");   
                    Directory.CreateDirectory(assetsFilePath);
                    var storeFilePath = Path.Combine(assetsFilePath, $"{kit.Id}{fileExtension}");

                    File.Copy(kitCreateDTO.ImageUrl, storeFilePath, true);

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
