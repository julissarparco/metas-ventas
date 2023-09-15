using AutoMapper;
using BCP.META.Application.DTO;
using BCP.META.Domain.Entities;

namespace BCP.Distributed.Config
{
    /// <summary>
    /// Mapper
    /// </summary>
    public class SimpleMapping : Profile
    {
        /// <summary>
        /// Builder
        /// </summary>
        public SimpleMapping() {
            CreateMap<Agencia, AgenciaResponse>().ReverseMap();
            CreateMap<ProductoComercial, ProductoComercialResponse>().ReverseMap();
            CreateMap<Cliente, ClienteResponse>().ReverseMap();
            CreateMap<Venta, VentaCreateResponse>().ReverseMap();
            CreateMap<VentaCreateRequest, Venta>().ReverseMap();
            CreateMap<AsesorComercialCreateRequest, AsesorComercial>().ReverseMap();
            CreateMap<AsesorComercial, AsesorComercialResponse>().ReverseMap();
        }
    }
}
