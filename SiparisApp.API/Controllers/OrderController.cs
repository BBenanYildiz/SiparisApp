using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Services;

namespace SiparisApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> OrderInsert(OrderInsertDTOs model)
        {
            var result = await _orderService.OrderInsert(model);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
