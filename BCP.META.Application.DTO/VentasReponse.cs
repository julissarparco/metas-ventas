namespace BCP.META.Application.DTO
{
    public class VentasReponse
    {
        public int RowId { get; set; }
        public int Id { get; set; }
        public string PeriodoMes { get; set; }
        public string PeriodoAnio { get; set; }
        public string FechaVenta { get; set; }
        public decimal MontoPrestamo { get; set; }
        public decimal MontoDesembolsado { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombres { get; set; }
        public string ClienteApellidos { get; set; }
        public int AsesorId { get; set; }
        public string AsesorNombres { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombres { get; set; }
    }
}
