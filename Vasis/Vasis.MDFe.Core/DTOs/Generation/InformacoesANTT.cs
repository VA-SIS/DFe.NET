using System.Text.Json.Serialization;

namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class InformacoesANTT
    {
        [JsonPropertyName("RNTRC")]
        public string RNTRC { get; set; }

        [JsonPropertyName("infCIOT")]
        public List<InformacoesCIOT> InformacoesCIOT { get; set; }

        [JsonPropertyName("valePed")]
        public ValePedagio ValePedagio { get; set; }

        [JsonPropertyName("infContratante")]
        public List<Contratante> Contratantes { get; set; }

        [JsonPropertyName("infPag")]
        public List<InformacoesPagamento> InformacoesPagamento { get; set; }
    }
}