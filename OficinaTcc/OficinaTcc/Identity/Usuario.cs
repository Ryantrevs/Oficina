using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Models
{
    public class Usuario : IdentityUser
    {
        public String Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
