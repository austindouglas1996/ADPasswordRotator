using EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Shared.Model
{
    public class Location : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<DomainController> Controllers { get; set; } = new List<DomainController>();
        public virtual List<ServiceAccount> Accounts { get; set; } = new List<ServiceAccount>();
        public virtual List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
