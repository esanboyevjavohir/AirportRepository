using Airways.Application.Models;
using Airways.Application.Models.Airline;
using Airways.Application.Models.Reys;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class ReysContoller : ApiController
    {
        private readonly IReysService _reysService;

        public ReysContoller(IReysService reysService)
        {
            _reysService = reysService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _reysService.GetByIdAsync(id);
                return Ok(ApiResult<ReysResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _reysService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<ReysResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateReysModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _reysService.CreateAsync(createUserModel);
                return Ok(ApiResult<CreateReysResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateReysModel updateUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _reysService.UpdateAsync(id, updateUserModel);
                return Ok(ApiResult<UpdateReysResponceModel>.Success(response));
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
                var result = await _reysService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(result));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
