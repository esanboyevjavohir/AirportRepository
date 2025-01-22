using Airways.Application.Models;
using Airways.Application.Models.PricePolycy;

namespace Airways.Application.Services
{
    public interface IPricePolicyService
    {
        Task<PricePolicyResponceModel> GetByIdAsync(Guid id );
        Task<List<PricePolicyResponceModel>> GetAllAsync();
        Task<CreatePricePolicyResponceModel> CreateAsync(CreatePricePolicyModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<PricePolicyResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdatePricePolicyResponceModel> UpdateAsync(Guid id, UpdatePricePolicyModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
     

    }
}
