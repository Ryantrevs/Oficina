
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OficinaTcc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OficinaTcc.Identity
{
    public class ClaimsUsuario : UserClaimsPrincipalFactory<Usuario>
    {
        public ClaimsUsuario(UserManager<Usuario> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Usuario user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            return identity;
        }
    }
}
