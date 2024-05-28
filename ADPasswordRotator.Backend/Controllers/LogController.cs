using ADPasswordRotator.Backend.Service;
using ADPasswordRotator.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace ADPasswordRotator.Backend.Controllers
{
    [Route("AD/[controller]")]
    [ApiController]
    public class LogController(LogService service) : ServiceControllerBase<LogService, int, LogMessage>(service)
    {
    }
}
