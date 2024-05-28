using ADPasswordRotator.Backend.Repository;
using EFRepository;

namespace ADPasswordRotator.Backend
{
    public interface IADWorker : IWorker<ADContext>
    {
        public AdminRepository Admins { get; }
        public LocationRepository Locations { get; }
        public DomainControllerRepository DomainControllers { get; }
        public ServiceAccountRepository ServiceAccounts { get; }
        public SettingsOptionRepository SettingsOptions { get; }
        public NotificationRepository Notifications { get; }
        public LogRepository Logs { get; }
    }
}
