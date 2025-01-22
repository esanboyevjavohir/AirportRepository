using Airways.Application.Models.Payment;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Ticket;
using Airways.Application.Models.Aicraft;
using Airways.DataAccess.Repository.Impl;

namespace Airways.Application.Services.Impl
{
    public class TicketService:ITicketService
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;


        public TicketService(ITicketRepository ticketRepository,
            IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<TicketResponceModel> GetByIdAsync(Guid id)
        {
            var aircraft = await _ticketRepository.GetFirstAsync(a => a.Id == id);
            if (aircraft == null) { throw new Exception("Aircraft not found"); }

            return _mapper.Map<TicketResponceModel>(aircraft);
        }

        public async Task<List<TicketResponceModel>> GetAllAsync()
        {
            var res = await _ticketRepository.GetAllAsync(_ => true);
            return _mapper.Map<List<TicketResponceModel>>(res);
        }

        public async Task<IEnumerable<TicketResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _ticketRepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<TicketResponceModel>>(todoItems);
        }

        public async Task<CreateTicketResponceModel> CreateAsync(CreateTicketsModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Ticket>(createTodoItemModel);


            return new CreateTicketResponceModel
            {
                Id = (await _ticketRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateTicketResponceModel> UpdateAsync(Guid id, UpdateTicketModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _ticketRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateTicketResponceModel
            {
                Id = (await _ticketRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _ticketRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _ticketRepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
