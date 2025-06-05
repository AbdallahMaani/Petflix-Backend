using System.Collections.Generic;
using System.Threading.Tasks;
using FullPetflix.OrderFiles;

namespace FullPetflix.OrderFiles
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order> UpdateOrderStatusAsync(int orderId, string status);
        Task<bool> DeleteOrderAsync(int orderId); // Added for order deletion
    }
}