using ADPasswordRotator.Backend.Service;
using ADPasswordRotator.Shared.Model;

namespace ADPasswordRotator.Backend.Controllers
{
    public class SettingsOptionController(SettingsOptionService service) : ServiceControllerBase<SettingsOptionService, string, SettingsOption>(service)
    {
    }
}
