#pragma checksum "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9a1e26c5d81c1e0a020a134d6e6ede7bf44776b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_SelectT), @"mvc.1.0.view", @"/Views/Orders/SelectT.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Orders/SelectT.cshtml", typeof(AspNetCore.Views_Orders_SelectT))]
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
#line 1 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\_ViewImports.cshtml"
using BusinessBears;

#line default
#line hidden
#line 2 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\_ViewImports.cshtml"
using BusinessBears.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9a1e26c5d81c1e0a020a134d6e6ede7bf44776b", @"/Views/Orders/SelectT.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6099fbce6a1c26bbd9f9338e4bbeca769f61bf0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_SelectT : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BusinessBears.WebUI.Models.ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SelectL", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(65, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
  
    ViewData["Title"] = "Order Processing 3";

#line default
#line hidden
            BeginContext(121, 25, true);
            WriteLiteral("\r\n<h4>Customer Selected: ");
            EndContext();
            BeginContext(147, 20, false);
#line 7 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
                  Write(ViewBag.CustomerName);

#line default
#line hidden
            EndContext();
            BeginContext(167, 146, true);
            WriteLiteral("</h4>\r\n<hr />\r\n<h4>Select the necessary training for each bear.</h4>\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n       \r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(313, 1627, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b9a1e26c5d81c1e0a020a134d6e6ede7bf44776b4920", async() => {
                BeginContext(354, 179, true);
                WriteLiteral("\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    Bear #\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(534, 40, false);
#line 23 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
                EndContext();
                BeginContext(574, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(642, 41, false);
#line 26 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
               Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
                EndContext();
                BeginContext(683, 106, true);
                WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
                EndContext();
#line 32 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
             for (int i = 1; i < ViewBag.BearNumber + 1; i++)
            {

#line default
#line hidden
                BeginContext(867, 72, true);
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(940, 1, false);
#line 36 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
                   Write(i);

#line default
#line hidden
                EndContext();
                BeginContext(941, 121, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td></td>\r\n                    <td>$199.99</td>\r\n                </tr>\r\n");
                EndContext();
#line 41 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
                 foreach (var item2 in Model)
                {

#line default
#line hidden
                BeginContext(1128, 119, true);
                WriteLiteral("                    <tr>\r\n                        <td></td>\r\n                        <td>\r\n                            ");
                EndContext();
                BeginContext(1248, 36, false);
#line 46 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
                       Write(Html.DisplayFor(model => item2.Name));

#line default
#line hidden
                EndContext();
                BeginContext(1284, 92, true);
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            $");
                EndContext();
                BeginContext(1377, 37, false);
#line 49 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
                        Write(Html.DisplayFor(model => item2.Price));

#line default
#line hidden
                EndContext();
                BeginContext(1414, 132, true);
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <input type=\"checkbox\" name=TrainingArray");
                EndContext();
                BeginWriteAttribute("value", " value=", 1546, "", 1562, 1);
#line 52 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
WriteAttributeValue("", 1553, item2.Id, 1553, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1562, 65, true);
                WriteLiteral(" />\r\n\r\n                        </td>\r\n                    </tr>\r\n");
                EndContext();
#line 56 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
                }

#line default
#line hidden
                BeginContext(1646, 102, true);
                WriteLiteral("        <tr>\r\n            <td><input type=\"hidden\" name=TrainingArray value=0 /></td>\r\n        </tr>\r\n");
                EndContext();
#line 60 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
            }

#line default
#line hidden
                BeginContext(1763, 72, true);
                WriteLiteral("        </tbody>\r\n    </table>\r\n    <input type=\"hidden\" name=CustomerID");
                EndContext();
                BeginWriteAttribute("value", " value=", 1835, "", 1861, 1);
#line 63 "C:\Users\Eid\source\repos\sadiki-project1\BusinessBears.WebUI\BusinessBears\Views\Orders\SelectT.cshtml"
WriteAttributeValue("", 1842, ViewBag.CustomerID, 1842, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1861, 72, true);
                WriteLiteral(" />\r\n    <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BusinessBears.WebUI.Models.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591