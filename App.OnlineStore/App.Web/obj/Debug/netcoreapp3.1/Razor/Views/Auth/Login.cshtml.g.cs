#pragma checksum "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8ee0eb1696c7c51ef302bf682635f244def7489"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_Login), @"mvc.1.0.view", @"/Views/Auth/Login.cshtml")]
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
#line 1 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\_ViewImports.cshtml"
using App.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\_ViewImports.cshtml"
using App.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8ee0eb1696c7c51ef302bf682635f244def7489", @"/Views/Auth/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9386501d24ccd2c509c1f7d1e82e6b6dabf08c3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<App.Web.Models.LoginModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
   ViewData["Title"] = "Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 5 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
Write(await Html.PartialAsync("_UserView", Model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Вход на сайт</h2>\n");
#nullable restore
#line 7 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
 using (Html.BeginForm("Login", "Auth", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\n        ");
#nullable restore
#line 12 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
   Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 15 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
       Write(Html.LabelFor(model => model.Email, new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 17 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
           Write(Html.EditorFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 18 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
           Write(Html.ValidationMessageFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 24 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
       Write(Html.LabelFor(model => model.Password, new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 26 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
           Write(Html.EditorFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 27 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
           Write(Html.ValidationMessageFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n        \n        <div class=\"form-group\">\n            <div class=\"col-md-offset-2 col-md-10\">\n                <input type=\"submit\" value=\"Войти\" class=\"btn btn-success\" />\n            </div>\n        </div>\n    </div>\n");
#nullable restore
#line 37 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Auth\Login.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<App.Web.Models.LoginModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
