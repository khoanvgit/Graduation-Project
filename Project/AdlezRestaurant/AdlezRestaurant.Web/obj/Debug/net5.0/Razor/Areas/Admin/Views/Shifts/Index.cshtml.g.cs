#pragma checksum "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Shifts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f815c889cc7682ccf6479f2da1de72819812ee78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shifts_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Shifts/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f815c889cc7682ccf6479f2da1de72819812ee78", @"/Areas/Admin/Views/Shifts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66e66d0ac0862d4674be5fb8b5b1cd59a23c6114", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shifts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AdlezRestaurant.Core.Models.Shift>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Shifts\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Shifts</h1>\r\n\r\n<div id=\"view_all\">\r\n    ");
#nullable restore
#line 10 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Shifts\Index.cshtml"
Write(await Html.PartialAsync("_ViewAll", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Shifts\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AdlezRestaurant.Core.Models.Shift>> Html { get; private set; }
    }
}
#pragma warning restore 1591
