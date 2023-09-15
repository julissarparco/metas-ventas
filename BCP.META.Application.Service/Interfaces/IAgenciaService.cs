using BCP.META.Application.DTO;
using BCP.META.Application.DTO.General;

namespace BCP.META.Application.Service.Interfaces
{
    public interface IAgenciaService
    {
        Task<ResponseModel<AgenciaResponse>> GetAllAgencias();

        Task<ResponseModel<AgenciaResponse>> GetAgenciaById(int id);

    }
}
