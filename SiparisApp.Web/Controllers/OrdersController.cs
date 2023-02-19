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
            try
            {
                var result = await _orderService.GetOrderWitOrderStatus();
                return View(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Veriler çekilirken bir hata oluştu.");
                throw;
            }
        }
    }
}