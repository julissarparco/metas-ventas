using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.UnitOfWork.Repository.Interfaces;

namespace BCP.META.Infrastructure.Repository.Interfaces
{
    public interface IAsesorComercialRepository : IGenericRepository<AsesorComercial>
    {
        IEnumerable<AsesorComercial> GetAllAsesoresComerciales();
        AsesorComercial GetAsesorComercialById(int id);
    }
}
