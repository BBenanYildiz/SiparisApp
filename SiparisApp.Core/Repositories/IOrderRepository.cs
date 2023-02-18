using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Repositories;

namespace SiparisApp.Core.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<OrderListDTOs>> GetOrderWitOrderStatus();
    }
}
