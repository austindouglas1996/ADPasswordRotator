using ADPasswordRotator.Backend.Service;
using ADPasswordRotator.Shared;

namespace ADPasswordRotator.Backend.Settings
{
    public class PasswordSettings(SettingsOptionService service) : SettingsBase(service)
    {
        /// <summary>
        /// Grabs the minimum password length.
        /// </summary>
        public async Task<int> GetMinPasswordLengthAsync()
        {
            string result = await base.GetAsync("MinPasswordLength", "20");
            return Int32.Parse(result);
        }

        /// <summary>
        /// Sets the minimum password length.
        /// </summary>
        public async Task SetMinPasswordLengthAsync(int value)
        {
            await base.SetAsync("MinPasswordLength", value.ToString());
        }

        /// <summary>
        /// Grabs the maximum password length.
        /// </summary>
        public async Task<int> GetMaxPasswordLengthAsync()
        {
            string result = await base.GetAsync("MaxPasswordLength", "10");
            return Int32.Parse(result);
        }

        /// <summary>
        /// Sets the maximum password length.
        /// </summary>
        public async Task SetMaxPasswordLengthAsync(int value)
        {
            await base.SetAsync("MaxPasswordLength", value.ToString());
        }

        /// <summary>
        /// Grabs the minimum number of symbols.
        /// </summary>
        public async Task<int> GetMinSymbolsAsync()
        {
            string result = await base.GetAsync("MinSymbols", "10");
            return Int32.Parse(result);
        }

        /// <summary>
        /// Sets the minimum number of symbols.
        /// </summary>
        public async Task SetMinSymbolsAsync(int value)
        {
            await base.SetAsync("MinSymbols", value.ToString());
        }

        /// <summary>
        /// Grabs the maximum number of symbols.
        /// </summary>
        public async Task<int> GetMaxSymbolsAsync()
        {
            string result = await base.GetAsync("MaxSymbols", "20");
            return Int32.Parse(result);
        }

        /// <summary>
        /// Sets the maximum number of symbols.
        /// </summary>
        public async Task SetMaxSymbolsAsync(int value)
        {
            await base.SetAsync("MaxSymbols", value.ToString());
        }

        /// <summary>
        /// Grabs the default password reset time.
        /// </summary>
        public async Task<int> GetDefaultResetTimeAsync()
        {
            string result = await base.GetAsync("DefaultPasswordResetTime", "30");
            return Int32.Parse(result);
        }

        /// <summary>
        /// Sets the default password reset time.
        /// </summary>
        public async Task SetDefaultResetTimeAsync(int value)
        {
            await base.SetAsync("DefaultPasswordResetTime", value.ToString());
        }

        /// <summary>
        /// Grabs the type of the default password reset time interval.
        /// </summary>
        public async Task<IntervalType> GetDefaultResetTimeTypeAsync()
        {
            string result = await base.GetAsync("DefaultPasswordResetTimeType", "Days");
            return (IntervalType)Enum.Parse(typeof(IntervalType), result);
        }

        /// <summary>
        /// Sets the type of the default password reset time interval.
        /// </summary>
        public async Task SetDefaultResetTimeTypeAsync(IntervalType value)
        {
            await base.SetAsync("DefaultPasswordResetTimeType", value.ToString());
        }

        /// <summary>
        /// Grabs the default password reset time for connectors.
        /// </summary>
        public async Task<int> GetDefaultResetTimeForConnectorAsync()
        {
            string result = await base.GetAsync("DefaultPasswordResetTimeConnector", "10");
            return Int32.Parse(result);
        }

        /// <summary>
        /// Sets the default password reset time for connectors.
        /// </summary>
        public async Task SetDefaultResetTimeForConnectorAsync(int value)
        {
            await base.SetAsync("DefaultPasswordResetTimeConnector", value.ToString());
        }

        /// <summary>
        /// Grabs the type of the default password reset time interval for connectors.
        /// </summary>
        public async Task<IntervalType> GetDefaultResetTimeForConnectorTypeAsync()
        {
            string result = await base.GetAsync("DefaultPasswordResetTimeConnectorType", "Hours");
            return (IntervalType)Enum.Parse(typeof(IntervalType), result);
        }

        /// <summary>
        /// Sets the type of the default password reset time interval for connectors.
        /// </summary>
        public async Task SetDefaultResetTimeForConnectorTypeAsync(IntervalType value)
        {
            await base.SetAsync("DefaultPasswordResetTimeConnectorType", value.ToString());
        }
    }
}
