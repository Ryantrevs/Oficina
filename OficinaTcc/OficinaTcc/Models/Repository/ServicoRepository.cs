using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OficinaTcc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Models.Repository
{
    public interface IServicoRepository
    {

    }
    public class ServicoRepository : ContextRepository<Servico>, IServicoRepository
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor contextAccessor;
        public ServicoRepository(OficinaContext context, IHttpContextAccessor contextAccessor):base(context)
        {
            this.contextAccessor = contextAccessor;
        }
        public async Task SalvarServico(Servico servico)
        {
            var resultado = await DbSet.AddAsync(servico);
        }


        public async Task<IEnumerable<Servico>> getServicos()
        {
            IEnumerable<Servico> resultado = await DbSet.Where(t => t.Id != null).ToListAsync();
            return resultado;
        }

        public void RemoveServico(Servico servico)
        {
            DbSet.Remove(servico);
        }

        public void UpdateServico(Servico servico)
        {
            DbSet.Update(servico);
        }
    }
}
