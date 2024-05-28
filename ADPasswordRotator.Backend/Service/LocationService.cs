using ADPasswordRotator.Backend.Repository;
using ADPasswordRotator.Shared.Model;
using EFRepository;

namespace ADPasswordRotator.Backend.Service
{
    public class LocationService(LocationRepository repo) : EntityServiceBase<LocationRepository, int, Location>(repo)
    {
        public override async Task AddAsync(Location entity)
        {
            if (await this.Repository.LocationExists(entity.Name))
            {
                throw new ArgumentException("A location by this name already exists.");
            }

            await base.AddAsync(entity);
        }
    }
}
