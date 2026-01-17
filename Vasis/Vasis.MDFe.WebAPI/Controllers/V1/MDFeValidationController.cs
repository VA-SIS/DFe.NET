using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Application.Services.Validation;

namespace Vasis.MDFe.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/mdfe/validation")]
    [Authorize]
    public class MDFeValidationController : ControllerBase
    {
        private readonly MDFeValidationService _validationService;

        public MDFeValidationController(MDFeValidationService validationService)
        {
            _validationService = validationService;
        }

        [HttpPost("validate-xml")]
        public async Task<IActionResult> ValidateXml([FromBody] ValidateXmlRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _validationService.ValidateXmlAsync(request);
            return Ok(result);
        }

        [HttpPost("validate-business-rules")]
        public async Task<IActionResult> ValidateBusinessRules([FromBody] ValidateBusinessRulesRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _validationService.ValidateBusinessRulesAsync(request);
            return Ok(result);
        }
    }
}