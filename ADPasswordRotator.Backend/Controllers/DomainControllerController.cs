using ADPasswordRotator.Backend.Service;
using ADPasswordRotator.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace ADPasswordRotator.Backend.Controllers
{
    [Route("AD/[controller]")]
    [ApiController]
    public class DomainControllerController(DomainControllerService service) : ServiceControllerBase<DomainControllerService, int, DomainController>(service)
    {
        [HttpPost("Verify/{id}")]
        public async Task<ActionResult> VerifyDC(int id)
        {
            DomainController dc = await base._service.GetAsync(id);
            bool result = await base._service.VerifyDC(dc);

            return Ok();
        }
    }
}
