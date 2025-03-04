﻿using Airways.Application.Models.Airline;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using AutoMapper;
using Airways.Application.Models.Order;
using Airways.Application.Models.Aicraft;
using Airways.DataAccess.Repository.Impl;

namespace Airways.Application.Services.Impl
{
    public class OrderService:IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;


        public OrderService(IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponceModel> GetByIdAsync(Guid id)
        {
            var aircraft = await _orderRepository.GetFirstAsync(a => a.Id == id);
            if (aircraft == null) { throw new Exception("Aircraft not found"); }

            return _mapper.Map<OrderResponceModel>(aircraft);
        }

        public async Task<IEnumerable<OrderResponceModel>> GetAllAsync()
        {
            var todoItems = await _orderRepository.GetAllAsync(_ => true);

            return _mapper.Map<IEnumerable<OrderResponceModel>>(todoItems);
        }

        public async Task<CreateOrderResponceModel> CreateAsync(CreateOrderModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Order>(createTodoItemModel);


            return new CreateOrderResponceModel
            {
                Id = (await _orderRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdateOrderResponceModel> UpdateAsync(Guid id, UpdateOrderModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _orderRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateOrderResponceModel
            {
                Id = (await _orderRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var todoItem = await _orderRepository.GetFirstAsync(ti => ti.Id == id);

            if(todoItem == null) return false;

            await _orderRepository.DeleteAsync(todoItem);

            return true;
        }
    }
}
