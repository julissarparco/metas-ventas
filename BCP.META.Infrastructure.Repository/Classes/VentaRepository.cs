using BCP.META.Application.DTO;
using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.Repository.Interfaces;
using BCP.META.Infrastructure.UnitOfWork.Repository.Classes;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace BCP.META.Infrastructure.Repository.Classes
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        public VentaRepository(string connectionString) : base(connectionString)
        {
        }

        public VentaCreateResponse Post(Venta venta)
        {
            const string sp = "";
            DynamicParameters parameters = new();
            //parameters.Add("@Nombre", venta.Name);
            using SqlConnection connection = new(ConnectionString);
            VentaCreateResponse obj = connection.QueryFirstOrDefault<VentaCreateResponse>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return obj;
        }
    }
}
