using BCP.META.Application.DTO;
using BCP.META.Application.DTO.General;

namespace BCP.META.Application.Service.Interfaces
{
    public interface IMetaMensualService
    {
        Task<ResponseModel<GeneralResponse>> Post(MetaMensualCreateRequest response);
    }
}
