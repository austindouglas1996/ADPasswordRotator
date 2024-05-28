using ADPasswordRotator.Backend.Repository;
using EFRepository;
using Microsoft.EntityFrameworkCore;

namespace ADPasswordRotator.Backend
{
    public class ADWorker : IADWorker
    {
        private ADContext _context;

        public ADWorker(ADContext context) 
        { 
            this._context = context;
            this.InitRepo();
        }

        public AdminRepository Admins { get; private set; }

        public LocationRepository Locations { get; private set; }

        public DomainControllerRepository DomainControllers { get; private set; }

        public ServiceAccountRepository ServiceAccounts { get; private set; }

        public SettingsOptionRepository SettingsOptions { get; private set; }

        public NotificationRepository Notifications { get; private set; }

        public LogRepository Logs { get; private set; }

        public ADContext Context => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();

        private void InitRepo()
        {
            this.Admins = new AdminRepository(this);
            this.Locations = new LocationRepository(this);
            this.DomainControllers = new DomainControllerRepository(this);
            this.ServiceAccounts = new ServiceAccountRepository(this);
            this.SettingsOptions = new SettingsOptionRepository(this);
            this.Notifications = new NotificationRepository(this);
            this.Logs = new LogRepository(this);
        }
    }
}
