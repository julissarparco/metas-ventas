namespace BCP.META.Domain.Entities
{
    public class MetaMensual
    {
        public int MetaId { get; set; }
        public int GerenteId { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public decimal Meta { get; set; }
    }
}
