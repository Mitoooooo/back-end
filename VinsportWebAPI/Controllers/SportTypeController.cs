using Application.IServices;
using Application.ViewModels.SportTypeViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace VinsportWebAPI.Controllers
{
    [Route("odata")]
    public class SportTypeController : ODataController
    {
        private readonly ISportTypeService _sportTypeService;

        public SportTypeController(ISportTypeService sportTypeService)
        {
            _sportTypeService = sportTypeService;
        }

        [EnableQuery]
        [HttpGet("SportTypes")]
        public async Task<IActionResult> GetAllSportTypes()
        {
            return Ok(await _sportTypeService.GetAllSportTypes());
        }

        [HttpPost("SportTypes")]
        public async Task<IActionResult> CreateSportType([FromBody] CreateSportTypeDTO createSportTypeDTO)
        {
            bool isCreated = await _sportTypeService.CreateSportTypeAsync(createSportTypeDTO);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("SportTypes")]
        public async Task<IActionResult> UpdateSportType([FromBody] UpdateSportTypeDTO updateSportTypeDTO)
        {
            bool isUpdated = await _sportTypeService.UpdateSportTypeAsync(updateSportTypeDTO);
            if (isUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [EnableQuery]
        [HttpGet("SportTypes({id})")]
        public async Task<IActionResult> GetSportType([FromRoute] Guid id)
        {
            SportType findSportType = await _sportTypeService.GetSportTypeByIdAsync(id);
            if (findSportType != null)
            {
                return Ok(findSportType);
            }
            return BadRequest();
        }

        [HttpDelete("SportTypes({id})")]
        public async Task<IActionResult> DeleteSportType([FromRoute] Guid id)
        {
            try
            {
                if (await _sportTypeService.SoftRemoveSportTypeAsync(id))
                {
                    return Ok("Soft Remove Sport Type successfully");
                    //return NoContent();
                }
                else
                {
                    throw new Exception("Saving fail");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Soft Remove Sport Type failed: " + ex.Message);
            }
        }
    }
}
