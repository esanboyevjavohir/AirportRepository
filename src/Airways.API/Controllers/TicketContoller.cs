using Airways.Application.Models;
using Airways.Application.Models.Airline;
using Airways.Application.Models.Ticket;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class TicketContoller : ApiController
    {
        private readonly ITicketService _ticketService;

        public TicketContoller(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _ticketService.GetByIdAsync(id);
                return Ok(ApiResult<TicketResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _ticketService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<TicketResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateTicketsModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _ticketService.CreateAsync(createUserModel);
                return Ok(ApiResult<CreateTicketResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateTicketModel updateUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _ticketService.UpdateAsync(id, updateUserModel);
                return Ok(ApiResult<UpdateTicketResponceModel>.Success(response));
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
                var result = await _ticketService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(result));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
