using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OficinaTcc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Models.Repository
{
    public interface IFuncionarioRepository
    {
        public Task<IEnumerable<Funcionario>> getUsuarios();
    }
    public class FuncionarioRepository : ContextRepository<Funcionario>, IFuncionarioRepository
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor contextAccessor;
        private readonly UserManager<Funcionario> userManager;
        public FuncionarioRepository(OficinaContext context, IHttpContextAccessor contextAccessor, UserManager<Funcionario> userManager) : base(context)
        {
            this.contextAccessor = contextAccessor;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<Funcionario>> getUsuarios(){
            IEnumerable<Funcionario> resultado = await DbSet.Where(t => t.Id != null).ToListAsync();
            return resultado;
        }
    }
}
