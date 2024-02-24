using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using System;
using GeekShopping.Order.Api.Configs.Settings;
using GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages;

namespace GeekShopping.Order.Api.Domain.Services.Messages
{
    public class RabbitMqSenderServices<T> : IRabbitMqSenderMsgServices<T> where T : class
    {
        private readonly IOptions<AppSettingsRabbitMq> _serviceSettings;

        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;

        public RabbitMqSenderServices(IOptions<AppSettingsRabbitMq> serviceSettings)
        {
            _serviceSettings = serviceSettings;

            _hostName = _serviceSettings.Value._hostName;
            _password = _serviceSettings.Value._password;
            _userName = _serviceSettings.Value._userName;
        }

        public void SendMessage(T message, string queueName)
        {
            try
            {
                CreateConnection();

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
            catch (Exception)
            {
                throw new Exception($"erroo send msg {queueName}");
            }

        }

        private byte[] GetMessageAsByteArray(T message)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(message, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }


        private void CreateConnection()
        {
            try
            {
                if (_connection == null)
                {
                    var factory = new ConnectionFactory
                    {
                        HostName = _hostName,
                        Password = _password,
                        UserName = _userName,
                    };

                    _connection = factory.CreateConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
