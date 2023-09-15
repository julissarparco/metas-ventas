using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.Repository.Interfaces;
using BCP.META.Infrastructure.UnitOfWork.Repository.Classes;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BCP.META.Infrastructure.Repository.Classes
{
    public class ProductoComercialRepository : GenericRepository<ProductoComercial>, IProductoComercialRepository
    {
        public ProductoComercialRepository(string connectionString) : base(connectionString)
        { 
        }

        public IEnumerable<ProductoComercial> GetAllProductosComerciales()
        {
            const string sp = "dbo.up_get_all_productos";
            DynamicParameters parameters = new();
            using SqlConnection connection = new(ConnectionString);
            var lst = connection.Query<ProductoComercial>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return lst;
        }

        public ProductoComercial GetProductoComercialById(int id)
        {
            const string sp = "dbo.up_get_producto_by_id";
            DynamicParameters parameters = new();
            parameters.Add("@id", id);
            using SqlConnection connection = new(ConnectionString);
            var obj = connection.QueryFirstOrDefault<ProductoComercial>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return obj;
        }
    }
}
