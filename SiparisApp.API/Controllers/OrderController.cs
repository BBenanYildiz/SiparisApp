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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderService> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderService> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        // RabbitMQ Kuyruk bağlantı bilgileri
        private const string RABBITMQ_HOST = "localhost";
        private const string RABBITMQ_USERNAME = "guest";
        private const string RABBITMQ_PASSWORD = "guest";
        private const string RABBITMQ_QUEUE_NAME = "ordersQueue";


        /// <summary>
        /// Sipariş İnsert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("OrderInsert")]
        [Route("OrderInsert")]
        public async Task<IActionResult> OrderInsert(List<OrderInsertDTOs> orders)
        {
            ApiResponse result = new ApiResponse();
            try
            {
                foreach (var order in orders)
                {
                    result = await _orderService.OrderInsert(order);
                }

                return StatusCode((int)result.StatusCode, result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "İşlem başarısız.");
            }
        }


        [HttpPost]
        [ActionName("SendOrdersToQueue")]
        [Route("SendOrdersToQueue")]
        public IActionResult SendOrdersToQueue(List<OrderInsertDTOs> orders)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = RABBITMQ_HOST, UserName = RABBITMQ_USERNAME, Password = RABBITMQ_PASSWORD };
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

                    //// Siparişler kuyruğa eklendikten sonra consumer'ı oluşturarak siparişleri veritabanına kaydedebilirsiniz.
                    //var consumer = new OrderConsumer(channel, _orderService);
                    //channel.BasicConsume(queue: RABBITMQ_QUEUE_NAME, autoAck: false, consumer: consumer);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received  += async(model, ea)  =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var order = JsonConvert.DeserializeObject<OrderInsertDTOs>(message);

                        var result = await _orderService.OrderInsert(order);

                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };
                    channel.BasicConsume(queue: "ordersQueue",
                                         autoAck: false,
                                         consumer: consumer);


                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Siparişleri kuyruğa ekleme işleminde hata oluştu!");
                return StatusCode(500, "Bir hata oluştu!");
            }
        }

    }

}

