using System.Text.Json.Serialization;

namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class InformacoesModal
    {
        [JsonPropertyName("versaoModal")]
        public string VersaoModal { get; set; }

        [JsonPropertyName("rodo")]
        public ModalRodoviario Rodoviario { get; set; }

        [JsonPropertyName("aereo")]
        public ModalAereo Aereo { get; set; }

        [JsonPropertyName("aquav")]
        public ModalAquaviario Aquaviario { get; set; }

        [JsonPropertyName("ferrov")]
        public ModalFerroviario Ferroviario { get; set; }
    }
}