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

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // RabbitMQ Kuyruk bağlantı bilgileri
        private const string RABBITMQ_HOST = "localhost";
        private const string RABBITMQ_USERNAME = "guest";
        private const string RABBITMQ_PASSWORD = "guest";
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
        public async Task<IActionResult> SendOrdersToQueue(List<OrderInsertDTOs> orders)
        {
            var factory = new ConnectionFactory()
            {
                HostName = RABBITMQ_HOST,
                UserName = RABBITMQ_USERNAME,
                Password = RABBITMQ_PASSWORD
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: RABBITMQ_QUEUE_NAME,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    foreach (var order in orders)
                    {
                        var orderJson = JsonConvert.SerializeObject(order);
                        var body = Encoding.UTF8.GetBytes(orderJson);
                        channel.BasicPublish(exchange: "", routingKey: RABBITMQ_QUEUE_NAME, basicProperties: null, body: body);
                    }

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += async (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var order = JsonConvert.DeserializeObject<OrderInsertDTOs>(message);

                        await OrderInsert(order);

                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };
                    channel.BasicConsume(queue: RABBITMQ_QUEUE_NAME, autoAck: false, consumer: consumer);
                }
            }

            return Ok();
        }

    }
}

