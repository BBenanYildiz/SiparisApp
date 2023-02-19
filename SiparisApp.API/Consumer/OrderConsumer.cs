using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Services;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

public class OrderConsumer : DefaultBasicConsumer
{
    private readonly IOrderService _orderService;

    public OrderConsumer(IModel channel, IOrderService orderService) : base(channel)
    {
        _orderService = orderService;
    }

    public override async void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
    {
        var message = Encoding.UTF8.GetString(body.ToArray());
        var order = JsonConvert.DeserializeObject<OrderInsertDTOs>(message);

        var result = await _orderService.OrderInsert(order);

        var responseJson = JsonConvert.SerializeObject(result);
        var responseBytes = Encoding.UTF8.GetBytes(responseJson);
        Model.BasicPublish("", properties.ReplyTo, null, responseBytes);

        Model.BasicAck(deliveryTag, false);
    }
}
