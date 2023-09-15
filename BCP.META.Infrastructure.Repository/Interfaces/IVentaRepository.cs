using BCP.META.Application.DTO;
using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.UnitOfWork.Repository.Interfaces;

namespace BCP.META.Infrastructure.Repository.Interfaces
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        VentaCreateResponse Post(Venta venta);
    }
}
