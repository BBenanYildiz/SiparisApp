using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Services;

namespace SiparisApp.Web.Controllers
{
    public class OrdersStatusController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IOrderStatusService _orderStatusService;
        public OrdersStatusController(IOrderService orderService,
            IMapper mapper, IOrderStatusService orderStatusService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _orderStatusService = orderStatusService;
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

            try
            {
                var entity = await _orderService.GetByIdAsync(id);
                var result = _mapper.Map<OrderStatusUpdateDTOs>(entity);

                result.ord_musteri_no = entity.ord_musteri_no;

                return PartialView("_OrderStatusUpdate", result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sipariş durumu güncellemesi için sipariş detayında hata alındı", id);
                return Content("");

            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderStatusUpdate(OrderStatusUpdateDTOs model)
        {
            await _orderStatusService.OrderSatatusUpdate(model);
            return RedirectToAction("Index","Orders");
        }
    }
}
