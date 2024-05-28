using EFRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Shared.Model
{
    public class Admin : IdentityUser, IEntity<string>
    {
    }
}
