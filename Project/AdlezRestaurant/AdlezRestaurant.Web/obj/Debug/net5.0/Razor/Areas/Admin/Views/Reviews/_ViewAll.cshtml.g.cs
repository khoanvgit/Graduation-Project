#pragma checksum "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39c1cea88f2977b866c521ddbb7aa0cfaf041fa8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Reviews__ViewAll), @"mvc.1.0.view", @"/Areas/Admin/Views/Reviews/_ViewAll.cshtml")]
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
#line 1 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\_ViewImports.cshtml"
using AdlezRestaurant.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\_ViewImports.cshtml"
using AdlezRestaurant.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39c1cea88f2977b866c521ddbb7aa0cfaf041fa8", @"/Areas/Admin/Views/Reviews/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66e66d0ac0862d4674be5fb8b5b1cd59a23c6114", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Reviews__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AdlezRestaurant.Core.Models.Review>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return JqueryAjaxDelete(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<table class=\"table\" id=\"userDatatable\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 7 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
           Write(Html.DisplayNameFor(model => model.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 10 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
           Write(Html.DisplayNameFor(model => model.ReviewDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
           Write(Html.DisplayNameFor(model => model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 468, "\"", 571, 3);
            WriteAttributeValue("", 478, "showInPopup(\'", 478, 13, true);
#nullable restore
#line 16 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
WriteAttributeValue("", 491, Url.Action("CreateOrEdit", "Reviews", null, Context.Request.Scheme), 491, 68, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 559, "\',\'Reviews\')", 559, 12, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success text-light\"><i class=\"fas fa-plus-square\"></i> New</a>\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 21 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 25 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 28 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.ReviewDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 31 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a style=\"color: blue; cursor: pointer; float: left; margin-right: 40px;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1233, "\"", 1350, 3);
            WriteAttributeValue("", 1243, "showInPopup(\'", 1243, 13, true);
#nullable restore
#line 34 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
WriteAttributeValue("", 1256, Url.Action("CreateOrEdit", "Reviews", new{id = @item.Id}, Context.Request.Scheme), 1256, 82, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1338, "\',\'Reviews\')", 1338, 12, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-edit\"></i></a>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39c1cea88f2977b866c521ddbb7aa0cfaf041fa89706", async() => {
                WriteLiteral(@"
                        <button type=""submit"" style=""border-top-style: hidden;border-bottom-style: hidden;border-left-style: hidden;border-right-style: hidden; outline: none; color: red; background-color: transparent;""><i class=""fas fa-trash""></i></button>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 40 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Reviews\_ViewAll.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AdlezRestaurant.Core.Models.Review>> Html { get; private set; }
    }
}
#pragma warning restore 1591
