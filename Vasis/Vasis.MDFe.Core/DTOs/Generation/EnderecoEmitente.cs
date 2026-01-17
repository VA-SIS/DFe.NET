using System.Text.Json.Serialization;

namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class EnderecoEmitente
    {
        [JsonPropertyName("xLgr")]
        public string Logradouro { get; set; }

        [JsonPropertyName("nro")]
        public string Numero { get; set; }

        [JsonPropertyName("xCpl")]
        public string Complemento { get; set; }

        [JsonPropertyName("xBairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("cMun")]
        public int CodigoMunicipio { get; set; }

        [JsonPropertyName("xMun")]
        public string NomeMunicipio { get; set; }

        [JsonPropertyName("CEP")]
        public string CEP { get; set; }

        [JsonPropertyName("UF")]
        public string UF { get; set; }

        [JsonPropertyName("fone")]
        public string Telefone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}