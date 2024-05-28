using ADPasswordRotator.Shared.Model;
using EFRepository;

namespace ADPasswordRotator.Backend.Repository
{
    public class ServiceAccountRepository(ADWorker worker) : RepositoryBase<int,ServiceAccount>(worker)
    {
    }
}
