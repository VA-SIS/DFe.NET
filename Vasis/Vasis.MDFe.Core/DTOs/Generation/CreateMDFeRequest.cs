using System.Text.Json.Serialization;

namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class CreateMDFeRequest
    {
        [JsonPropertyName("ide")]
        public IdentificacaoMDFe Identificacao { get; set; }

        [JsonPropertyName("emit")]
        public EmitenteMDFe Emitente { get; set; }

        [JsonPropertyName("infModal")]
        public InformacoesModal InformacoesModal { get; set; }

        [JsonPropertyName("infDoc")]
        public InformacoesDocumentos InformacoesDocumentos { get; set; }

        [JsonPropertyName("seg")]
        public List<SeguroMDFe> Seguros { get; set; }

        [JsonPropertyName("prodPred")]
        public ProdutoPredominante ProdutoPredominante { get; set; }

        [JsonPropertyName("tot")]
        public TotalMDFe Total { get; set; }

        [JsonPropertyName("lacres")]
        public List<LacreMDFe> Lacres { get; set; }

        [JsonPropertyName("autXML")]
        public List<AutorizadoXml> AutorizadosXml { get; set; }

        [JsonPropertyName("infAdic")]
        public InformacoesAdicionais InformacoesAdicionais { get; set; }
    }
}