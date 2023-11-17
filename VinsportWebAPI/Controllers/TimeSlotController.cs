using Application.IServices;
using Application.Services;
using Application.ViewModels.TimeSlotViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace VinsportWebAPI.Controllers
{
    [Route("odata")]
    public class TimeSlotController : ODataController
    {
        private readonly ITimeSlotService _timeSlotService;

        public TimeSlotController(ITimeSlotService timeSlotService)
        {
            _timeSlotService = timeSlotService;
        }

        [EnableQuery]
        [HttpGet("TimeSlots")]
        public async Task<IActionResult> GetAllTimeSlots()
        {
            return Ok(await _timeSlotService.GetAllTimeSlots());
        }

        [HttpPost("TimeSlots")]
        public async Task<IActionResult> CreateTimeSlot([FromBody] CreateTimeSlotDTO createTimeSlotDTO)
        {
            bool isCreated = await _timeSlotService.CreateTimeSlotAsync(createTimeSlotDTO);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("TimeSlots")]
        public async Task<IActionResult> UpdateTimeSlot([FromBody] UpdateTimeSlotDTO updateTimeSlotDTO)
        {
            bool isUpdated = await _timeSlotService.UpdateTimeSlotAsync(updateTimeSlotDTO);
            if (isUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [EnableQuery]
        [HttpGet("TimeSlots({id})")]
        public async Task<IActionResult> GetTimeSlot([FromRoute] int id)
        {
            TimeSlot findTimeSlot = await _timeSlotService.GetTimeSlotByIdAsync(id);
            if (findTimeSlot != null)
            {
                return Ok(findTimeSlot);
            }
            return BadRequest();
        }

        [HttpDelete("TimeSlots({id})")]
        public async Task<IActionResult> DeleteTimeSlot([FromRoute] int id)
        {
            try
            {
                if (await _timeSlotService.SoftRemoveTimeSlotAsync(id))
                {
                    return Ok("Soft Remove Time Slot successfully");
                }
                else
                {
                    throw new Exception("Saving fail");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Soft Remove Time Slot failed: " + ex.Message);
            }
        }
    }
}
