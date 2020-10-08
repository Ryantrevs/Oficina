using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Models
{
    public class Funcionario
    {
        public String Nome { get; set; }
        public String Funcao { get; set; }
        public String Telefone { get; set; }
        public List<Servico> servicos { get; set; }

    }
}
