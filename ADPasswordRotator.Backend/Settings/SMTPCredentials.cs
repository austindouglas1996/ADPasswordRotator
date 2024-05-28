using System.Net.Mail;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ADPasswordRotator.Backend.Settings
{
    public class SMTPCredentials
    {
        public SMTPCredentials()
        {
        }

        [Required]
        public string HostName { get; set; } = "";

        [Required]
        public string Port { get; set; } = "25";

        [Required]
        public string UserName { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
