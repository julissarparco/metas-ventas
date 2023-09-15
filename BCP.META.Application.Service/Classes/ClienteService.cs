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
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            string connectionString = Connection.GetConnectionString();
            _unitOfWork.clienteRepository.ChangeConnectionString(connectionString);
            _mapper = mapper;
        }

        public Task<ResponseModel<ClienteReponse>> GetAllClientes()
        {
            const string methodName = "Cliente/GetAllClientes";
            AuditResponse auditResponse = new();
            ResponseModel<ClienteReponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                var lst = _unitOfWork.clienteRepository.GetAllClientes();
                var lstProductsResponse = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteReponse>>(lst);
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

        public Task<ResponseModel<ClienteReponse>> GetClienteById(int id)
        {
            const string methodName = "Cliente/GetClienteById";
            AuditResponse auditResponse = new();
            ResponseModel<ClienteReponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                var obj = _unitOfWork.clienteRepository.GetClienteById(id);
                var cliente = _mapper.Map<Cliente, ClienteReponse>(obj);

                if (cliente == null)
                {
                    config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.NoData, string.Empty);
                    response.AuditResponse = auditResponse;
                    response.IsValid = false;
                    return Task.Run(() => response);
                }


                response.Entity = cliente;
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

        public Task<ResponseModel<GeneralResponse>> Post(ClienteCreateRequest cliente)
        {
            const string methodName = "Cliente/Post";
            AuditResponse auditResponse = new();
            ResponseModel<GeneralResponse> response = new();
            ConfigurationHelper config = new();

            try
            {
                Cliente oCliente = _mapper.Map<ClienteCreateRequest, Cliente>(cliente);
                GeneralResponse res = _unitOfWork.clienteRepository.Post(oCliente);
                response.Entity = res;
                config.GetResponseCode(ref auditResponse, (int)ConfigurationHelper.CodeResponseService.Success,
                    string.Empty);
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
