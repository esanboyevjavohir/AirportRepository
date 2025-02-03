using Airways.Application.Models;
using Airways.Application.Models.Airline;
using Airways.Application.Models.Review;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class ReviewContoller : ApiController
    {
        private readonly IReviewservice _reviewService;

        public ReviewContoller(IReviewservice reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _reviewService.GetByIdAsync(id);
                return Ok(ApiResult<ReviewResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _reviewService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<ReviewResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateReviewModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _reviewService.CreateAsync(createUserModel);
                return Ok(ApiResult<CreateReviewResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateReviewModel updateUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _reviewService.UpdateAsync(id, updateUserModel);
                return Ok(ApiResult<UpdateReviewResponceModel>.Success(response));
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
                var result = await _reviewService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(result));
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
