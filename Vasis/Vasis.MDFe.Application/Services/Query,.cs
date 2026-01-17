using AutoMapper;
using Microsoft.Extensions.Logging;
using Vasis.MDFe.Application.DTOs.Query;
using Vasis.MDFe.Core.Interfaces.External;
using Vasis.MDFe.Core.Interfaces.Repositories;

namespace Vasis.MDFe.Application.Services.Query
{
    public class MDFeQueryService
    {
        private readonly IMDFeRepository _repository;
        private readonly IZeusMDFeWrapper _zeusWrapper;
        private readonly IMapper _mapper;
        private readonly ILogger<MDFeQueryService> _logger;

        public MDFeQueryService(
            IMDFeRepository repository,
            IZeusMDFeWrapper zeusWrapper,
            IMapper mapper,
            ILogger<MDFeQueryService> logger)
        {
            _repository = repository;
            _zeusWrapper = zeusWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<QueryMDFeResponse> GetByKeyAsync(string chaveAcesso)
        {
            try
            {
                var document = await _repository.GetByChaveAcessoAsync(chaveAcesso);

                if (document != null)
                {
                    return _mapper.Map<QueryMDFeResponse>(document);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar MDFe por chave");
                return null;
            }
        }

        public async Task<ConsultMDFeResponse> ConsultMDFeAsync(ConsultMDFeRequest request)
        {
            try
            {
                var result = await _zeusWrapper.ConsultMDFeAsync(request);

                return new ConsultMDFeResponse
                {
                    ChaveAcesso = result.ChaveAcesso,
                    Status = result.Status,
                    XmlRetorno = result.XmlRetorno,
                    Message = result.Message
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar MDFe");
                return new ConsultMDFeResponse
                {
                    Message = ex.Message
                };
            }
        }
    }
}