using System.Text.Json.Serialization;

namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class ModalRodoviario
    {
        [JsonPropertyName("infANTT")]
        public InformacoesANTT InformacoesANTT { get; set; }

        [JsonPropertyName("veicTracao")]
        public VeiculoTracao VeiculoTracao { get; set; }

        [JsonPropertyName("veicReboque")]
        public List<VeiculoReboque> VeiculosReboque { get; set; }

        [JsonPropertyName("codAgPorto")]
        public string CodigoAgenciaPorto { get; set; }

        [JsonPropertyName("lacRodo")]
        public List<LacreRodoviario> LacresRodoviarios { get; set; }
    }
}