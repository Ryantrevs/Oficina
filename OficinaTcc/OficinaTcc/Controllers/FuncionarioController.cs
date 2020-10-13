using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OficinaTcc.Models;
using OficinaTcc.Models.Repository;

namespace OficinaTcc.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ListaDeUsuario()
        {
            List<Funcionario> funcionarios = (List<Funcionario>)await funcionarioRepository.getUsuarios();
            return View(funcionarios);
        }

    }
}
