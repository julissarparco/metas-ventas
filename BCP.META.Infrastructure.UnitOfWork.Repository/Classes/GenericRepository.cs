using BCP.META.Infrastructure.UnitOfWork.Repository.Interfaces;
using Dapper.Contrib.Extensions;

namespace BCP.META.Infrastructure.UnitOfWork.Repository.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected string ConnectionString;

        public GenericRepository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => type.Name;
            ConnectionString = connectionString;
        }

        public void ChangeConnectionString(string newConnectionString)
        {
            ConnectionString = newConnectionString;
        }
    }
}