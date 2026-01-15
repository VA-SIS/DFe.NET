using Microsoft.AspNetCore.Mvc;
using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.DTOs.Validation;

namespace Vasis.MDFe.WebAPI.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class MDFeController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMDFeRequest request)
    {
        // RED - Implementação mínima para compilar
        throw new NotImplementedException("MDFeController.Create não implementado - TDD RED");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        // RED - Implementação mínima para compilar
        throw new NotImplementedException("MDFeController.GetById não implementado - TDD RED");
    }

    [HttpPut("{id}/validate")]
    public async Task<IActionResult> Validate(Guid id)
    {
        // RED - Implementação mínima para compilar
        throw new NotImplementedException("MDFeController.Validate não implementado - TDD RED");
    }
}