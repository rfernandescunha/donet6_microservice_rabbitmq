using GeekShopping.Cart.Api.Configs.Settings;
using GeekShopping.MessageBus;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using GeekShopping.Cart.Api.Domain.Messages;

namespace GeekShopping.Cart.Api.RabbitMqSender
{
    public class RabbitMqSender : IRabbitMqSender
    {
        private readonly IOptions<AppSettingsRabbitMq> _serviceSettings;

        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;

        public RabbitMqSender(IOptions<AppSettingsRabbitMq> serviceSettings)
        {
            _serviceSettings = serviceSettings;

            _hostName = _serviceSettings.Value._hostName;
            _password = _serviceSettings.Value._password;
            _userName = _serviceSettings.Value._userName;
            //_connection = connection;
        }

        public void SendMessage(CheckoutHeaderMsgDto message, string queueName)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                Password = _password,
                UserName = _userName,
            };

            _connection = factory.CreateConnection();

            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
                
                byte[] body = GetMessageAsByteArray(message);
                
                channel.BasicPublish(
                                        exchange: "",
                                        routingKey: queueName,
                                        basicProperties: null,
                                        body: body);
            }
        }

        private byte[] GetMessageAsByteArray(CheckoutHeaderMsgDto message)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize<CheckoutHeaderMsgDto>(message, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }
    }
}
