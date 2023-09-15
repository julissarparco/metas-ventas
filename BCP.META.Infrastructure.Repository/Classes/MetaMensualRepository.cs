using BCP.META.Application.DTO.General;
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

        public GeneralResponse RegistrarMetaMensual(MetaMensual metaMensual)
        {
            const string sp = "dbo.up_registrar_meta_mensual";
            DynamicParameters parameters = new();
            parameters.Add("@GerenteId", metaMensual.GerenteId);
            parameters.Add("@Mes", metaMensual.Mes);
            parameters.Add("@Anio", metaMensual.Anio);
            parameters.Add("@Meta", metaMensual.Meta);
                
            using SqlConnection connection = new(ConnectionString);
            GeneralResponse obj = connection.QueryFirstOrDefault<GeneralResponse>(sp,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure,
                commandTimeout: 5000);
            return obj;
        }
    }
}
