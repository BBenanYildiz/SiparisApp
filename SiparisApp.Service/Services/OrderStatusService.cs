using AutoMapper;
using Azure;
using Microsoft.Extensions.Logging;
using SiparisApp.Core.DTOs;
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
    public class OrderStatusService : GenericService<OrderStatus>, IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderStatusService> _logger;
        public OrderStatusService(IGenericRepository<OrderStatus> repository,
            IUnitOfWork unitOfWork,
            IOrderStatusRepository orderStatusRepository,
            IMapper mapper,
            ILogger<OrderStatusService> logger) : base(repository, unitOfWork)
        {
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse> OrderSatatusUpdate(OrderStatusUpdateDTOs model)
        {
            try
            {
                var entity = this
                .GetAllAsync()
                .Result
                .Where(x => x.ord_sta_musteri_no == model.ord_musteri_no)
                .FirstOrDefault();

                if (entity is not null)
                {
                    entity.ord_sta_durum = model.ord_durum;
                    entity.UpdateDate = DateTime.Now;

                    await this.UpdateAsync(entity);
                }

                _logger.LogInformation("Müşteri sipariş numarası için sipariş durumu güncellendi {SiparisDurumu}", entity.ord_sta_durum);
                return ApiResponse.CreateResponse(HttpStatusCode.OK, ApiResponse.SuccessMessage, entity);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Müşteri statü entegrasyon servisi çağrısı başarısız oldu: {ApiResponse.ErrorMessage}");
                return ApiResponse.CreateResponse(HttpStatusCode.InternalServerError, ApiResponse.ErrorMessage);
            }
        }

    }
}
