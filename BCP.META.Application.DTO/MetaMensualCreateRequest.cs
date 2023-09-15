using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BCP.META.Application.DTO
{
    public class MetaMensualCreateRequest
    {
        [JsonPropertyName("gerenteId")]
        [Required]
        public int GerenteId { get; set; }
        [JsonPropertyName("mes")]
        [Required]
        public int Mes { get; set; }
        [JsonPropertyName("año")]
        [Required]
        public int Anio { get; set; }
        [JsonPropertyName("meta")]
        [Required]
        public decimal Meta { get; set; }
    }
}
