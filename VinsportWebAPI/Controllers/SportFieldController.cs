using Application.IServices;
using Application.ViewModels.SportFieldViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace VinsportWebAPI.Controllers
{
    [Route("odata")]
    public class SportFieldController : ODataController
    {
        private readonly ISportFieldService _sportFieldService;

        public SportFieldController(ISportFieldService sportFieldService)
        {
            _sportFieldService = sportFieldService;
        }

        [EnableQuery]
        [HttpGet("SportFields")]
        public async Task<IActionResult> GetAllSportFields()
        {
            return Ok(await _sportFieldService.GetAllSportFields());
        }

        [HttpPost("SportFields")]
        public async Task<IActionResult> CreateSportField([FromBody] CreateSportFieldDTO createSportFieldDTO)
        {
            bool isCreated = await _sportFieldService.CreateSportFieldAsync(createSportFieldDTO);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("SportFields")]
        public async Task<IActionResult> UpdateSportField([FromBody] UpdateSportFieldDTO updateSportFieldDTO)
        {
            bool isUpdated = await _sportFieldService.UpdateSportFieldAsync(updateSportFieldDTO);
            if (isUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [EnableQuery]
        [HttpGet("SportFields({id})")]
        public async Task<IActionResult> GetSportField([FromRoute] Guid id)
        {
            SportField findSportField = await _sportFieldService.GetSportFieldByIdAsync(id);
            if (findSportField != null)
            {
                return Ok(findSportField);
            }
            return BadRequest();
        }

        [HttpDelete("SportFields({id})")]
        public async Task<IActionResult> DeleteSportField([FromRoute] Guid id)
        {
            try
            {
                if (await _sportFieldService.SoftRemoveSportFieldAsync(id))
                {
                    return Ok("Soft Remove Sport Field successfully");
                }
                else
                {
                    throw new Exception("Saving fail");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Soft Remove Sport Field failed: " + ex.Message);
            }
        }
    }
}
