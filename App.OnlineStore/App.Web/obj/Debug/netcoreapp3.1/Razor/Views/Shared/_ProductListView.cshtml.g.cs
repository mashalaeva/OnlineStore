#pragma checksum "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5172a5a2a3e770d0ab279255537db96367895c7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductListView), @"mvc.1.0.view", @"/Views/Shared/_ProductListView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5172a5a2a3e770d0ab279255537db96367895c7b", @"/Views/Shared/_ProductListView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9386501d24ccd2c509c1f7d1e82e6b6dabf08c3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductListView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<App.Web.Models.ProductListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"list-group\">\n");
#nullable restore
#line 4 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
     for (int i = 0; i < Model.Products.Count(); i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"list-group-item d-flex justify-content-end\">\n\n            <a");
            BeginWriteAttribute("href", " href=\"", 205, "\"", 250, 2);
            WriteAttributeValue("", 212, "/ProductDetail/", 212, 15, true);
#nullable restore
#line 8 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
WriteAttributeValue("", 227, Model.Products[i].Id, 227, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"list-group-item-action\">");
#nullable restore
#line 8 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
                                                                                       Write(Model.Products[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n            <div class=\"px-3 mx-3\">");
#nullable restore
#line 9 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
                              Write(Model.Products[i].Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n            <div class=\"px-3 mx-3\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5172a5a2a3e770d0ab279255537db96367895c7b5261", async() => {
                WriteLiteral("\n\n                    <input type=\"hidden\"");
                BeginWriteAttribute("id", " id=\"", 537, "\"", 555, 2);
                WriteAttributeValue("", 542, "ProductId", 542, 9, true);
#nullable restore
#line 13 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
WriteAttributeValue("", 551, i, 551, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"ProductId\"");
                BeginWriteAttribute("value", " value=\"", 573, "\"", 604, 1);
#nullable restore
#line 13 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
WriteAttributeValue("", 581, Model.Products[i].Id, 581, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n                    <input type=\"hidden\"");
                BeginWriteAttribute("id", " id=\"", 649, "\"", 663, 2);
                WriteAttributeValue("", 654, "Price", 654, 5, true);
#nullable restore
#line 14 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
WriteAttributeValue("", 659, i, 659, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"Price\"");
                BeginWriteAttribute("value", " value=\"", 677, "\"", 711, 1);
#nullable restore
#line 14 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
WriteAttributeValue("", 685, Model.Products[i].Price, 685, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n                    <input type=\"hidden\"");
                BeginWriteAttribute("id", " id=\"", 756, "\"", 771, 2);
                WriteAttributeValue("", 761, "UserId", 761, 6, true);
#nullable restore
#line 15 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
WriteAttributeValue("", 767, i, 767, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"UserId\"");
                BeginWriteAttribute("value", " value=\"", 786, "\"", 809, 1);
#nullable restore
#line 15 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
WriteAttributeValue("", 794, Model.UserId, 794, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n                    <input type=\"hidden\"");
                BeginWriteAttribute("id", " id=\"", 854, "\"", 875, 2);
                WriteAttributeValue("", 859, "ProductCount", 859, 12, true);
#nullable restore
#line 16 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
WriteAttributeValue("", 871, i, 871, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"ProductCount\" value=\"1\" />\n                    <input class=\"btn btn-primary\" type=\"submit\"");
                BeginWriteAttribute("id", " id=\"", 974, "\"", 993, 2);
                WriteAttributeValue("", 979, "AddProduct", 979, 10, true);
#nullable restore
#line 17 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
WriteAttributeValue("", 989, i, 989, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" value=\"В корзину\" />\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 11 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
AddHtmlAttributeValue("", 457, Model.PostActionURL, 457, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "name", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 485, "form", 485, 4, true);
#nullable restore
#line 11 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
AddHtmlAttributeValue("", 489, i, 489, 4, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n            </div>\n        </div>\n");
#nullable restore
#line 22 "C:\Users\acer\Desktop\EduPractice\OnlineMarket\App.OnlineStore\App.Web\Views\Shared\_ProductListView.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<App.Web.Models.ProductListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
