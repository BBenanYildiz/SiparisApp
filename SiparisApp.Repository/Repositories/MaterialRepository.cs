using Microsoft.EntityFrameworkCore;
using SiparisApp.Core.Model;
using SiparisApp.Core.Repositories;

namespace SiparisApp.Repository.Repositories
{
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Material> GetByKodAsync(string mat_kod)
        {
            return await _context.Materials.FirstOrDefaultAsync(x => x.mat_kodu == mat_kod);
        }
    }
}
