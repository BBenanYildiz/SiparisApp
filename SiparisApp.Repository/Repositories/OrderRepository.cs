using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Repositories;

namespace SiparisApp.Repository.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly IMapper _mapper;
        public OrderRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<OrderListDTOs>> GetOrderWitOrderStatus()
        {
            return await _context
                .Orders
                .Include(x => x.OrderStatuses)
                .Select(s => new OrderListDTOs
                {
                    Id = s.Id.ToString(),
                    ord_musteri_no = s.ord_musteri_no,
                    ord_varis_adres = s.ord_varis_adres,
                    ord_cikis_adres = s.ord_cikis_adres,
                    ord_miktar_birim = s.ord_miktar_birim,
                    ord_miktar = s.ord_miktar,
                    ord_agirlik = s.ord_agirlik,
                    ord_agirlik_birim = s.ord_agirlik_birim,
                    ord_malzeme_kodu = s.ord_malzeme_kodu,
                    ord_malzeme_adi = s.ord_malzeme_adi,
                    ord_not = s.ord_not,
                    ord_durum = s.OrderStatuses.OrderByDescending(d => d.ord_sta_musteri_no).FirstOrDefault().ord_sta_durum
                }).ToListAsync();
        }
    }
}
