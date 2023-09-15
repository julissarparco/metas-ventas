using BCP.META.Application.DTO;
using BCP.META.Application.DTO.General;

namespace BCP.META.Application.Service.Interfaces
{
    public interface IAsesorComercialService
    {
        Task<ResponseModel<AsesorComercialResponse>> GetAllAsesoresComerciales();

        Task<ResponseModel<AsesorComercialResponse>> GetAsesorComercialById(int id);

        Task<ResponseModel<GeneralResponse>> Post(AsesorComercialCreateRequest asesorComercial);
    }
}
