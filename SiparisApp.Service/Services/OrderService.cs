using AutoMapper;
using Azure;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Repositories;
using SiparisApp.Core.Services;
using SiparisApp.Core.UnitOfWorks;
using SiparisApp.Repository.Repositories;
using SiparisApp.Service.Services;
using System.Net;
using System.Text;

namespace SiparisApp.Service.Services
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly  ILogger<OrderService> _logger;
        private readonly IMapper _mapper;
        private readonly IMaterialService _materialService;
        private readonly IOrderStatusService _orderStatusService;
        public OrderService(IGenericRepository<Order> repository,
            IUnitOfWork unitOfWork,
            IOrderRepository orderRepository,
            IMapper mapper,
            IMaterialService materialService,
            IOrderStatusService orderStatusService,
           ILogger<OrderService> logger) : base(repository, unitOfWork)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _materialService = materialService;
            _orderStatusService = orderStatusService;
            _logger = logger;
        }


        /// <summary>
        /// Film listesini kayıt eder.
        /// </summary>
        /// <param name="moviesList"></param>
        /// <returns></returns>
        public async Task<ApiResponse> OrderInsert(OrderInsertDTOs model)
        {
            try
            {
                OrderResponseDTOs orderResponse = new OrderResponseDTOs();
                Order entity = new Order();

                if (model.ord_musteri_no is not null)
                {
                    var result = await CustomerOrderNoValidation(model.ord_musteri_no);

                    if (!result.IsSuccess)
                    {
                        _logger.LogWarning($"Sipariş müşteri numarası doğrulama hatası: {model.ord_musteri_no}");
                        return result;
                    }
                }

                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.ord_musteri_no = model.ord_musteri_no;
                entity.ord_cikis_adres = model.ord_cikis_adres;
                entity.ord_varis_adres = model.ord_varis_adres;
                entity.ord_miktar = model.ord_miktar;
                entity.ord_miktar_birim = model.ord_miktar_birim;
                entity.ord_agirlik = model.ord_agirlik;
                entity.ord_agirlik_birim = model.ord_agirlik_birim;
                entity.ord_malzeme_kodu = model.ord_malzeme_kodu;
                entity.ord_malzeme_adi = model.ord_malzeme_adi;
                entity.ord_not = model.ord_not;
                entity.ord_durum = "Sipariş Alındı";

                var resultInsert = await this.AddAsync(entity);

                _logger.LogInformation("Sipariş kaydı oluşturuldu. Müşteri Sipariş No: {MusteriSiparisNo}", resultInsert.ord_musteri_no);

                orderResponse = _mapper.Map<OrderResponseDTOs>(resultInsert);

                // Eğer malzeme kodu yoksa burada gelen malzeme koduna göre insert işlemi yapılır
                if (model.ord_malzeme_kodu is not null)
                {
                    var material = await _materialService.GetByKodAsync(model.ord_malzeme_kodu);

                    if (material is null)
                    {
                        material = new Material();

                        material.mat_kodu = model.ord_malzeme_kodu;
                        material.mat_adi = model.ord_malzeme_adi;

                        await _materialService.InsertMaterial(material);

                        _logger.LogInformation("Malzeme kaydı oluşturuldu. Malzeme Kodu: {MalzemeKodu}", material.mat_kodu);
                    }
                }

                // Sipariş Durum Tablosuna kayıt atılır.
                if (resultInsert.ord_musteri_no is not null)
                {
                    OrderStatus orderStatus = new OrderStatus();

                    orderStatus.ord_sta_durum = "Sipariş Alındı";
                    orderStatus.ord_sta_musteri_no = resultInsert.ord_musteri_no;
                    orderStatus.ord_sta_degisim_tarihi = DateTime.Now;
                    orderStatus.OrderId = resultInsert.Id;
                    await _orderStatusService.AddAsync(orderStatus);

                    _logger.LogInformation("Müşteri sipariş numarası için sipariş durumu eklendi {MusteriSiparisNo}", resultInsert.ord_musteri_no);
                }


                orderResponse.ord_musteri_no = resultInsert.ord_musteri_no;
                orderResponse.ord_sistem_no = resultInsert.Id;
                orderResponse.ord_hata_aciklama = "Başarılı işlem";
                orderResponse.ord_statu = 0;

                if (orderResponse is null)
                {
                    _logger.LogWarning("Sipariş yanıtı bulunamadı!");
                    return ApiResponse.CreateResponse(HttpStatusCode.NoContent, ApiResponse.ErrorMessage);
                }

                return ApiResponse.CreateResponse(HttpStatusCode.OK, ApiResponse.SuccessMessage, orderResponse);

            }
            catch (Exception ex)
            {
                return ApiResponse.CreateResponse(HttpStatusCode.InternalServerError, ApiResponse.ErrorMessage);
            }
        }


        /// <summary>
        /// Aynı müşteri numarası kontrolü yapılır
        /// </summary>
        /// <param name="ord_musteri_no"></param>
        /// <returns></returns>
        public async Task<ApiResponse> CustomerOrderNoValidation(string ord_musteri_no)
        {

            try
            {
                OrderResponseDTOs orderResponse = new OrderResponseDTOs();
                ApiResponse response = new ApiResponse();

                if (ord_musteri_no is not null)
                {
                    var result = await _orderRepository.AnyAsync(s => s.ord_musteri_no == ord_musteri_no);

                    if (result)
                    {
                        orderResponse.ord_hata_aciklama = "Aynı müşteri sipariş no girişi mevcuttur.Lütfen farklı bir sipariş giriniz!";
                        orderResponse.ord_statu = 1;
                        orderResponse.ord_sistem_no = 0;
                        orderResponse.ord_musteri_no = ord_musteri_no;

                        response = ApiResponse.CreateResponse(HttpStatusCode.NotFound, ApiResponse.ErrorMessage, orderResponse);

                        _logger.LogWarning($"Sipariş müşteri numarası doğrulama hatası: {response.Message}");
                    }
                    else
                    {
                        response = ApiResponse.CreateResponse(HttpStatusCode.OK, ApiResponse.SuccessMessage, orderResponse);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Sipariş müşteri numarası doğrulama hatası: {ex.Message}");
                return ApiResponse.CreateResponse(HttpStatusCode.InternalServerError, ApiResponse.ErrorMessage);
            }
        }

        public async Task<List<OrderListDTOs>> GetOrderWitOrderStatus()
        {
            try
            {
                var result = await _orderRepository.GetOrderWitOrderStatus();

                _logger.LogInformation("Sipariş durumları başarılı şekilde çekildi.");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sipariş durumları çekilemedi.");
                throw;
            }
           
        }
    }
}
