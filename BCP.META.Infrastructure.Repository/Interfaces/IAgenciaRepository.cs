using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.UnitOfWork.Repository.Interfaces;

namespace BCP.META.Infrastructure.Repository.Interfaces
{
    public interface IAgenciaRepository : IGenericRepository<Agencia>
    {
        IEnumerable<Agencia> GetAllAgencias();

        Agencia GetAgenciaById(int id);
    }
}
