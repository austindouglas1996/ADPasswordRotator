using ADPasswordRotator.Backend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Backend.Settings
{
    /// <summary>
    /// Retrieves or sets the values for the mail settings for the app.
    /// </summary>
    public class MailSettings(SettingsOptionService settingsOptionService) : SettingsBase(settingsOptionService)
    {
        /// <summary>
        /// Grabs the hostname for the SMTP server asynchronously.
        /// </summary>
        public async Task<string> GetSMTPHostAsync()
        {
            return await base.GetAsync("SMTPHost");
        }

        /// <summary>
        /// Sets the hostname for the SMTP server asynchronously.
        /// </summary>
        public async Task SetSMTPHostAsync(string value)
        {
            await base.SetAsync("SMTPHost", value);
        }

        /// <summary>
        /// Grabs the username of the SMTP server to use for authentication.
        /// </summary>
        public async Task<string> GetSMTPUsernameAsync()
        {
            return await base.GetAsync("SMTPName");
        }

        /// <summary>
        /// Sets the username of the SMTP server to use for authentication.
        /// </summary>
        public async Task SetSMTPUsernameAsync(string value)
        {
            await base.SetAsync("SMTPName", value);
        }

        /// <summary>
        /// Grabs the password of the SMTP server to use for authentication.
        /// </summary>
        public async Task<string> GetSMTPPasswordAsync()
        {
            return await base.GetAsync("SMTPPassword");
        }

        /// <summary>
        /// Sets the password of the SMTP server to use for authentication.
        /// </summary>
        public async Task SetSMTPPasswordAsync(string value)
        {
            await base.SetAsync("SMTPPassword", value);
        }

        /// <summary>
        /// Grabs the port for the SMTP server.
        /// </summary>
        public async Task<string> GetSMTPPortAsync()
        {
            return await base.GetAsync("SMTPPort", "25");
        }

        /// <summary>
        /// Sets the port for the SMTP server.
        /// </summary>
        public async Task SetSMTPPortAsync(string value)
        {
            await base.SetAsync("SMTPPort", value);
        }

        /// <summary>
        /// Grabs the value for the from address.
        /// </summary>
        public async Task<string> GetSMTPFromAsync()
        {
            return await base.GetAsync("SMTPFrom", "support@someEmail.com");
        }

        /// <summary>
        /// Sets the value for the from address.
        /// </summary>
        public async Task SetSMTPFromAsync(string value)
        {
            await base.SetAsync("SMTPFrom", value);
        }
        /// <summary>
        /// Create an instance of <see cref="SMTPCredentials"/> with the provided setting values.
        /// </summary>
        /// <returns></returns>
        public async Task<SMTPCredentials> CreateCredentials()
        {
            var credentials = new SMTPCredentials();
            credentials.HostName = await GetSMTPHostAsync();
            credentials.Port = await GetSMTPPortAsync();
            credentials.UserName = await GetSMTPUsernameAsync();
            credentials.Password = await GetSMTPPasswordAsync();
            return credentials;
        }

        /// <summary>
        /// Set the saved credentials with the provided values.
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> SetCredentials(SMTPCredentials credentials)
        {
            if (credentials == null) throw new ArgumentNullException("credentials");

            await SetSMTPHostAsync(credentials.HostName);
            await SetSMTPPortAsync(credentials.Port);
            await SetSMTPUsernameAsync(credentials.UserName);
            await SetSMTPPasswordAsync(credentials.Password);

            return true;
        }
    }
}
