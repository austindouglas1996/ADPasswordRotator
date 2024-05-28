using ADPasswordRotator.Backend.Repository;
using ADPasswordRotator.Shared.Model;
using EFRepository;

namespace ADPasswordRotator.Backend.Service
{
    public class LogService(LogRepository repository) : EntityServiceBase<LogRepository, int, LogMessage>(repository)
    {
    }
}
