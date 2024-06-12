using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univ.Core.Entities
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
