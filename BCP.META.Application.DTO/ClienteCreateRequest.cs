using BCP.Distributed.CustomAnnotations;
using System.ComponentModel.DataAnnotations;

namespace BCP.META.Application.DTO
{
    public class ClienteCreateRequest
    {
        [Required]
        [AllowedValues("DNI", "RUC", "Pasaporte", "Carnet de Extranjería", "Otro")]
        public string TipoDocumento { get; set; }
        [Required]
        [MinLength(3)]
        public string NumeroDocumento { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Nombres { get; set; }
        public string NumeroCelular { get; set; }
    }
}
