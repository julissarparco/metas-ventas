﻿namespace BCP.META.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string NumeroCelular { get; set; }
    }
}
