using EFRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Shared.Model
{
    public class LogMessage : IEntity<int>
    {
        public int Id { get; set; }

        public LogLevel Level { get; set; }
        public string EventId { get; set; }
        public string LoggerName { get; set; }
        public string State { get; set; }
        public string MessageShort { get; set; }
        public string MessageLong { get; set; }

        public DateTime DateTime { get; set; }
    }
}
