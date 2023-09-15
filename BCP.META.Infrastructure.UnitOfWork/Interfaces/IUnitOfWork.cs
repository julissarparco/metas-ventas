using BCP.META.Infrastructure.Repository.Interfaces;

namespace BCP.META.Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IAgenciaRepository agenciaRepository { get; }
        IProductoComercialRepository productoComercialRepository { get; }
        IVentaRepository ventaRepository { get; }
        IClienteRepository clienteRepository { get; }
        IAsesorComercialRepository asesorComercialRepository { get; }
        IMetaMensualRepository metaMensualRepository { get; }
     }
}
