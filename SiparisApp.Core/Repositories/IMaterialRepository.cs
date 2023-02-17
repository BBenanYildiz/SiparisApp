using SiparisApp.Core.Model;
using SiparisApp.Core.Repositories;

namespace SiparisApp.Core.Repositories
{
    public interface IMaterialRepository : IGenericRepository<Material>
    {
        Task<Material> GetByKodAsync(string mat_kod);
    }
}
