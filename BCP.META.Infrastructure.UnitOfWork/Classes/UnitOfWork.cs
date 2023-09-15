using BCP.META.Infrastructure.Repository.Classes;
using BCP.META.Infrastructure.Repository.Interfaces;
using BCP.META.Infrastructure.UnitOfWork.Interfaces;
using System.Data;

namespace BCP.META.Infrastructure.UnitOfWork.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        public bool Disposed;

        private IDbConnection _connection;

        #region Repositories
        public IAgenciaRepository agenciaRepository { get; private set; }
        public IProductoComercialRepository productoComercialRepository { get; private set; }
        public IVentaRepository ventaRepository { get; private set; }
        public IClienteRepository clienteRepository { get; private set; }
        public IAsesorComercialRepository asesorComercialRepository { get; private set; }
        public IMetaMensualRepository metaMensualRepository { get; private set; }
        #endregion

        public UnitOfWork(string connectionString)
        {
            agenciaRepository = new AgenciaRepository(connectionString);
            productoComercialRepository = new ProductoComercialRepository(connectionString);
            ventaRepository = new VentaRepository(connectionString);
            clienteRepository = new ClienteRepository(connectionString);
            asesorComercialRepository = new AsesorComercialRepository(connectionString);
            metaMensualRepository = new MetaMensualRepository(connectionString);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
            Disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
