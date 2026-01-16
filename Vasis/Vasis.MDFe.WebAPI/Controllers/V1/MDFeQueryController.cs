using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vasis.MDFe.Application.DTOs.Query;
using Vasis.MDFe.Application.Services.Query;

namespace Vasis.MDFe.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/mdfe/query")]
    [Authorize]
    public class MDFeQueryController : ControllerBase
    {
        private readonly MDFeQueryService _queryService;

        public MDFeQueryController(MDFeQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet("by-key/{chaveAcesso}")]
        public async Task<IActionResult> GetByKey(string chaveAcesso)
        {
            if (string.IsNullOrEmpty(chaveAcesso))
                return BadRequest("Chave de acesso inválida");

            var result = await _queryService.GetByKeyAsync(chaveAcesso);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost("consultation")]
        public async Task<IActionResult> ConsultMDFe([FromBody] ConsultMDFeRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _queryService.ConsultMDFeAsync(request);
            return Ok(result);
        }
    }
}