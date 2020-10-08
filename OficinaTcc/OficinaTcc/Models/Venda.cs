using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Models
{
    public class Venda
    {
        public String id { get; set; }
        public string Cpf{ get; set; }
        public Produto Produto { get; set; }
        public double Valor { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}
