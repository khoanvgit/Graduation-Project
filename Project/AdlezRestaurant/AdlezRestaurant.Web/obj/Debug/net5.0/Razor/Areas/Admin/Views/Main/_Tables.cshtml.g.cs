#pragma checksum "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ace859b4ef0f076f7e77edb9d4d971bb41fb0db5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Main__Tables), @"mvc.1.0.view", @"/Areas/Admin/Views/Main/_Tables.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
using AdlezRestaurant.Web.Areas.Admin.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ace859b4ef0f076f7e77edb9d4d971bb41fb0db5", @"/Areas/Admin/Views/Main/_Tables.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66e66d0ac0862d4674be5fb8b5b1cd59a23c6114", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Main__Tables : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GeneralModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div class=""col-xxl-12"">
    <div class=""card"">
        <div class=""card-header border-0 pb-0 d-sm-flex d-block"">
            <h4 class=""card-title mb-1"">Table Management</h4>
        </div>
        <div class=""card-body orders-summary"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ace859b4ef0f076f7e77edb9d4d971bb41fb0db54810", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
                 foreach (var item in Model.Tables)
                {
                    if (item.Status == "available" || item.Status == "wait")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input");
                BeginWriteAttribute("onclick", " onclick=\"", 560, "\"", 666, 3);
                WriteAttributeValue("", 570, "tableClick(\'", 570, 12, true);
#nullable restore
#line 15 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
WriteAttributeValue("", 582, Url.Action("Detail", "Main", new {number = @item.Number}, Context.Request.Scheme), 582, 82, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 664, "\')", 664, 2, true);
                EndWriteAttribute();
                WriteLiteral(" style=\"width:90px; height:80px; margin: 10px;\" class=\"btn btn-success\"");
                BeginWriteAttribute("value", " value=\"", 738, "\"", 758, 1);
#nullable restore
#line 15 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
WriteAttributeValue("", 746, item.Number, 746, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 16 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
                        if (item.Status == "wait")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <i class=\"fas fa-question m-0 p-0\" style=\"position: relative; left: -95px; top: -25px; z-index:99;\"></i>\r\n");
#nullable restore
#line 19 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
                        }
                    }
                    if (item.Status == "busy")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input");
                BeginWriteAttribute("onclick", " onclick=\"", 1128, "\"", 1234, 3);
                WriteAttributeValue("", 1138, "tableClick(\'", 1138, 12, true);
#nullable restore
#line 23 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
WriteAttributeValue("", 1150, Url.Action("Detail", "Main", new {number = @item.Number}, Context.Request.Scheme), 1150, 82, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1232, "\')", 1232, 2, true);
                EndWriteAttribute();
                WriteLiteral(" style=\"width:90px; height:80px; margin: 10px;\" class=\"btn btn-danger\"");
                BeginWriteAttribute("value", " value=\"", 1305, "\"", 1325, 1);
#nullable restore
#line 23 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
WriteAttributeValue("", 1313, item.Number, 1313, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 24 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
                    }
                    if (item.Status == "reserved")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input");
                BeginWriteAttribute("onclick", " onclick=\"", 1459, "\"", 1565, 3);
                WriteAttributeValue("", 1469, "tableClick(\'", 1469, 12, true);
#nullable restore
#line 27 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
WriteAttributeValue("", 1481, Url.Action("Detail", "Main", new {number = @item.Number}, Context.Request.Scheme), 1481, 82, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1563, "\')", 1563, 2, true);
                EndWriteAttribute();
                WriteLiteral(" style=\"width:90px; height:80px; margin: 10px;\" class=\"btn btn-warning\"");
                BeginWriteAttribute("value", " value=\"", 1637, "\"", 1657, 1);
#nullable restore
#line 27 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
WriteAttributeValue("", 1645, item.Number, 1645, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 28 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Tables.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GeneralModel> Html { get; private set; }
    }
}
#pragma warning restore 1591