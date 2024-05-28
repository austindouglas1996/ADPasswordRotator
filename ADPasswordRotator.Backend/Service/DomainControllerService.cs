using ADPasswordRotator.Backend.Repository;
using ADPasswordRotator.Shared;
using ADPasswordRotator.Shared.Model;
using EFRepository;

namespace ADPasswordRotator.Backend.Service
{
    public class DomainControllerService(DomainControllerRepository repo) : EntityServiceBase<DomainControllerRepository, int, DomainController>(repo)
    {
        public override async Task AddAsync(DomainController entity)
        {
            if (entity.IPAddress == null)
                throw new ArgumentNullException("IP address is required.");

            if (entity.Port < 0 || entity.Port > 65536)
                throw new ArgumentNullException("Port is required.");

            // Allow for some room.
            if (entity.Location == null && entity.LocationId != -1)
                entity.Location = await base.Repository.Worker.Locations.GetAsync(entity.LocationId);

            if (entity.Location == null)
                throw new ArgumentNullException("Location is required.");

            foreach (DomainController c in entity.Location.Controllers)
            {
                if (c.DisplayName == entity.DisplayName)
                    throw new ArgumentException("There is already a controller with this name."); 

                if (c.IPAddress == entity.IPAddress)
                    throw new ArgumentException("There is already a controller with this IP address.");
            }

            await base.AddAsync(entity);
        }

        public async Task<bool> VerifyDC(DomainController dc)
        {
            LDAPConnection connection = new LDAPConnection(dc.HostName, dc.Port.ToString(), dc.UserName, dc.Password);
            return await connection.TryConnectAsync();
        }
    }
}
