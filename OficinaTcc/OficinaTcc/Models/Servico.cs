using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Models
{
    public interface IServicoRepository
    {

    }
    public class Servico : IServicoRepository
    {
        public String Id { get; set; }
        public String nome { get; set; }
        public String Responsavel { get; set; }
        public String Descricao { get; set; }
        public List<Funcionario> Colaborador { get; set; }
        public DateTime Data { get; set; }

        private readonly DbContext context;
        public Servico(DbContext context)
        {
            this.context = context;
        }

        public void addServico(String responsavel,String descricao,Funcionario colaborador,DateTime inicio)
        {
            //context.Add
        }
    }
}
