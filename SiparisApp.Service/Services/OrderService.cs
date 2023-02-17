using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IMaterialService _materialService;
        private readonly IOrderStatusService _orderStatusService;
        public OrderService(IGenericRepository<Order> repository,
            IUnitOfWork unitOfWork,
            IOrderRepository orderRepository,
            IMapper mapper,
            IMaterialService materialService,
            IOrderStatusService orderStatusService) : base(repository, unitOfWork)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _materialService = materialService;
            _orderStatusService = orderStatusService;
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
                        return result;
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
                    }
                }

                // Sipariş Durum Tablosuna kayıt atılır.
                if (resultInsert.ord_musteri_no is not null)
                {
                    OrderStatus orderStatus = new OrderStatus();

                    orderStatus.ord_sta_durum = "Sipariş Alındı";
                    orderStatus.ord_sta_musteri_no = resultInsert.ord_musteri_no;
                    orderStatus.ord_sta_degisim_tarihi = DateTime.Now;

                    await _orderStatusService.AddAsync(orderStatus);
                }


                orderResponse.ord_musteri_no = resultInsert.ord_musteri_no;
                orderResponse.ord_sistem_no = resultInsert.Id;
                orderResponse.ord_hata_aciklama = "Başarılı işlem";
                orderResponse.ord_statu = 0;

                if (orderResponse is null)
                    return ApiResponse.CreateResponse(HttpStatusCode.NoContent, ApiResponse.ErrorMessage);

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
                }
                else
                {
                    response = ApiResponse.CreateResponse(HttpStatusCode.OK, ApiResponse.SuccessMessage, orderResponse);
                }
            }
            return response;
        }
    }
}
