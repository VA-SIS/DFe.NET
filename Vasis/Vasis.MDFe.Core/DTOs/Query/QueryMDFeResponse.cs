namespace Vasis.MDFe.Application.DTOs.Query
{
    public class QueryMDFeResponse
    {
        public int Id { get; set; }
        public string ChaveAcesso { get; set; }
        public string Status { get; set; }
        public string XmlContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}