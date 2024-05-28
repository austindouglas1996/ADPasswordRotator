using ADPasswordRotator.Backend.Repository;
using ADPasswordRotator.Backend.Service;
using ADPasswordRotator.Shared.Model;
using EFRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADPasswordRotator.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdminController(AdminService service) : ServiceControllerBase<AdminService, string, Admin>(service)
    {
    }
}
