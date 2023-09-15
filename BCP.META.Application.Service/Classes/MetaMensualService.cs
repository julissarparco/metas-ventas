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
    public class MetaMensualService : IMetaMensualService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MetaMensualService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            string connectionString = Connection.GetConnectionString();
            _unitOfWork.metaMensualRepository.ChangeConnectionString(connectionString);
            _mapper = mapper;
        }

        public Task<ResponseModel<GeneralResponse>> Post(MetaMensualCreateRequest metaMensual)
        {
            const string methodName = "MetaMensual/Post";
            AuditResponse auditResponse = new();
            ResponseModel<GeneralResponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                MetaMensual oMetaMensual = _mapper.Map<MetaMensualCreateRequest, MetaMensual>(metaMensual);
                GeneralResponse res = _unitOfWork.metaMensualRepository.RegistrarMetaMensual(oMetaMensual);
                response.Entity = res;
                config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.Success, string.Empty);
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
