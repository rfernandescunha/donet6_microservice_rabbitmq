using GeekShopping.Payment.Api.Configs.Settings;
using GeekShopping.Payment.Api.Domain.Dto.Messages;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices;
using GeekShopping.Payment.Api.Domain.Dto;
using Microsoft.Extensions.Logging;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send;

namespace GeekShopping.Payment.Api.Domain.Services.Messages.Consumer
{
    public class PaymentConsumerMsgServices : BackgroundService
    {
        private readonly ILogger<PaymentConsumerMsgServices> _logger;
        private readonly IOptions<AppSettingsRabbitMq> _serviceSettings;
        private readonly IPaymentProcessServices _paymentProcessServices;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public PaymentConsumerMsgServices(ILogger<PaymentConsumerMsgServices> logger, IPaymentProcessServices paymentProcesServices, IOptions<AppSettingsRabbitMq> serviceSettings)
        {
            _serviceSettings = serviceSettings;
            _paymentProcessServices = paymentProcesServices;
            _logger = logger;

            var factory = new ConnectionFactory
            {
                HostName = _serviceSettings.Value._hostName,
                UserName = _serviceSettings.Value._password,
                Password = _serviceSettings.Value._password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "orderpaymentprocessqueue", false, false, false, arguments: null);

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("await messages...");

            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());

                _logger.LogInformation($"[New message | {DateTime.Now:yyyy-MM-dd HH:mm:ss}] " + content);

                var dto = JsonSerializer.Deserialize<PaymentProcessConsumerMsgDto>(content);

                _paymentProcessServices.PaymentProcess(PaymentDto(dto));

                _channel.BasicAck(evt.DeliveryTag, false);
            };

            _channel.BasicConsume("orderpaymentprocessqueue", false, consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"PaymentConsumerMsgServices active em: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                await Task.Delay(_serviceSettings.Value._executeConsumerTimer, stoppingToken);
            }
        }


        private PaymentDto PaymentDto(PaymentProcessConsumerMsgDto dto)
        {
            var payment = new PaymentDto()
            {
                Id = dto.Id,
                Name = dto.Name,
                CardNumber = dto.CardNumber,
                CVV = dto.CVV,
                ExpiryMonthYear = dto.ExpiryMonthYear,
                OrderId = dto.OrderId,
                PurchaseAmount = dto.PurchaseAmount,
                Email = dto.Email
            };

            return payment;
        }


    }
}
