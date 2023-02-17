using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Services;

namespace SiparisApp.Core.Services
{ 
    public interface IMaterialService : IGenericService<Material>
    {
        /// <summary>
        /// Sipariş  kayıt aşamasında aynı malzeme kodunun kontrolünü sağlayabilmek için oluşturuldu
        /// </summary>
        /// <param name="mat_kod"></param>
        /// <returns></returns>
        Task<Material> GetByKodAsync(string mat_kod);


        /// <summary>
        /// Sipariş Kayıt aşamasında malzeme kodu yok ise insert işlemi gerçekleştirmek için oluşturuldu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ApiResponse> InsertMaterial(Material model);
    }
}
