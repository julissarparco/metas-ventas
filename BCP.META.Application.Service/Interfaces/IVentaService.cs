using BCP.META.Application.DTO;
using BCP.META.Application.DTO.General;

namespace BCP.META.Application.Service.Interfaces
{
    public interface IVentaService
    {
        Task<ResponseModel<VentasReponse>> GetAllVentas();
        Task<ResponseModel<GeneralResponse>> Post(VentaCreateRequest response);
    }
}
