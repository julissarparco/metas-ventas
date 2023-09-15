using AutoMapper;
using BCP.META.Application.DTO;
using BCP.META.Application.DTO.General;
using BCP.META.Application.Service.Interfaces;
using BCP.META.Crosscuting.Helper;
using BCP.META.Domain.Entities;
using BCP.META.Framework.Logger;
using BCP.META.Infrastructure.Connections;
using BCP.META.Infrastructure.UnitOfWork.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BCP.META.Application.Service.Classes
{
    public class AgenciaService : IAgenciaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgenciaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            string connectionString = Connection.GetConnectionString();
            _unitOfWork.agenciaRepository.ChangeConnectionString(connectionString);
            _mapper = mapper;
        }

        public Task<ResponseModel<AgenciaResponse>> GetAllAgencias()
        {
            const string methodName = "Agencia/GetAllAgencias";
            AuditResponse auditResponse = new();
            ResponseModel<AgenciaResponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                var lst = _unitOfWork.agenciaRepository.GetAllAgencias();
                var res = _mapper.Map<IEnumerable<Agencia>, IEnumerable<AgenciaResponse>>(lst);
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

        public Task<ResponseModel<AgenciaResponse>> GetAgenciaById(int id)
        {
            const string methodName = "Agencia/GetAgenciaById";
            AuditResponse auditResponse = new();
            ResponseModel<AgenciaResponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                var obj = _unitOfWork.agenciaRepository.GetAgenciaById(id);
                var agencia = _mapper.Map<Agencia, AgenciaResponse>(obj);

                if (agencia == null)
                {
                    config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.NoData, string.Empty);
                    response.AuditResponse = auditResponse;
                    response.IsValid = false;
                    return Task.Run(() => response);
                }

                response.Entity = agencia;
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
