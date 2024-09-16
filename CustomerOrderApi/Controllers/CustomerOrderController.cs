using CustomerOrder.Core.Entities;
using CustomerOrder.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderService _orderService;

        public CustomerOrderController(ICustomerOrderService orderService)
        {
            _orderService = orderService;
        }

        // OB(15.09.2024): Tüm siparişleri getir
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders); // OB(15.09.2024): Başarılı yanıt
        }

        // OB(15.09.2024): Belirli bir siparişi ID'ye göre getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound(); // OB(15.09.2024): Sipariş bulunamazsa 404 yanıtı

            return Ok(order); // OB(15.09.2024): Başarılı yanıt
        }

        // OB(15.09.2024): Yeni bir sipariş oluştur
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CustomerOrder.Infrastructure.Data.CustomerOrder order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); 

            await _orderService.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById), order); 
        }

        // OB(15.09.2024): Mevcut bir siparişi güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] CustomerOrder.Infrastructure.Data.CustomerOrder order)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); 

            var existingOrder = await _orderService.GetOrderByIdAsync(id);
            if (existingOrder == null)
                return NotFound();

            await _orderService.UpdateOrderAsync(order); 

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var existingOrder = await _orderService.GetOrderByIdAsync(id);
            if (existingOrder == null)
                return NotFound(); 

            await _orderService.DeleteOrderAsync(id);
            return NoContent(); 
        }
    }
}
