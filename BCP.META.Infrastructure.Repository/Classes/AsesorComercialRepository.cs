using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.Repository.Interfaces;
using BCP.META.Infrastructure.UnitOfWork.Repository.Classes;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BCP.META.Infrastructure.Repository.Classes
{
    public class AsesorComercialRepository : GenericRepository<AsesorComercial>, IAsesorComercialRepository
    {
        public AsesorComercialRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<AsesorComercial> GetAllAsesoresComerciales()
        {
            const string sp = "dbo.up_get_all_asesores_comerciales";
            DynamicParameters parameters = new();
            using SqlConnection connection = new(ConnectionString);
            var lst = connection.Query<AsesorComercial>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return lst;
        }

        public AsesorComercial GetAsesorComercialById(int id)
        {
            const string sp = "dbo.up_get_asesor_comercial_by_id";
            DynamicParameters parameters = new();
            parameters.Add("@id", id);
            using SqlConnection connection = new(ConnectionString);
            var obj = connection.QueryFirstOrDefault<AsesorComercial>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return obj;
        }       
    }
}
