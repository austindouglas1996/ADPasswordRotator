using ADPasswordRotator.Shared.Model;
using EFRepository;
using Microsoft.CodeAnalysis;

namespace ADPasswordRotator.Backend.Repository
{
    public class LocationRepository(ADWorker worker) : RepositoryBase<int,Location>(worker)
    {
        public virtual async Task<bool> LocationExists(string name)
        {
            var loc = await base.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            return loc != null;
        }
    }
}
