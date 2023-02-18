using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Services;
using System.Threading.Tasks;

namespace SiparisApp.Core.Services
{
    public interface IOrderStatusService : IGenericService<OrderStatus>
    {
        Task<ApiResponse> OrderSatatusUpdate(OrderStatusUpdateDTOs model);
    }
}
