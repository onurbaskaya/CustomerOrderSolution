using CustomerOrder.Application.Interfaces;
using CustomerOrder.Core.Entities;
using CustomerOrder.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrder.Application.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerOrderRepository _customerOrderRepository;

        public CustomerOrderService(ICustomerOrderRepository customerOrderRepository)
        {
            _customerOrderRepository = customerOrderRepository;
        }

        public async Task<IEnumerable<CustomerOrders>> GetAllOrdersAsync()
        {
            return await _customerOrderRepository.GetAllOrdersAsync();
        }

        public async Task<CustomerOrders> GetOrderByIdAsync(int orderId)
        {
            return await _customerOrderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task AddOrderAsync(CustomerOrders order)
        {
            await _customerOrderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(CustomerOrders order)
        {
            await _customerOrderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _customerOrderRepository.DeleteOrderAsync(orderId);
        }

        Task<IEnumerable<Infrastructure.Data.CustomerOrder>> ICustomerOrderService.GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddOrderAsync(Infrastructure.Data.CustomerOrder order)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderAsync(Infrastructure.Data.CustomerOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
