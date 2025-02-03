using Airways.Application.Models;
using Airways.Application.Models.Payment;

namespace Airways.Application.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponceModel> GetByIdAsync(Guid id);
        Task<List<PaymentResponceModel>> GetAllAsync();
        Task<CreatePaymentResponceModel> CreateAsync(CreatePaymentModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<PaymentResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdatePaymentResponceModel> UpdateAsync(Guid id, UpdatePaymentModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
