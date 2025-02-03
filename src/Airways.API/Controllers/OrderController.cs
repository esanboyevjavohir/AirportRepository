using Airways.Application.Models;
using Airways.Application.Models.Airline;
using Airways.Application.Models.Order;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    
    [Route("api/order")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _orderService.GetByIdAsync(id);
                return Ok(ApiResult<OrderResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _orderService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<OrderResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateOrderModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _orderService.CreateAsync(createUserModel);
                return Ok(ApiResult<CreateOrderResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateOrderModel updateUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _orderService.UpdateAsync(id, updateUserModel);
                return Ok(ApiResult<UpdateOrderResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _orderService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(result));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
