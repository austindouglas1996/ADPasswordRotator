using ADPasswordRotator.Backend.Repository;
using ADPasswordRotator.Shared.Model;
using EFRepository;
using Microsoft.EntityFrameworkCore;

namespace ADPasswordRotator.Backend.Service
{
    public class SettingsOptionService(ADWorker worker, SettingsOptionRepository settings) : EntityServiceBase<SettingsOptionRepository, string, SettingsOption>(settings)
    {
        private readonly ADWorker _worker = worker;
        private readonly SettingsOptionRepository _settings = settings;

        public async Task<SettingsOption> GetAsync(string id)
        {
            return await _settings.GetAsync(id);
        }

        public async Task<SettingsOption> GetAsync(string id, string defaultValue)
        {
            SettingsOption option = await _worker.SettingsOptions.GetAsync(id);

            if (option == null)
            {
                return await Set(id, defaultValue);
            }

            return option;
        }

        public async Task<SettingsOption> Set(string propName, string newValue)
        {
            SettingsOption setting = new SettingsOption();
            setting.Id = propName;
            setting.Value = newValue;

            await _settings.AddAsync(setting);
            await _settings.SaveChangesAsync();

            return setting;
        }

        public async Task<bool> Set(string propName, string newValue, bool CreateIfNotExists = true)
        {
            SettingsOption setting = await GetAsync(propName);

            if (setting == null && !CreateIfNotExists)
                return false;

            if (setting == null && CreateIfNotExists)
                return (await Set(propName, newValue) != null);

            setting.Value = newValue;
             _settings.UpdateAsync(setting);

            return true;
        }
    }
}
