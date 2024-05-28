using ADPasswordRotator.Shared.Model;

namespace ADPasswordRotator.Backend.Repository
{
    public class AdminRepository(ADWorker worker) : RepositoryBase<string, Admin>(worker)
    {
    }
}
