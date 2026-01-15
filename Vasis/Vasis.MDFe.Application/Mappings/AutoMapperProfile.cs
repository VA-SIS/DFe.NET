using AutoMapper;
using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Core.Entities.Document;

namespace Vasis.MDFe.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateMDFeRequest -> MDFeDocument
        CreateMap<CreateMDFeRequest, MDFeDocument>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.ChaveAcesso, opt => opt.MapFrom(src => GenerateChaveAcesso()))
            .ForMember(dest => dest.NumeroMDFe, opt => opt.MapFrom(src => GenerateNumeroMDFe()))
            .ForMember(dest => dest.SerieMDFe, opt => opt.MapFrom(src => "1"));

        // MDFeDocument -> MDFeResponse
        CreateMap<MDFeDocument, MDFeResponse>();
    }

    private static string GenerateChaveAcesso()
    {
        // Gerar chave de acesso temporária (depois integrar com Zeus)
        return DateTime.Now.ToString("yyyyMMddHHmmss") + Random.Shared.Next(1000000000, int.MaxValue).ToString();
    }

    private static string GenerateNumeroMDFe()
    {
        // Gerar número sequencial temporário
        return Random.Shared.Next(1, 999999999).ToString("D9");
    }
}