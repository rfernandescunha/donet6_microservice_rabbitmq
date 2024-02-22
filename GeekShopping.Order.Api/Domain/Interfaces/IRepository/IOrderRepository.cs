using GeekShopping.Order.Api.Domain.Entities;

namespace GeekShopping.Order.Api.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<bool> Save(OrderHeader header);
        Task UpdatePaymentStatus(long orderHeaderId, bool paid);
    }
}
