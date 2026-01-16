using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vasis.MDFe.Application.DTOs.Lifecycle;
using Vasis.MDFe.Application.Services.Lifecycle;

namespace Vasis.MDFe.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/mdfe/lifecycle")]
    [Authorize]
    public class MDFeLifecycleController : ControllerBase
    {
        private readonly MDFeLifecycleService _lifecycleService;

        public MDFeLifecycleController(MDFeLifecycleService lifecycleService)
        {
            _lifecycleService = lifecycleService;
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelMDFe([FromBody] CancelMDFeRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _lifecycleService.CancelMDFeAsync(request);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("close")]
        public async Task<IActionResult> CloseMDFe([FromBody] CloseMDFeRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _lifecycleService.CloseMDFeAsync(request);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}