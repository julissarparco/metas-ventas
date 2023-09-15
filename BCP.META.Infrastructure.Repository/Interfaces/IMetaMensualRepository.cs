using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.UnitOfWork.Repository.Interfaces;

namespace BCP.META.Infrastructure.Repository.Interfaces
{
    public interface IMetaMensualRepository: IGenericRepository<MetaMensual>
    {
        MetaMensual GetMetaMensualByGerenteIdYMes(int gerenteId, string mes);

    }
}
