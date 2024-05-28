using EFRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Shared.Model
{
    public class SettingsOption : IEntity<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public bool Internal { get; set; } = false;
    }
}
