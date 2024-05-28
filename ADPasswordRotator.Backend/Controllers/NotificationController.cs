using ADPasswordRotator.Backend.Service;
using ADPasswordRotator.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace ADPasswordRotator.Backend.Controllers
{
    [Route("AD/[controller]")]
    [ApiController]
    public class NotificationController(NotificationService service) : ServiceControllerBase<NotificationService, int, Notification>(service)
    {
    }
}
