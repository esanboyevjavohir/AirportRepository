using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;

namespace Airways.Application.Services.Impl
{
    public class AicraftService : IAircraftService
    {
        private readonly IMapper _mapper;
        private readonly IAircraftRepository _aicraftrepository;

        public AicraftService(IAircraftRepository aicraftRepository,
            IMapper mapper)
        {
            _aicraftrepository = aicraftRepository;
            _mapper = mapper;
        }

        public async Task<AicraftResponceModel> GetByIdAsync(Guid id)
        {
            var aircraft = await _aicraftrepository.GetFirstAsync(a => a.Id == id);
            if (aircraft == null) { throw new Exception("Aircraft not found"); }

            return _mapper.Map<AicraftResponceModel>(aircraft);
        }

        public async Task<List<AicraftResponceModel>> GetAllAsync()
        {
            var res = await _aicraftrepository.GetAllAsync(_ => true);
            return _mapper.Map<List<AicraftResponceModel>>(res);
        }

       /* public async Task<IEnumerable<AicraftResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _aicraftrepository.GetAllAsync(ti => ti.Airline.Id == id);


            return _mapper.Map<IEnumerable<AicraftResponceModel>>(todoItems);
        }*/

        public async Task<CreateAicraftResponceModel> CreateAsync(CreateAircraftModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Aircraft>(createTodoItemModel);

            return new CreateAicraftResponceModel
            {
                Id = (await _aicraftrepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateAicraftResponceModel> UpdateAsync(Guid id, UpdateAicraftModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _aicraftrepository.GetFirstAsync(ti => ti.Airline.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateAicraftResponceModel
            {
                Id = (await _aicraftrepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _aicraftrepository.GetFirstAsync(ti => ti.Id == id);

            if (todoItem == null) return false;

            await _aicraftrepository.DeleteAsync(todoItem);

            return true;
        }
    }
}
