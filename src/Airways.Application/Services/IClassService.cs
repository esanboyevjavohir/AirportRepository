using Airways.Application.Models;
using Airways.Application.Models.Classs;

namespace Airways.Application.Services
{
    public interface IClassService
    {
        Task<ClassResponceModel> GetByIdAsync(Guid id);

        Task<List<ClassResponceModel>> GetAllAsync();
        Task<CreateClassResponceModel> CreateAsync(CreateCLassModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<ClassResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateClassResponceModel> UpdateAsync(Guid id, UpdateClassModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
