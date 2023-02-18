using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Services;
using System.Text;

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

        // RabbitMQ Kuyruk bağlantı bilgileri
        private const string RABBITMQ_HOST = "localhost:7193"; 
        private const string RABBITMQ_USERNAME = "Yıldız";
        private const string RABBITMQ_PASSWORD = "Yıldız";
        private const string RABBITMQ_QUEUE_NAME = "ordersQueue";

        [HttpPost]
        [ActionName("OrderInsert")]
        [Route("OrderInsert")]
        public async Task<IActionResult> OrderInsert(OrderInsertDTOs model)
        {
            var result = await _orderService.OrderInsert(model);
            return StatusCode((int)result.StatusCode, result);
        }


        [HttpPost]
        [ActionName("SendOrdersToQueue")]
        [Route("SendOrdersToQueue")]
        public IActionResult SendOrdersToQueue(List<OrderInsertDTOs> orders)
        {
            var factory = new ConnectionFactory() { HostName = RABBITMQ_HOST,
                UserName = RABBITMQ_USERNAME, Password = RABBITMQ_PASSWORD };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: RABBITMQ_QUEUE_NAME, durable: false, exclusive: false, autoDelete: false, arguments: null);

                // Siparişleri kuyruğa ekleme işlemi
                foreach (var order in orders)
                {
                    var orderJson = JsonConvert.SerializeObject(order);
                    var body = Encoding.UTF8.GetBytes(orderJson);
                    channel.BasicPublish(exchange: "", routingKey: RABBITMQ_QUEUE_NAME, basicProperties: null, body: body);
                }
            }

            return Ok();
        }
    }
}
