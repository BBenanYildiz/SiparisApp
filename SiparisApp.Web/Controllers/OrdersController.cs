using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Services;

namespace SiparisApp.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IOrderStatusService _orderStatusService;
        public OrdersController(IOrderService orderService,
            IMapper mapper, IOrderStatusService orderStatusService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _orderStatusService = orderStatusService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _orderService.GetOrderWitOrderStatus();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> OrderStatusUpdate(int id)
        {
             var items = new List<SelectListItem>
              {
                 new SelectListItem { Value = "Sipariş Alındı", Text = "Sipariş Alındı" },
                 new SelectListItem { Value = "Yola Çıktı", Text = "Yola Çıktı" },
                 new SelectListItem { Value = "Dağıtım Merkezinde", Text = "Dağıtım Merkezinde" },
                 new SelectListItem { Value = "Dağıtıma Çıktı", Text = "Dağıtıma Çıktı" },
                 new SelectListItem { Value = "Teslim Edildi", Text = "Teslim " },
                 new SelectListItem { Value = "Teslim Edilemedi", Text = "Teslim Edilemedi" }
                };

            var orderStatusList = new SelectList(items, "Value", "Text");

            ViewBag.orderStatusList = orderStatusList;

            var entity = await _orderService.GetByIdAsync(id);

            var result = _mapper.Map<OrderStatusUpdateDTOs>(entity);

            result.ord_musteri_no = entity.ord_musteri_no;
            result.Id = entity.Id;

            return PartialView("_OrderStatusUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> OrderStatusUpdate(OrderStatusUpdateDTOs model)
        {

            var entity = _orderStatusService
                .GetAllAsync()
                .Result
                .Where(x => x.ord_sta_musteri_no == model.ord_musteri_no)
                .FirstOrDefault();

            if (entity is not null)
            {
                entity.ord_sta_durum = model.ord_durum;
                entity.UpdateDate = DateTime.Now;

                await _orderStatusService.UpdateAsync(entity);

            }

            return RedirectToAction("Index");
        }

    }
}
