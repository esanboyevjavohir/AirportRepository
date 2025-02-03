using Airways.Application.Models;
using Airways.Application.Models.Airline;
using Airways.Core.Entity;
using System.Linq.Expressions;

namespace Airways.Application.Services
{
    public interface IAirlineService
    {
        Task<AirlineResponceModel> GetByIdAsync(Guid id);
        
        Task<List<AirlineResponceModel>> GetAllAsync();
        Task<CreateAirlineResponceModel> CreateAsync(CreateAirlineModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<AirlineResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateAirlineResponceModel> UpdateAsync(Guid id, UpdateAirlineModel updateTodoItemModel);
    }
}
