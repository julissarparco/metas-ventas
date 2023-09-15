using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.Repository.Interfaces;
using BCP.META.Infrastructure.UnitOfWork.Repository.Classes;
using Dapper;
using System.Data.SqlClient;

namespace BCP.META.Infrastructure.Repository.Classes
{
    public class MetaMensualRepository : GenericRepository<MetaMensual>, IMetaMensualRepository
    {
        public MetaMensualRepository(string connectionString) : base(connectionString)
        {
        }

        public MetaMensual GetMetaMensualByGerenteIdYMes(int gerenteId, string mes)
        {
            const string sp = "dbo.up_get_meta_mensual_by_gerente_mes";
            DynamicParameters parameters = new();
            parameters.Add("@gerenteId", gerenteId);
            parameters.Add("@mes", mes);
            using SqlConnection connection = new(ConnectionString);
            var obj = connection.QueryFirstOrDefault<MetaMensual>(sp,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure,
                commandTimeout: 5000);
            return obj;
        }
    }
}
