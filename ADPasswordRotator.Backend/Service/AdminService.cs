using ADPasswordRotator.Backend.Repository;
using ADPasswordRotator.Shared.Model;
using EFRepository;

namespace ADPasswordRotator.Backend.Service
{
    public class AdminService(AdminRepository repository) : EntityServiceBase<AdminRepository, string, Admin>(repository)
    {
    }
}
