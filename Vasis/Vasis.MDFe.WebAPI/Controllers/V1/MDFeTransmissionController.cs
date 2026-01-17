using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vasis.MDFe.Application.DTOs.Transmission;
using Vasis.MDFe.Application.Services.Transmission;

namespace Vasis.MDFe.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/mdfe/transmission")]
    [Authorize]
    public class MDFeTransmissionController : ControllerBase
    {
        private readonly MDFeTransmissionService _transmissionService;

        public MDFeTransmissionController(MDFeTransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMDFe([FromBody] SendMDFeRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _transmissionService.SendMDFeAsync(request);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("check-status")]
        public async Task<IActionResult> CheckStatus([FromBody] CheckStatusRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _transmissionService.CheckStatusAsync(request);
            return Ok(result);
        }

        [HttpGet("service-status")]
        public async Task<IActionResult> GetServiceStatus()
        {
            var result = await _transmissionService.GetServiceStatusAsync();
            return Ok(result);
        }
    }
}