using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vasis.MDFe.Application.DTOs.Generation;
using Vasis.MDFe.Application.Services.Generation;

namespace Vasis.MDFe.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/mdfe/generation")]
    [Authorize]
    public class MDFeGenerationController : ControllerBase
    {
        private readonly MDFeGenerationService _generationService;

        public MDFeGenerationController(MDFeGenerationService generationService)
        {
            _generationService = generationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMDFe([FromBody] CreateMDFeRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _generationService.CreateMDFeAsync(request);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("sign")]
        public async Task<IActionResult> SignMDFe([FromBody] SignMDFeRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _generationService.SignMDFeAsync(request);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}