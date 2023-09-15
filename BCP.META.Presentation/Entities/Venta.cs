namespace BCP.META.Presentation.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public int MetaMensualId { get; set; }
        public string PeriodoMes { get; set; }
        public int PeriodoAnio { get; set; }
        public int AsesorId { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public int PuntosObtenidos { get; set; }
        public string FechaVenta { get; set; }
        public decimal MontoDesembolsado { get; set; }
        public decimal MontoPrestamo { get; set; }
        public int RowId { get; set; }
        public string ClienteNombres { get; set; }
        public string ClienteApellidos { get; set; }
        public string AsesorNombres { get; set; }
        public string ProductoNombres { get; set; }
    }
}
