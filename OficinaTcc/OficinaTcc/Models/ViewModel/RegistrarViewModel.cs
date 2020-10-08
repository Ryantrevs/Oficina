using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Models.ViewModel
{
    public class RegistrarViewModel
    {
        public String UserName { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public DateTime Nascimento { get; set; }
        public String Senha { get; set; }
    }
}
