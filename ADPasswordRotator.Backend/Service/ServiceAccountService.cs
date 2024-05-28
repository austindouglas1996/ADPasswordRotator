using ADPasswordRotator.Backend.Repository;
using ADPasswordRotator.Shared.Model;
using EFRepository;

namespace ADPasswordRotator.Backend.Service
{
    public class ServiceAccountService(ServiceAccountRepository repo) : EntityServiceBase<ServiceAccountRepository, int, ServiceAccount>(repo)
    {
        public override async Task AddAsync(ServiceAccount entity)
        {
            if (entity.UserName == null)
                throw new ArgumentNullException("Name is required.");

            // Allow for some room.
            if (entity.Location == null && entity.LocationId != -1)
                entity.Location = await base.Repository.Worker.Locations.GetAsync(entity.LocationId);

            if (entity.Location == null)
                throw new ArgumentNullException("Location is required.");

            foreach (ServiceAccount account in entity.Location.Accounts)
            {
                if (account.UserName == entity.UserName)
                    throw new ArgumentException("There is already an account under that name at this location.");
            }

            await base.AddAsync(entity);
        }
    }
}
