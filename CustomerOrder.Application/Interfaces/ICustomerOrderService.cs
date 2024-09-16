using CustomerOrder.Core.Entities;
using CustomerOrder.Infrastructure.Data;
using CustomerOrder.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrder.Application.Interfaces
{
    public interface ICustomerOrderService
    {
        Task<IEnumerable<Infrastructure.Data.CustomerOrder>> GetAllOrdersAsync(); 
        Task<CustomerOrders> GetOrderByIdAsync(int orderId);   
        Task AddOrderAsync(CustomerOrder.Infrastructure.Data.CustomerOrder order);              
        Task UpdateOrderAsync(Infrastructure.Data.CustomerOrder order);          
        Task DeleteOrderAsync(int orderId);                   
    }
}
