using ADPasswordRotator.Shared.Common;
using EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Shared.Model
{
    public class ServiceAccount : IEntity<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public int LocationId { get; set; }
        public virtual Location? Location { get; set; }

        public AccountStatus Status { get; set; }

        public IntervalType PasswordResetIntervalType { get; set; }
        public int PasswordResetIntervalValue { get; set; }
        public DateTime LastPasswordReset { get; set; }

        public virtual List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
