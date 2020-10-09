using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OficinaTcc.MailService;
using OficinaTcc.Models;
using OficinaTcc.Models.ViewModel;

namespace OficinaTcc.Controllers
{
    public class ContaController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Funcionario> userManager;
        private readonly IUserClaimsPrincipalFactory<Funcionario> userClaimsPrincipalFactory;
        private readonly SignInManager<Funcionario> signInManager;
        private readonly IServicoEmail service;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager;
        public ContaController(Microsoft.AspNetCore.Identity.UserManager<Funcionario> userManager,IUserClaimsPrincipalFactory<Funcionario> userClaimsPrincipalFactory,
            SignInManager<Funcionario> signInManager, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager,IServicoEmail service)
        {
            this.userManager = userManager;
            this.userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.service = service;
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
                    var confimacao = await userManager.IsEmailConfirmedAsync(user);
                    if (confimacao != false)
                    {
                        var result = await signInManager.CheckPasswordSignInAsync(user, model.Senha, false);
                        if (result.Succeeded)
                        {
                            await signInManager.SignInAsync(user, true);
                            return RedirectToAction("ListaDeUsuario","Funcionario");//REDIRECIONAR PRA ONDE?
                        }
                        ModelState.AddModelError("", "Senha Inválida");
                        return View();
                    }
                    ModelState.AddModelError("", "Por favor cheque seu email, a conta ainda não foi confirmada");
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
                    Nome = model.Nome,
                    Nascimento = model.Nascimento,
                    PhoneNumber = model.Telefone
                };
                var result = await userManager.CreateAsync(user, model.Senha);
                if (result.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync("Funcionario");
                    Microsoft.AspNetCore.Identity.IdentityResult resultado = await userManager.AddToRoleAsync(user,role.ToString());
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmacao = Url.Action("Confirmacao", "Conta", new { token, user.Email }, Request.Scheme);
                    ConfirmarEmail(token, user);
                    return View("ConfirmarEmail");
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
        public IActionResult ConfirmarEmail()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Confirmacao(String token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");//criar view para confirmar email nota: depois da view de confirmar, ela redireciona para profile;
                }
            }
            //tratar erro de falta de informacao 
            return View("Error");//criar view para ocasião de não confirmação de email, nota: deixar contato de adm para resolver problemas
        }
        public async Task<IActionResult> Logoff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        private void ConfirmarEmail(string token, Funcionario user)
        {
            var confirmacao = new IdentityMessage() { Destination = user.Email, Body = "Use o link abaixo para confirmar seu email\n" + token, Subject = "Bem Vindo ao ThinkingMoney" };
            service.SendAsync(confirmacao);
        }
    }
}
