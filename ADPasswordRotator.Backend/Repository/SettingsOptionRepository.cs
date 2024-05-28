using ADPasswordRotator.Shared.Model;
using EFRepository;

namespace ADPasswordRotator.Backend.Repository
{
    public class SettingsOptionRepository(ADWorker worker) : RepositoryBase<string,SettingsOption>(worker)
    {
    }
}
