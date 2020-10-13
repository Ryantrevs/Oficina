using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OficinaTcc.Models;
using OficinaTcc.Models.ViewModel;

namespace OficinaTcc.Controllers
{
    public class ContaController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Funcionario> userManager;
        private readonly IUserClaimsPrincipalFactory<Funcionario> userClaimsPrincipalFactory;
        private readonly SignInManager<Funcionario> signInManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager;
        public ContaController(Microsoft.AspNetCore.Identity.UserManager<Funcionario> userManager, IUserClaimsPrincipalFactory<Funcionario> userClaimsPrincipalFactory,
            SignInManager<Funcionario> signInManager, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, model.Senha, false);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, true);
                        return RedirectToAction("ListaDeUsuario", "Funcionario");//REDIRECIONAR PRA ONDE?
                    }
                    ModelState.AddModelError("", "Senha Inválida");
                    return View();
                }
                ModelState.AddModelError("", "usuário não existe");
                return View();
            }
            return View();
        }
        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            var email = await userManager.FindByEmailAsync(model.Email);
            if (user == null && email == null)
            {
                user = new Funcionario()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    Email = model.Email,
                    Funcao = "Funcionario",
                    Nome = model.Nome,
                    Nascimento = model.Nascimento,
                    PhoneNumber = model.Telefone
                };
                var result = await userManager.CreateAsync(user, model.Senha);
                if (result.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync("Funcionario");
                    Microsoft.AspNetCore.Identity.IdentityResult resultado = await userManager.AddToRoleAsync(user, role.ToString());
                    return RedirectToAction("ListaDeUsuario", "Funcionario");
                }
            }
            if (user != null)
            {
                ModelState.AddModelError("UserInvalido", "Usuário já existe, tente outro nome");
            }
            else
            {
                ModelState.AddModelError("EmailInvalido", "Email Já está sendo utilizado");
            }
            return View();
        }
        public async Task<IActionResult> Logoff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(String id)
        {
            var user = await userManager.FindByIdAsync(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(String id, String funcao)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(id);
                var role = await roleManager.FindByNameAsync(funcao);
                var teste = userManager.GetUsersInRoleAsync(funcao);
                Console.WriteLine(teste.Result);
                /*if ()
                {
                    await userManager.AddToRoleAsync(user, funcao);
                }
                else
                {
                    if(funcao == "Funcionario")
                    {
                        await userManager.RemoveFromRoleAsync(user, "Gerente");
                        await userManager.AddToRoleAsync(user, funcao);
                    }
                    else
                    {
                        await userManager.RemoveFromRoleAsync(user, "Funcionario");
                        await userManager.AddToRoleAsync(user, funcao);
                    }
                }
                user.Funcao = funcao;
                await userManager.UpdateAsync(user);
                return RedirectToAction("ListaDeUsuario", "Funcionario");
            }*/
                return View();
            }
            return View();
        }
    }
}
