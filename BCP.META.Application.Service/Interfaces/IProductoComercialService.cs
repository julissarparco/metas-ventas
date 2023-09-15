using BCP.META.Application.DTO;
using BCP.META.Application.DTO.General;

namespace BCP.META.Application.Service.Interfaces
{
    public interface IProductoComercialService
    {
        Task<ResponseModel<ProductoComercialResponse>> GetAllProductos();
        Task<ResponseModel<ProductoComercialResponse>> GetProductoById(int id);
    }
}
