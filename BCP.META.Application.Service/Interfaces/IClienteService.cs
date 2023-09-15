using BCP.META.Application.DTO;
using BCP.META.Application.DTO.General;

namespace BCP.META.Application.Service.Interfaces
{
    public interface IClienteService
    {
        Task<ResponseModel<ClienteResponse>> GetAllClientes();
        Task<ResponseModel<ClienteResponse>> GetClienteById(int id);
        Task<ResponseModel<GeneralResponse>> Post(ClienteCreateRequest cliente);
    }
}
