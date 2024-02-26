using GeekShopping.Order.Api.Domain.Dto;
using GeekShopping.Order.Api.Domain.Entities;
using System.Threading.Tasks;

namespace GeekShopping.Order.Api.Domain.Interfaces.IServices
{
    public interface IOrderServices
    {
        Task<bool> Save(OrderHeaderDto header);
        Task<bool> PaymentStatusUpdate(long orderHeaderId, bool paid);
    }
}
