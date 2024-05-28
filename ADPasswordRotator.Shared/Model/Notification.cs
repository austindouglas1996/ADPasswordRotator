using EFRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Shared.Model
{
    public class Notification : IEntity<int>
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime Time { get; set; }

        public int? LocationId { get; set; }
        public virtual Location? Location { get; set; }

        public int? DomainControllerId { get; set; }
        public virtual DomainController? DomainController { get; set;}

        public int? ServiceAccountId { get; set; }
        public virtual ServiceAccount? ServiceAccount { get; set; }
    }
}
