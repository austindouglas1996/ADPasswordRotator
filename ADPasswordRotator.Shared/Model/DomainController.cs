using EFRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Shared.Model
{
    public class DomainController : IEntity<int>
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public string HostName { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public ConnectionStatus Status { get; set; }

        public int LocationId { get; set; }
        public virtual Location? Location { get; set; }

        public virtual List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
