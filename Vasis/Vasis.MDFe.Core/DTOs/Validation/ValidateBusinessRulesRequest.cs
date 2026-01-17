namespace Vasis.MDFe.Application.DTOs.Validation
{
    public class ValidateBusinessRulesRequest
    {
        public string XmlContent { get; set; }
        public int TipoAmbiente { get; set; }
        public string UF { get; set; }
    }
}