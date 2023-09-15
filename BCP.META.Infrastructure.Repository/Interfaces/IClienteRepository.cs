using BCP.META.Application.DTO.General;
using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.UnitOfWork.Repository.Interfaces;

namespace BCP.META.Infrastructure.Repository.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int id);
        GeneralResponse Post(Cliente oCliente);
    }
}
