using ADPasswordRotator.Shared.Model;
using EFRepository;

namespace ADPasswordRotator.Backend.Repository
{
    public class DomainControllerRepository(ADWorker worker) : RepositoryBase<int,DomainController>(worker)
    {
       
    }
}
