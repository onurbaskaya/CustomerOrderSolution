using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerOrder.Core.Entities;

namespace CustomerOrder.Core.Interfaces
{
    public interface ICustomerOrderRepository
    {
        Task<IEnumerable<CustomerOrders>> GetAllOrdersAsync();
        Task<CustomerOrders> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(CustomerOrders order);
        Task UpdateOrderAsync(CustomerOrders order);
        Task DeleteOrderAsync(int orderId);
    }
}
