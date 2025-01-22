using Airways.Application.Models;
using Airways.Application.Models.Airline;
using Airways.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class AirlineController : ApiController
    {
        private readonly IAirlineService _airlineService;

        public AirlineController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var response = await _airlineService.GetByIdAsync(id);
                return Ok(ApiResult<AirlineResponceModel>.Success(response));
            }
            catch(Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResult<List<AirlineResponceModel>>>> GetAll()
        {
            var responce = await _airlineService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<AirlineResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateAirlineModel createUserModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _airlineService.CreateAsync(createUserModel);
                return Ok(ApiResult<CreateAirlineResponceModel>.Success(response));
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateAirlineModel updateUserModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _airlineService.UpdateAsync(id, updateUserModel);
                return Ok(ApiResult<UpdateAirlineResponceModel>.Success(response));
            }
            catch (Exception ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _airlineService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponceModel>.Success(result));
            }
            catch(Exception ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }
    }
}
