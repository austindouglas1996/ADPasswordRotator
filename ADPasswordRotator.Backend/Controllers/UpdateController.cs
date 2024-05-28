using ADPasswordRotator.Backend.Service;
using EFRepository;
using Microsoft.AspNetCore.Mvc;

namespace ADPasswordRotator.Backend.Controllers
{
    [Route("AD/[controller]")]
    [ApiController]
    public class UpdateController(UpdateService update) : ControllerBase
    {
        private readonly UpdateService _updater = update;

        [HttpGet("PerformHeartBeat")]
        public virtual async Task PerformHeartBeat()
        {
            await _updater.PerformHeartBeat();
        }
    }
}
