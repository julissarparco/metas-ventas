using AutoMapper;
using BCP.META.Application.DTO;
using BCP.META.Application.DTO.General;
using BCP.META.Application.Service.Interfaces;
using BCP.META.Crosscuting.Helper;
using BCP.META.Domain.Entities;
using BCP.META.Framework.Logger;
using BCP.META.Infrastructure.Connections;
using BCP.META.Infrastructure.UnitOfWork.Interfaces;
using System.Data.SqlClient;

namespace BCP.META.Application.Service.Classes
{
    public class VentaService : IVentaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VentaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            string connectionString = Connection.GetConnectionString();
            _unitOfWork.ventaRepository.ChangeConnectionString(connectionString);
            _unitOfWork.clienteRepository.ChangeConnectionString(connectionString);
            _unitOfWork.asesorComercialRepository.ChangeConnectionString(connectionString);
            _unitOfWork.productoComercialRepository.ChangeConnectionString(connectionString);
            _unitOfWork.metaMensualRepository.ChangeConnectionString(connectionString);
            _mapper = mapper;
        }

        public Task<ResponseModel<GeneralResponse>> Post(VentaCreateRequest venta)
        {
            const string methodName = "Venta/Post";
            AuditResponse auditResponse = new();
            ResponseModel<GeneralResponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                var validarCliente = _unitOfWork.clienteRepository.GetClienteById(venta.ClienteId);
                if (validarCliente == null)
                {
                    config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.UnexpectedError, string.Empty);
                    response.Entity = new GeneralResponse()
                    {
                        Code = -1,
                        Message = "No se encontro el cliente"
                    };
                    response.AuditResponse = auditResponse;
                    response.IsValid = false;
                    return Task.Run(() => response);
                }

                var validarAsesorComercial = _unitOfWork.asesorComercialRepository.GetAsesorComercialById(venta.AsesorId);
                if (validarAsesorComercial == null)
                {
                    config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.NoData, string.Empty);
                    response.Entity = new GeneralResponse()
                    {
                        Code = -1,
                        Message = "No se encontro el asesor comercial"
                    };
                    response.AuditResponse = auditResponse;
                    response.IsValid = false;
                    return Task.Run(() => response);
                }

                var validarProducto = _unitOfWork.productoComercialRepository.GetProductoComercialById(venta.ProductoId);
                if (validarProducto == null)
                {
                    config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.NoData, string.Empty);
                    response.Entity = new GeneralResponse()
                    {
                        Code = -1,
                        Message = "No se encontro el producto"
                    };
                    response.AuditResponse = auditResponse;
                    response.IsValid = false;
                    return Task.Run(() => response);
                }

                var metaMensual = _unitOfWork.metaMensualRepository.GetMetaMensualByGerenteIdYMes(validarAsesorComercial.GerenteId, venta.PeriodoMes);
              
                var PuntosPorVenta = validarProducto.PuntosPorVenta;
                var TipoPuntos = validarProducto.TipoPuntos;
                var puntosParaCalculo = 0;

                if (decimal.TryParse(PuntosPorVenta, out decimal valorDecimal))
                {
                    if (TipoPuntos.Contains("entero"))
                    {
                        puntosParaCalculo = (int)valorDecimal;
                    } else if (TipoPuntos.Contains("porcentaje")) {
                        puntosParaCalculo = (int)(valorDecimal * venta.MontoPrestamo);
                    }
                }

                Venta oVenta = _mapper.Map<VentaCreateRequest, Venta>(venta);
                oVenta.MetaMensualId = metaMensual.MetaId;
                GeneralResponse res = _unitOfWork.ventaRepository.Post(oVenta);
                response.Entity = res;
                config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.Created, string.Empty);
                response.AuditResponse = auditResponse;
                return Task.Run(() => response);
            }
            catch (SqlException ex)
            {
                Logger.LoggerInstance()
                    .RegisterError(ex, methodName, string.Empty, Environment.MachineName, string.Empty);
                config.GetResponseCode(ref auditResponse, ex.Number, ex.Message);
                response.IsValid = false;
                response.AuditResponse = auditResponse;
                return Task.Run(() => response);
            }
            catch (Exception ex)
            {
                Logger.LoggerInstance()
                    .RegisterError(ex, methodName, string.Empty, Environment.MachineName, string.Empty);
                config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.UnexpectedError,
                    string.Empty);
                response.IsValid = false;
                response.AuditResponse = auditResponse;
                return Task.Run(() => response);
            }
        }
    }
}
