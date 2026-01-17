using System.Text.Json.Serialization;

namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class IdentificacaoMDFe
    {
        [JsonPropertyName("cUF")]
        public int CodigoUF { get; set; }

        [JsonPropertyName("tpAmb")]
        public int TipoAmbiente { get; set; }

        [JsonPropertyName("tpEmit")]
        public int TipoEmitente { get; set; }

        [JsonPropertyName("tpTransp")]
        public int TipoTransportador { get; set; }

        [JsonPropertyName("mod")]
        public int Modelo { get; set; } = 58;

        [JsonPropertyName("serie")]
        public int Serie { get; set; }

        [JsonPropertyName("nMDF")]
        public int NumeroMDFe { get; set; }

        [JsonPropertyName("cMDF")]
        public string CodigoMDFe { get; set; }

        [JsonPropertyName("cDV")]
        public int DigitoVerificador { get; set; }

        [JsonPropertyName("modal")]
        public int Modal { get; set; }

        [JsonPropertyName("dhEmi")]
        public DateTime DataHoraEmissao { get; set; }

        [JsonPropertyName("tpEmis")]
        public int TipoEmissao { get; set; }

        [JsonPropertyName("procEmi")]
        public int ProcessoEmissao { get; set; }

        [JsonPropertyName("verProc")]
        public string VersaoProcesso { get; set; }

        [JsonPropertyName("UFIni")]
        public string UFInicio { get; set; }

        [JsonPropertyName("UFFim")]
        public string UFFim { get; set; }

        [JsonPropertyName("infMunCarrega")]
        public List<MunicipioCarregamento> MunicipiosCarregamento { get; set; }

        [JsonPropertyName("infPercurso")]
        public List<MunicipioPercurso> MunicipiosPercurso { get; set; }

        [JsonPropertyName("dhIniViagem")]
        public DateTime? DataHoraInicioViagem { get; set; }

        [JsonPropertyName("indCanalVerde")]
        public int? IndicadorCanalVerde { get; set; }

        [JsonPropertyName("indCarregaPosterior")]
        public int? IndicadorCarregaPosterior { get; set; }
    }
}