using ADPasswordRotator.Shared.Model;

namespace ADPasswordRotator.Backend.Repository
{
    public class NotificationRepository(ADWorker worker) : RepositoryBase<int, Notification>(worker)
    {
    }
}
