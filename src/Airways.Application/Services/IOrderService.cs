using Airways.Application.Models;
using Airways.Application.Models.Order;

namespace Airways.Application.Services
{
    public interface IOrderService
    {
        Task<OrderResponceModel> GetByIdAsync(Guid id);
        Task<IEnumerable<OrderResponceModel>> GetAllAsync();

        Task<CreateOrderResponceModel> CreateAsync(CreateOrderModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id);

        Task<UpdateOrderResponceModel> UpdateAsync(Guid id, UpdateOrderModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
