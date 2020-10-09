using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Models
{
    public class Funcionario : IdentityUser
    {
        public String Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public String Funcao { get; set; }
        public List<Servico> servicos { get; set; }

    }
}
