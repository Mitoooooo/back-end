using Application.IServices;
using Application.Services;
using Application.ViewModels.FieldClusterViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace VinsportWebAPI.Controllers
{
    [Route("odata")]
    public class FieldClusterController : ODataController
    {
        private readonly IFieldClusterService _fieldClusterService;

        public FieldClusterController(IFieldClusterService fieldClusterService)
        {
            _fieldClusterService = fieldClusterService;
        }

        [EnableQuery]
        [HttpGet("FieldClusters")]
        public async Task<IActionResult> GetAllFieldClusters()
        {
            return Ok(await _fieldClusterService.GetAllFieldClusters());
        }

        [HttpPost("FieldClusters")]
        public async Task<IActionResult> CreateFieldCluster([FromBody] CreateFieldClusterDTO createFieldClusterDTO)
        {
            bool isCreated = await _fieldClusterService.CreateFieldClusterAsync(createFieldClusterDTO);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("FieldClusters")]
        public async Task<IActionResult> UpdateFieldCluster([FromBody] UpdateFieldClusterDTO updateFieldClusterDTO)
        {
            bool isUpdated = await _fieldClusterService.UpdateFieldClusterAsync(updateFieldClusterDTO);
            if (isUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [EnableQuery]
        [HttpGet("FieldClusters({id})")]
        public async Task<IActionResult> GetFieldCluster([FromRoute] Guid id)
        {
            FieldCluster findFieldCluster = await _fieldClusterService.GetFieldClusterByIdAsync(id);
            if (findFieldCluster != null)
            {
                return Ok(findFieldCluster);
            }
            return BadRequest();
        }

        [HttpDelete("FieldClusters({id})")]
        public async Task<IActionResult> DeleteFieldCluster([FromRoute] Guid id)
        {
            try
            {
                if (await _fieldClusterService.SoftRemoveFieldClusterAsync(id))
                {
                    return Ok("Soft Remove Field Cluster successfully");
                }
                else
                {
                    throw new Exception("Saving fail");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Soft Remove Field Cluster failed: " + ex.Message);
            }
        }
    }
}
