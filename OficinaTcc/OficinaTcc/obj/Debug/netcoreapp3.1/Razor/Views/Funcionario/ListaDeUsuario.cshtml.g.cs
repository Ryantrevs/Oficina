#pragma checksum "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\Funcionario\ListaDeUsuario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58d35da27633c443ece9df4a55f26ebd794c38a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Funcionario_ListaDeUsuario), @"mvc.1.0.view", @"/Views/Funcionario/ListaDeUsuario.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\_ViewImports.cshtml"
using OficinaTcc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\_ViewImports.cshtml"
using OficinaTcc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58d35da27633c443ece9df4a55f26ebd794c38a5", @"/Views/Funcionario/ListaDeUsuario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"231aa4145ea8570980a1abd41de4c676062e1172", @"/Views/_ViewImports.cshtml")]
    public class Views_Funcionario_ListaDeUsuario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Funcionario>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<table>\r\n   <tr>\r\n       <th>Nome</th>\r\n       <th>Data de nascimento</th>\r\n       <th>Função</th>\r\n       <th>Contato</th>\r\n       <th>Email</th>\r\n   </tr>\r\n");
#nullable restore
#line 10 "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\Funcionario\ListaDeUsuario.cshtml"
       
        foreach (Funcionario func in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 13 "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\Funcionario\ListaDeUsuario.cshtml"
           Write(func.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 14 "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\Funcionario\ListaDeUsuario.cshtml"
           Write(func.Nascimento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 15 "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\Funcionario\ListaDeUsuario.cshtml"
           Write(func.Funcao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 16 "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\Funcionario\ListaDeUsuario.cshtml"
           Write(func.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 17 "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\Funcionario\ListaDeUsuario.cshtml"
           Write(func.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 20 "C:\Users\Patrick F\Desktop\Tcc\OficinaTcc\OficinaTcc\Views\Funcionario\ListaDeUsuario.cshtml"
        } 
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Funcionario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
