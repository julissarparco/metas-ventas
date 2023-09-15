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
    public class ProductoComercialService : IProductoComercialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoComercialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            string connectionString = Connection.GetConnectionString();
            _unitOfWork.productoComercialRepository.ChangeConnectionString(connectionString);
            _mapper = mapper;
        }

        public Task<ResponseModel<ProductoComercialResponse>> GetAllProductos()
        {
            const string methodName = "ProductoComercial/GetAllProductos";
            AuditResponse auditResponse = new();
            ResponseModel<ProductoComercialResponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                var lst = _unitOfWork.productoComercialRepository.GetAllProductosComerciales();
                var lstProductsResponse = _mapper.Map<IEnumerable<ProductoComercial>, IEnumerable<ProductoComercialResponse>>(lst);
                response.EntityList = lstProductsResponse;
                config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.Success, string.Empty);
                response.AuditResponse = auditResponse;
                return Task.Run(() => response);
            }
            catch (SqlException ex)
            {
                Logger.LoggerInstance().RegisterError(ex, methodName, string.Empty, Environment.MachineName, string.Empty);
                config.GetResponseCode(ref auditResponse, ex.Number, ex.Message);
                response.IsValid = false;
                response.AuditResponse = auditResponse;
                return Task.Run(() => response);
            }
            catch (Exception ex)
            {
                Logger.LoggerInstance().RegisterError(ex, methodName, string.Empty, Environment.MachineName, string.Empty);
                config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.UnexpectedError, string.Empty);
                response.IsValid = false;
                response.AuditResponse = auditResponse;
                return Task.Run(() => response);
            }
        }

        public Task<ResponseModel<ProductoComercialResponse>> GetProductoById(int id)
        {
            const string methodName = "ProductoComercial/GetProductoById";
            AuditResponse auditResponse = new();
            ResponseModel<ProductoComercialResponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                var obj = _unitOfWork.productoComercialRepository.GetProductoComercialById(id);
                var producto = _mapper.Map<ProductoComercial, ProductoComercialResponse>(obj);
                if (producto == null)
                {
                    config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.NoData, string.Empty);
                    response.AuditResponse = auditResponse;
                    response.IsValid = false;
                    return Task.Run(() => response);
                }
                response.Entity = producto;
                config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.Success, string.Empty);
                response.AuditResponse = auditResponse;
                return Task.Run(() => response);
            }
            catch (SqlException ex)
            {
                Logger.LoggerInstance().RegisterError(ex, methodName, string.Empty, Environment.MachineName, string.Empty);
                config.GetResponseCode(ref auditResponse, ex.Number, ex.Message);
                response.IsValid = false;
                response.AuditResponse = auditResponse;
                return Task.Run(() => response);
            }
            catch (Exception ex)
            {
                Logger.LoggerInstance().RegisterError(ex, methodName, string.Empty, Environment.MachineName, string.Empty);
                config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.UnexpectedError, string.Empty);
                response.IsValid = false;
                response.AuditResponse = auditResponse;
                return Task.Run(() => response);
            }
        }
    }
}
