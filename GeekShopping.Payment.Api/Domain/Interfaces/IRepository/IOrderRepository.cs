using GeekShopping.Payment.Api.Domain.Entities;
using System.Threading.Tasks;

namespace GeekShopping.Payment.Api.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task<bool> Save(OrderHeader header);
        Task UpdatePaymentStatus(long orderHeaderId, bool paid);
    }
}
