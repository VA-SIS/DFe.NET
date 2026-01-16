using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.Services.Document;

namespace Vasis.MDFe.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class MDFeController : ControllerBase
    {
        private readonly MDFeDocumentService _mdfeService;

        public MDFeController(MDFeDocumentService mdfeService)
        {
            _mdfeService = mdfeService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMDFe([FromBody] CreateMDFeRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _mdfeService.CreateMDFeAsync(request);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateMDFe([FromBody] CreateMDFeRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _mdfeService.ValidateMDFeAsync(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMDFe(int id)
        {
            var result = await _mdfeService.GetMDFeAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMDFe()
        {
            var result = await _mdfeService.GetAllMDFeAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMDFe(int id)
        {
            var result = await _mdfeService.DeleteMDFeAsync(id);

            if (result)
                return NoContent();

            return NotFound();
        }
    }
}