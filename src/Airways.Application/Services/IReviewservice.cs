using Airways.Application.Models;
using Airways.Application.Models.PricePolycy;
using Airways.Application.Models.Review;

namespace Airways.Application.Services
{
    public interface IReviewservice
    {
        Task<ReviewResponceModel> GetByIdAsync(Guid id);
        Task<List<ReviewResponceModel>> GetAllAsync();
        Task<CreateReviewResponceModel> CreateAsync(CreateReviewModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<ReviewResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateReviewResponceModel> UpdateAsync(Guid id, UpdateReviewModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
