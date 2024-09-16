using CustomerOrder.Core.Entities;
using CustomerOrder.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrder.Infrastructure.Repositories
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private readonly List<CustomerOrders> _orders = new List<CustomerOrders>();

        public async Task<IEnumerable<CustomerOrders>> GetAllOrdersAsync()
        {
            return await Task.FromResult(_orders);
        }

        public async Task<CustomerOrders> GetOrderByIdAsync(int orderId)
        {
            return await Task.FromResult(_orders.Find(o => o.Id == orderId));
        }

        public async Task AddOrderAsync(CustomerOrders order)
        {
            _orders.Add(order);
            await Task.CompletedTask;
        }

        public async Task UpdateOrderAsync(CustomerOrders order)
        {
            var existingOrder = _orders.Find(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.Customer = order.Customer;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.Status = order.Status;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = _orders.Find(o => o.Id == orderId);
            if (order != null)
            {
                _orders.Remove(order);
            }
            await Task.CompletedTask;
        }
    }
}
