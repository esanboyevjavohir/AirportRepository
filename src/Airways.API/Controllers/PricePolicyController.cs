using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Airline;
using Airways.Application.Models.PricePolycy;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class PricePolicyController : ApiController
    {
        private readonly IPricePolicyService _pricepolicyService;

        public PricePolicyController(IPricePolicyService pricepolicyService)
        {
            _pricepolicyService = pricepolicyService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _pricepolicyService.GetByIdAsync(id);
                return Ok(ApiResult<PricePolicyResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _pricepolicyService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<PricePolicyResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreatePricePolicyModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _pricepolicyService.CreateAsync(createUserModel);
                return Ok(ApiResult<CreatePricePolicyResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdatePricePolicyModel updateUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _pricepolicyService.UpdateAsync(id, updateUserModel);
                return Ok(ApiResult<UpdatePricePolicyResponceModel>.Success(response));
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
                var result = await _pricepolicyService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(result));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
