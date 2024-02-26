using AutoMapper;
using GeekShopping.Order.Api.Domain.Dto;
using GeekShopping.Order.Api.Domain.Dto.Messages;
using GeekShopping.Order.Api.Domain.Entities;
using GeekShopping.Order.Api.Domain.Interfaces.IServices;
using GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages.Send;
using GeekShopping.Order.Api.Infra.Data.Repository;
using System;
using System.Threading.Tasks;

namespace GeekShopping.Order.Api.Domain.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly OrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IPaymentSendMsgServices _paymentSendMsgServices;

        public OrderServices(OrderRepository orderRepository, IMapper mapper, IPaymentSendMsgServices paymentSendMsgServices)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _paymentSendMsgServices = paymentSendMsgServices;
        }

        public async Task<bool> Save(OrderHeaderDto dto)
        {
            try
            {
                var ent = _mapper.Map<OrderHeader>(dto);

                var result = await _orderRepository.Save(ent);

                _paymentSendMsgServices.SendMessage(PaymentMsgDto(dto), "orderpaymentprocessqueue");

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PaymentStatusUpdate(long orderHeaderId, bool paid)
        {
            try
            {

               return await _orderRepository.PaymentStatusUpdate(orderHeaderId, paid);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PaymentMsgDto PaymentMsgDto(OrderHeaderDto dto)
        {
            var payment = new PaymentMsgDto()
            {
                Name = dto.FirstName + " " + dto.LastName,
                CardNumber = dto.CardNumber,
                CVV = dto.CVV,
                ExpiryMonthYear = dto.ExpiryMonthYear,
                OrderId = dto.Id,
                PurchaseAmount = dto.PurchaseAmount,
                Email = dto.Email
            };

            return payment;
        }
    }
}
