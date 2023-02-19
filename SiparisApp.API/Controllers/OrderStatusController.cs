using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Services;
using SiparisApp.Service.Services;
using System.Net;
using System.Text;
using System.Threading.Channels;

namespace SiparisApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;
        private readonly ILogger<OrderStatusService> _logger;

        public OrderStatusController(IOrderStatusService orderStatusService, 
            ILogger<OrderStatusService> logger)
        {
            _orderStatusService = orderStatusService;
            _logger = logger;
        }

        /// <summary>
        /// Sipariş İnsert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("OrderStatusUpdate")]
        [Route("OrderStatusUpdate")]
        public async Task<IActionResult> OrderStatusUpdate(OrderStatusUpdateDTOs model)
        {
            var result = await _orderStatusService.OrderSatatusUpdate(model);
            return StatusCode((int)result.StatusCode, result);

        }
    }



}

