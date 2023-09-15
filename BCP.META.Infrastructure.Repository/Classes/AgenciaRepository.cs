using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.Repository.Interfaces;
using BCP.META.Infrastructure.UnitOfWork.Repository.Classes;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BCP.META.Infrastructure.Repository.Classes
{
    public class AgenciaRepository : GenericRepository<Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Agencia> GetAllAgencias()
        {
            const string sp = "dbo.up_get_all_agencias";
            DynamicParameters parameters = new();
            using SqlConnection connection = new(ConnectionString);
            var lst = connection.Query<Agencia>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return lst;
        }

        public Agencia GetAgenciaById(int id)
        {
            const string sp = "dbo.up_get_agencia_by_id";
            DynamicParameters parameters = new();
            parameters.Add("@id", id);
            using SqlConnection connection = new(ConnectionString);
            var obj = connection.QueryFirstOrDefault<Agencia>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return obj;
        }
    }
}
