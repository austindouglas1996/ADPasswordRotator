using ADPasswordRotator.Backend.Repository;
using ADPasswordRotator.Shared.Model;
using EFRepository;

namespace ADPasswordRotator.Backend.Service
{
    public class NotificationService(NotificationRepository repository) : EntityServiceBase<NotificationRepository, int, Notification>(repository)
    {
    }
}
