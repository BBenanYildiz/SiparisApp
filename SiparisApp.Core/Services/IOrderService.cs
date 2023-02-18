using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Services;
using System.Threading.Tasks;

namespace SiparisApp.Core.Services
{
    public interface IOrderService : IGenericService<Order>
    {
        /// <summary>
        /// Sipariş Insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ApiResponse> OrderInsert(OrderInsertDTOs model);

        Task<ApiResponse> CustomerOrderNoValidation(string sip_musteri_no);

        Task<List<OrderListDTOs>> GetOrderWitOrderStatus();
    }
}
