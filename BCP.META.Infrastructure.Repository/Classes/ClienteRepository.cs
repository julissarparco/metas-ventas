using BCP.META.Application.DTO.General;
using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.Repository.Interfaces;
using BCP.META.Infrastructure.UnitOfWork.Repository.Classes;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BCP.META.Infrastructure.Repository.Classes
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            const string sp = "dbo.up_get_all_clientes";
            DynamicParameters parameters = new();
            using SqlConnection connection = new(ConnectionString);
            var lst = connection.Query<Cliente>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return lst;
        }

        public Cliente GetClienteById(int id)
        {
            const string sp = "dbo.up_get_cliente_by_id";
            DynamicParameters parameters = new();
            parameters.Add("@id", id);
            using SqlConnection connection = new(ConnectionString);
            var lst = connection.QueryFirstOrDefault<Cliente>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return lst;
        }

        public GeneralResponse Post(Cliente oCliente)
        {
            const string sp = "dbo.up_crear_cliente";
            DynamicParameters parameters = new();
            parameters.Add("@nombre", oCliente.Nombres);
            parameters.Add("@apellido", oCliente.Apellidos);
            parameters.Add("@tipoDocumento", oCliente.TipoDocumento);
            parameters.Add("@numeroDocumento", oCliente.NumeroDocumento);
            parameters.Add("@numeroCelular", oCliente.NumeroCelular);

            using SqlConnection connection = new(ConnectionString);
            var response = connection.QueryFirstOrDefault<GeneralResponse>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);

            return response;
        }
    }
}
