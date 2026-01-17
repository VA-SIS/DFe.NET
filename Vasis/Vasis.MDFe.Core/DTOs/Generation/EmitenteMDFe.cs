using System.Text.Json.Serialization;

namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class EmitenteMDFe
    {
        [JsonPropertyName("CNPJ")]
        public string CNPJ { get; set; }

        [JsonPropertyName("CPF")]
        public string CPF { get; set; }

        [JsonPropertyName("IE")]
        public string InscricaoEstadual { get; set; }

        [JsonPropertyName("xNome")]
        public string RazaoSocial { get; set; }

        [JsonPropertyName("xFant")]
        public string NomeFantasia { get; set; }

        [JsonPropertyName("enderEmit")]
        public EnderecoEmitente Endereco { get; set; }
    }
}