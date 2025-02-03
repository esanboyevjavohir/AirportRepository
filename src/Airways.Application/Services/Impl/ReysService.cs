using Airways.Application.Models.Aicraft;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Reys;
using Airways.DataAccess.Repository.Impl;

namespace Airways.Application.Services.Impl
{
    public class ReysService:IReysService
    {
        private readonly IMapper _mapper;
        private readonly IReysRepository _reysrepository;

        public ReysService(IReysRepository reysRepository,
            IMapper mapper)
        {
            _reysrepository = reysRepository;
            _mapper = mapper;
        }

        public async Task<ReysResponceModel> GetByIdAsync(Guid id)
        {
            var aircraft = await _reysrepository.GetFirstAsync(a => a.Id == id);
            if (aircraft == null) { throw new Exception("Aircraft not found"); }

            return _mapper.Map<ReysResponceModel>(aircraft);
        }

        public async Task<IEnumerable<ReysResponceModel>> GetAllAsync()
        {
            var res = await _reysrepository.GetAllAsync(_ => true);
            return _mapper.Map<List<ReysResponceModel>>(res);
        }

        public async Task<IEnumerable<ReysResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _reysrepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<ReysResponceModel>>(todoItems);
        }

        public async Task<CreateReysResponceModel> CreateAsync(CreateReysModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Reys>(createTodoItemModel);
            var res = await _reysrepository.AddAsync(todoItem);
            if(res == null)
                throw new ArgumentNullException(nameof(res));
            return new CreateReysResponceModel
            {
                Id = res.Id
            };
        }

        public async Task<UpdateReysResponceModel> UpdateAsync(Guid id, UpdateReysModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _reysrepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateReysResponceModel
            {
                Id = (await _reysrepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _reysrepository.GetFirstAsync(ti => ti.Id == id);

            if (todoItem == null) return false;

            await _reysrepository.DeleteAsync(todoItem);

            return true;
        }
    }
}
