using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.UnitOfWork.Repository.Interfaces;

namespace BCP.META.Infrastructure.Repository.Interfaces
{
    public interface IProductoComercialRepository : IGenericRepository<ProductoComercial>
    {
        IEnumerable<ProductoComercial> GetAllProductosComerciales();
        ProductoComercial GetProductoComercialById(int id);
    }
}
