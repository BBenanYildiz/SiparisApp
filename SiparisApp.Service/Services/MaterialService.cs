using AutoMapper;
using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Repositories;
using SiparisApp.Core.Services;
using SiparisApp.Core.UnitOfWorks;
using SiparisApp.Service.Services;
using System.Net;
using System.Text;

namespace SiparisApp.Service.Services
{
    public class MaterialService : GenericService<Material>, IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        public MaterialService(IGenericRepository<Material> repository,
            IUnitOfWork unitOfWork, IMaterialRepository materialRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public Task<Material> GetByKodAsync(string mat_kod)
        {
            return _materialRepository.GetByKodAsync(mat_kod);
        }

        public async Task<ApiResponse> InsertMaterial(Material model)
        {
            try
            {
                Material entity = new Material();

                entity.mat_kodu = model.mat_kodu;
                entity.mat_adi = model.mat_adi;
                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;

                var resultInsert = await AddAsync(entity);

                if (resultInsert is null)
                    return ApiResponse.CreateResponse(HttpStatusCode.NoContent, ApiResponse.ErrorMessage);

                return ApiResponse.CreateResponse(HttpStatusCode.OK, ApiResponse.SuccessMessage, resultInsert);

            }
            catch (Exception ex)
            {
                return ApiResponse.CreateResponse(HttpStatusCode.InternalServerError, ApiResponse.ErrorMessage);
            }
        }
    }
}
