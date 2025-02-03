using Airways.Application.Models;
using Airways.Application.Models.Aicraft;
using Airways.Application.Services;
using Airways.Application.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.IsisMtt.X509;

namespace Airways.API.Controllers
{

    public class AircraftController : ApiController
    {
        private readonly IAircraftService _aicraftService;

        public AircraftController(IAircraftService aircraftService)
        {
            _aicraftService = aircraftService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var responce = await _aicraftService.GetByIdAsync(id);
                return Ok(ApiResult<AicraftResponceModel>.Success(responce));
            }
            catch(Exception ex) 
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResult<List<AicraftResponceModel>>>> GetAll()
        {
            var responce = await _aicraftService.GetAllAsync();
            return Ok(ApiResult<IEnumerable<AicraftResponceModel>>.Success(responce));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(CreateAircraftModel createUserModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var responce = await _aicraftService.CreateAsync(createUserModel);
                return Ok(ApiResult<CreateAicraftResponceModel>.Success(responce));
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateAicraftModel updateUserModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var responce = await _aicraftService.UpdateAsync(id, updateUserModel);
                return Ok(ApiResult<UpdateAicraftResponceModel>.Success(responce));
            }
            catch(Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _aicraftService.DeleteAsync(id);
                return Ok(ApiResult<bool>.Success(result));
            }
            catch (Exception ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }
    }
}
