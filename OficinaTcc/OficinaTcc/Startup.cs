using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OficinaTcc.Data;
using OficinaTcc.Identity;
using OficinaTcc.Models;

namespace OficinaTcc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<OficinaContext>(option=> {
                option.UseMySql(Configuration.GetConnectionString("OficinaContext"));
            });

            services.AddIdentity<Usuario, IdentityRole>(Options =>
            {
                Options.SignIn.RequireConfirmedEmail = true;
                Options.Lockout.MaxFailedAccessAttempts = 3;
                Options.Lockout.AllowedForNewUsers = true;
                Options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                Options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<OficinaContext>().AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(opt => {
                    opt.LoginPath = "/Account/Login";
                    opt.Cookie.Name = "Usuario";
                });

            services.AddScoped<IUserClaimsPrincipalFactory<Usuario>, ClaimsUsuario>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public async Task CreateRole(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<Usuario>>();
            String[] roles = { "Gerente", "Funcionario" };
            IdentityResult resultado;
            foreach(var nomes in roles)
            {
                var existe = await roleManager.RoleExistsAsync(nomes);
                if (!existe)
                {
                    resultado = await roleManager.CreateAsync(new IdentityRole(nomes));
                }
            }
        }
    }
}
