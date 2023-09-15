namespace BCP.META.Infrastructure.UnitOfWork.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void ChangeConnectionString(string newConnectionString);
    }
}
