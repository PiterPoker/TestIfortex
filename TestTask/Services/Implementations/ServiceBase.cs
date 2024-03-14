using TestTask.Data;

namespace TestTask.Services.Implementations
{
    public abstract class ServiceBase : IDisposable
    {
        private protected ApplicationDbContext _db;
        public ServiceBase(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            ((IDisposable)_db).Dispose();
        }
    }
}
