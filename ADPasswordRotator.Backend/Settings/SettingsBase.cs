using ADPasswordRotator.Backend.Service;
using ADPasswordRotator.Shared.Model;

namespace ADPasswordRotator.Backend.Settings
{
    public abstract class SettingsBase(SettingsOptionService service)
    {
        protected SettingsOptionService Service = service;

        protected async Task<string> GetAsync(string id)
        {
            SettingsOption option = await Service.GetAsync(id);
            return option.Value;
        }

        protected async Task<string> GetAsync(string id, string defaultValue)
        {
            SettingsOption option = await Service.GetAsync(id, defaultValue);
            return option.Value;
        }

        protected async Task SetAsync(string id, string newValue)
        {
            await Service.Set(id, newValue);
        }
    }
}
