using BCP.META.Application.DTO;
using BCP.META.Application.DTO.General;
using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.UnitOfWork.Repository.Interfaces;

namespace BCP.META.Infrastructure.Repository.Interfaces
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        IEnumerable<Venta> GetAllVentas();
        GeneralResponse Post(Venta venta);

    }
}
