using AutoMapper;
using Azure;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Repositories;
using SiparisApp.Core.Services;
using SiparisApp.Core.UnitOfWorks;
using SiparisApp.Service.Services;
using System.Net;
using System.Net.Http;
using System.Text;

namespace SiparisApp.Service.Services
{
    public class OrderStatusService : GenericService<OrderStatus>, IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderStatusService> _logger;
        private readonly HttpClient _httpClient;

        public OrderStatusService(IGenericRepository<OrderStatus> repository,
              IUnitOfWork unitOfWork,
              IOrderStatusRepository orderStatusRepository,
              IMapper mapper,
              ILogger<OrderStatusService> logger,
              IHttpClientFactory httpClientFactory) : base(repository, unitOfWork)
        {
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<ApiResponse> OrderSatatusUpdate(OrderStatusUpdateDTOs model)
        {
            try
            {
                OrderStatusUpdateDTOs response = new OrderStatusUpdateDTOs();

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

                    var updateEntity = await GetByIdAsync(entity.Id);
                    response = _mapper.Map<OrderStatusUpdateDTOs>(updateEntity);
                    response.ord_durum = updateEntity.ord_sta_durum;
                    response.ord_musteri_no = updateEntity.ord_sta_musteri_no;
                    response.ord_degisim_tarihi = updateEntity.ord_sta_degisim_tarihi;
                }

                _logger.LogInformation("Müşteri sipariş numarası için sipariş durumu güncellendi {SiparisDurumu}", entity.ord_sta_durum);
                
                OrderStatusUpdateAsync(response);


                return ApiResponse.CreateResponse(HttpStatusCode.OK, ApiResponse.SuccessMessage, response);


                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Müşteri statü entegrasyon servisi çağrısı başarısız oldu: {ApiResponse.ErrorMessage}");
                return ApiResponse.CreateResponse(HttpStatusCode.InternalServerError, ApiResponse.ErrorMessage);
            }
        }

        public async Task<OrderStatusUpdateDTOs> OrderStatusUpdateAsync(OrderStatusUpdateDTOs request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://api.xx.com/status", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrderStatusUpdateDTOs>(responseContent);
                return result;
            }

            throw new Exception($"İşlem başarısız {response.StatusCode}");
        }

    }
}
