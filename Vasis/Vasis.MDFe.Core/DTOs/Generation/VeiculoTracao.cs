using System.Text.Json.Serialization;

namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class VeiculoTracao
    {
        [JsonPropertyName("cInt")]
        public string CodigoInterno { get; set; }

        [JsonPropertyName("placa")]
        public string Placa { get; set; }

        [JsonPropertyName("RENAVAM")]
        public string RENAVAM { get; set; }

        [JsonPropertyName("tara")]
        public int Tara { get; set; }

        [JsonPropertyName("capKG")]
        public int CapacidadeKG { get; set; }

        [JsonPropertyName("capM3")]
        public int CapacidadeM3 { get; set; }

        [JsonPropertyName("prop")]
        public ProprietarioVeiculo Proprietario { get; set; }

        [JsonPropertyName("condutor")]
        public List<CondutorVeiculo> Condutores { get; set; }

        [JsonPropertyName("tpRod")]
        public int TipoRodado { get; set; }

        [JsonPropertyName("tpCar")]
        public int TipoCarroceria { get; set; }

        [JsonPropertyName("UF")]
        public string UF { get; set; }
    }
}