using Airways.Application.Models;
using Airways.Application.Models.PricePolycy;
using Airways.Application.Models.Ticket;

namespace Airways.Application.Services
{
    public interface ITicketService
    {
        Task<TicketResponceModel> GetByIdAsync(Guid id);
        Task<List<TicketResponceModel>> GetAllAsync();
        Task<CreateTicketResponceModel> CreateAsync(CreateTicketsModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<TicketResponceModel>> 
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateTicketResponceModel> UpdateAsync(Guid id, UpdateTicketModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
