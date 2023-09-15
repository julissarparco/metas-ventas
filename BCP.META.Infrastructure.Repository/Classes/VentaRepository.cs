using BCP.META.Application.DTO;
using BCP.META.Domain.Entities;
using BCP.META.Infrastructure.Repository.Interfaces;
using BCP.META.Infrastructure.UnitOfWork.Repository.Classes;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using BCP.META.Application.DTO.General;

namespace BCP.META.Infrastructure.Repository.Classes
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        public VentaRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Venta> GetAllVentas()
        {
            const string sp = "dbo.up_get_all_ventas";
            using SqlConnection connection = new(ConnectionString);
            var lst = connection.Query<Venta>(sp,
                 commandType: CommandType.StoredProcedure,
                 commandTimeout: 5000);
            return lst;
        }

        public GeneralResponse Post(Venta venta)
        {
            const string sp = "dbo.up_registrar_venta";
            DynamicParameters parameters = new();
            parameters.Add("@ClienteId", venta.ClienteId);
            parameters.Add("@AsesorId", venta.AsesorId);
            parameters.Add("@ProductoId", venta.ProductoId);
            parameters.Add("@MontoPrestamo", venta.MontoPrestamo);
            parameters.Add("@MontoDesembolsado", venta.MontoDesembolsado);
            parameters.Add("@FechaVenta", venta.FechaVenta);
            parameters.Add("@MetaMensualId", venta.MetaMensualId);
            parameters.Add("@PuntosObtenidos", venta.PuntosObtenidos);
            parameters.Add("@PeriodoMes", venta.PeriodoMes);
            parameters.Add("@PeriodoAnio", venta.PeriodoAnio);
           
            using SqlConnection connection = new(ConnectionString);
            GeneralResponse obj = connection.QueryFirstOrDefault<GeneralResponse>(sp,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 5000);
            return obj;
        }
    }
}
