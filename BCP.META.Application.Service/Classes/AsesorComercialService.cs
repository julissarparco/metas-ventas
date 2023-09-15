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
    public class AsesorComercialService : IAsesorComercialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AsesorComercialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            string connectionString = Connection.GetConnectionString();
            _unitOfWork.asesorComercialRepository.ChangeConnectionString(connectionString);
            _mapper = mapper;
        }

        public Task<ResponseModel<AsesorComercialResponse>> GetAllAsesoresComerciales()
        {
            const string methodName = "AsesorComercial/GetAllAsesoresComerciales";
            AuditResponse auditResponse = new();
            ResponseModel<AsesorComercialResponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                var lst = _unitOfWork.asesorComercialRepository.GetAllAsesoresComerciales();
                var res = _mapper.Map<IEnumerable<AsesorComercial>, IEnumerable<AsesorComercialResponse>>(lst);
                response.EntityList = res;
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

        public Task<ResponseModel<AsesorComercialResponse>> GetAsesorComercialById(int id)
        {
            const string methodName = "AsesorComercial/GetAsesorComercialById";
            AuditResponse auditResponse = new();
            ResponseModel<AsesorComercialResponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                var obj = _unitOfWork.asesorComercialRepository.GetAsesorComercialById(id);
                var entity = _mapper.Map<AsesorComercial, AsesorComercialResponse>(obj);

                if (entity == null)
                {
                    config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.NoData, string.Empty);
                    response.AuditResponse = auditResponse;
                    response.IsValid = false;
                    return Task.Run(() => response);
                }

                response.Entity = entity;
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

        public Task<ResponseModel<GeneralResponse>> Post(AsesorComercialCreateRequest asesorComercial)
        {
            throw new NotImplementedException();
        }
    }
}
