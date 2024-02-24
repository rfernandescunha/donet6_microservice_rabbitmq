using GeekShopping.Order.Api.Configs.Settings;
using GeekShopping.Order.Api.Domain.Dto.Messages;
using GeekShopping.Order.Api.Domain.Entities;
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
using GeekShopping.Order.Api.Infra.Data.Repository;
using GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages;
using GeekShopping.Order.Api.Domain.Interfaces.IServices;
using GeekShopping.Order.Api.Domain.Dto;
using GeekShopping.OrderAPI.Messages;

namespace GeekShopping.Order.Api.Domain.Services.Messages
{
    public class RabbitMqConsumerMsgServices : BackgroundService
    {
        private readonly IOptions<AppSettingsRabbitMq> _serviceSettings;
        private readonly IOrderServices _orderServices;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        

        public RabbitMqConsumerMsgServices(IOrderServices orderServices, IOptions<AppSettingsRabbitMq> serviceSettings)
        {
            _serviceSettings = serviceSettings;
            _orderServices = orderServices;

            var factory = new ConnectionFactory
            {
                HostName = _serviceSettings.Value._hostName,
                UserName = _serviceSettings.Value._password,
                Password = _serviceSettings.Value._password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
            
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                var vo = JsonSerializer.Deserialize<CheckoutHeaderMsgDto>(content);


                _orderServices.Save(ProcessMsg(vo));

                _channel.BasicAck(evt.DeliveryTag, false);
            };

            _channel.BasicConsume("checkoutqueue", false, consumer);

            return Task.CompletedTask;
        }

        private OrderHeaderDto ProcessMsg(CheckoutHeaderMsgDto vo)
        {
            OrderHeaderDto order = new()
            {
                UserId = vo.UserId,
                FirstName = vo.FirstName,
                LastName = vo.LastName,
                OrderDetails = new List<OrderDetailDto>(),
                CardNumber = vo.CardNumber,
                CouponCode = vo.CouponCode,
                CVV = vo.CVV,
                DiscountAmount = vo.DiscountAmount,
                Email = vo.Email,
                ExpiryMonthYear = vo.ExpiryMothYear,
                OrderTime = DateTime.Now,
                PurchaseAmount = vo.PurchaseAmount,
                PaymentStatus = false,
                Phone = vo.Phone,
                DateTime = vo.DateTime
            };

            foreach (var details in vo.CartDetails)
            {
                OrderDetailDto detail = new()
                {
                    ProductId = details.ProductId,
                    ProductName = details.Product.Name,
                    Price = details.Product.Price,
                    Count = details.Count,
                };
                order.CartTotalItens += details.Count;
                order.OrderDetails.Add(detail);
            }

            return order;
        }

    }
}
