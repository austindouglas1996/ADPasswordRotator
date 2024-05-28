using ADPasswordRotator.Shared.Model;

namespace ADPasswordRotator.Backend.Repository
{
    public class LogRepository(ADWorker worker) : RepositoryBase<int, LogMessage>(worker)
    {
    }
}
