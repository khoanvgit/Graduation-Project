#pragma checksum "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07329a045ff7117a2118f10dbbc305ff9524c5c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Main__Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/Main/_Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07329a045ff7117a2118f10dbbc305ff9524c5c3", @"/Areas/Admin/Views/Main/_Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66e66d0ac0862d4674be5fb8b5b1cd59a23c6114", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Main__Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdlezRestaurant.Web.Areas.Admin.ViewModels.GeneralModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("cash"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("creditcard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
 if (ViewBag.on != null && ViewBag.Status == "busy")
{
    int d = 0;
    decimal totalM = 0;
    var order = Model.Orders.FirstOrDefault(o => o.TableNumber == ViewBag.on);
    var orderId = -1;
    var customerName = "";
    var orderTime = "";
    var customerId = 0;
    if (order != null)
    {
        customerName = order.Customer.FirstName;
        orderTime = order.OrderDate.ToString();
        orderId = order.OrderId;
        customerId = order.Customer.CustomerId;
    }



#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""col-xxl-6 col-md-6 col-xl-6 col-lg-6"">
        <div id=""user-activity"" class=""card"">
            <div class=""card-header border-0 pb-0 d-sm-flex d-block"">
                <h4 class=""card-title mb-1"">Dishes</h4>
            </div>
            <div class=""card-body"">
                <div>
                    <hr style=""width: 90%; margin: auto; border-width: 1px; color: black; background-color: black "" />
                    <br />
                    <div>
                        <table class=""table table-bordered"">
                            <thead class=""thead-dark"">
                                <tr>
                                    <th colspan=""4"" style=""text-align: right;"">
                                        <input class=""btn btn-danger btn-sm"" value=""CANCEL ORDER""");
            BeginWriteAttribute("onclick", " onclick=\"", 1393, "\"", 1503, 3);
            WriteAttributeValue("", 1403, "cancelOrder(\'", 1403, 13, true);
#nullable restore
#line 37 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 1416, Url.Action("CancelOrder", "Main", new {number = ViewBag.on}, Context.Request.Scheme), 1416, 85, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1501, "\')", 1501, 2, true);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    </th>
                                </tr>
                                <tr>
                                    <th scope=""col"">Name</th>
                                    <th scope=""col"">Price</th>
                                    <th scope=""col"">Number</th>
                                    <th scope=""col"">Option</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 48 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                 foreach (var item in Model.OrderDetails)
                                {
                                    if (item.Order.TableNumber == ViewBag.on)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 53 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                           Write(item.Dish.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 54 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                           Write(item.Dish.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 55 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                           Write(item.DishNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n                                                <input class=\"btn btn-outline-primary btn-sm\" value=\"Cancel\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2644, "\"", 2789, 6);
            WriteAttributeValue("", 2654, "cancelDish(\'", 2654, 12, true);
#nullable restore
#line 57 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 2666, Url.Action("CancelDish", "Main", new{ dishId = @item.DishId, orderId = @orderId}, Context.Request.Scheme), 2666, 106, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2772, "\',", 2772, 2, true);
            WriteAttributeValue(" ", 2774, "\'", 2775, 2, true);
#nullable restore
#line 57 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 2776, ViewBag.on, 2776, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2787, "\')", 2787, 2, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 60 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>
                    <hr style=""width: 90%; margin: auto; border-width: 1px; color: black; background-color: black "" />
                    <br />
                </div>
                <div>
                    <div class=""input-group mb-3"">
                        <input class=""form-control border border-secondary"" id=""myInput"" type=""text"" placeholder=""Search.."">
                        <div class=""input-group-append"">
                            <button id=""btnClearSearch"" class=""btn btn-sm btn-outline-secondary"" type=""button"">Clear</button>
                        </div>
                    </div>
                    <div>
                        <table class=""table table-bordered"">
                            <thead>
                                <tr>
                                    <td>Name</td>
                                    <td>Price</td>
                                    <td");
            WriteLiteral(">Number</td>\r\n                                    <td></td>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody id=\"myTable\">\r\n");
#nullable restore
#line 86 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                 foreach (var item1 in Model.Dishes)
                                {
                                    string aa = "dishnum" + @item1.DishId;
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n                                        <td>");
#nullable restore
#line 90 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                       Write(item1.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 91 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                       Write(item1.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            <input");
            BeginWriteAttribute("id", " id=\"", 4623, "\"", 4631, 1);
#nullable restore
#line 93 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 4628, aa, 4628, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" type=""number"" style=""width:50px"" value=""1"" min=""1"" onchange=""updateNumber(this)"" />
                                        </td>
                                        <td>
                                            <input class=""btn btn-outline-primary btn-sm"" value=""Add""");
            BeginWriteAttribute("onclick", " onclick=\"", 4912, "\"", 5062, 9);
            WriteAttributeValue("", 4922, "chooseDish(\'", 4922, 12, true);
#nullable restore
#line 96 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 4934, Url.Action("AddDish", "Main", new{ dishId = @item1.DishId, orderId = @orderId}, Context.Request.Scheme), 4934, 104, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5038, "\',", 5038, 2, true);
            WriteAttributeValue(" ", 5040, "\'", 5041, 2, true);
#nullable restore
#line 96 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 5042, aa, 5042, 3, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5045, "\',", 5045, 2, true);
            WriteAttributeValue(" ", 5047, "\'", 5048, 2, true);
#nullable restore
#line 96 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 5049, ViewBag.on, 5049, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5060, "\')", 5060, 2, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 99 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-xxl-6 col-md-6 col-xl-6 col-lg-6"">
        <div class=""card"">
            <div class=""card-header border-0 pb-0 d-sm-flex d-block"">
                <h4 class=""card-title mb-1"">Payment</h4>
            </div>
            <div class=""card-body"">
                <div>
                    <div>
                        <label>Customer's Name : ");
#nullable restore
#line 115 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                            Write(customerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n                        <label>Order Time : ");
#nullable restore
#line 116 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                       Write(orderTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br />\r\n                        <label>Table : ");
#nullable restore
#line 117 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                  Write(ViewBag.on);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label><br />
                    </div>
                    <table class=""table table-bordered"">
                        <thead>
                            <tr>
                                <th>No.</th>
                                <th>Name</th>
                                <th>Price</th>
                                <th>Number</th>
                                <th>Total price</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 130 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                             foreach (var item in Model.OrderDetails)
                            {
                                if (item.Order.TableNumber == ViewBag.on)
                                {
                                    d++;
                                    decimal totalP = (decimal)(@item.Dish.Price * @item.DishNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 137 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                       Write(d);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 138 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                       Write(item.Dish.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 139 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                       Write(item.Dish.Price.Value.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 140 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                       Write(item.DishNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>$");
#nullable restore
#line 141 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                        Write(totalP);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 143 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
                                    totalM += (decimal)(item.Dish.Price * item.DishNumber);
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td colspan=\"4\" style=\"text-align:center\"><strong>TOTAL MONEY</strong></td>\r\n                                <td>$<input class=\"border-0\" type=\"number\" readonly id=\"totalM\"");
            BeginWriteAttribute("value", " value=\"", 7569, "\"", 7584, 1);
#nullable restore
#line 148 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 7577, totalM, 7577, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" /></td>
                            </tr>
                            <tr>
                                <td colspan=""4"" style=""text-align:center""><strong>CUSTOMER PAY</strong></td>
                                <td>
                                    <strong>
                                        <input id=""customerpay"" min=""0"" class=""border-bottom"" style=""outline:0; border-width:0 0 2px;"" type=""number"" placeholder=""Type money receive here. . ."" autofocus />
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td colspan=""4"" style=""text-align:center""><strong>CHANGE</strong></td>
                                <td>$<input class=""border-0"" type=""number"" readonly id=""changemoney""");
            BeginWriteAttribute("value", " value=\"", 8423, "\"", 8431, 0);
            EndWriteAttribute();
            WriteLiteral(@" /></td>
                            </tr>
                            <tr>
                                <td colspan=""4"" style=""text-align:center""><strong>MODE OF PAYMENT</strong></td>
                                <td>
                                    <select id=""mop"" class=""border-primary"" name=""modeofpayment"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07329a045ff7117a2118f10dbbc305ff9524c5c323883", async() => {
                WriteLiteral("Cash");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07329a045ff7117a2118f10dbbc305ff9524c5c325274", async() => {
                WriteLiteral("Credit card");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </select>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <input id=""btnPay"" class=""btn btn-primary btn-sm"" value=""Pay""");
            BeginWriteAttribute("onclick", " onclick=\"", 9199, "\"", 9324, 3);
            WriteAttributeValue("", 9209, "payOrder(\'", 9209, 10, true);
#nullable restore
#line 173 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 9219, Url.Action("Paying", "Main", new{ orderId = orderId, customerId = customerId}, Context.Request.Scheme), 9219, 103, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9322, "\')", 9322, 2, true);
            EndWriteAttribute();
            WriteLiteral(" disabled=\"disabled\"/>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 9371, "\"", 9462, 1);
#nullable restore
#line 174 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 9378, Url.Action("PrintInvoice","Main", new{ orderId = orderId, customerId = customerId}), 9378, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm\" target=\"_blank\">Print invoice</a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 179 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
}
else if (ViewBag.on != null && (ViewBag.Status == "available" || ViewBag.Status == "wait" || ViewBag.Status == "reserved"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 9739, "\"", 9871, 4);
            WriteAttributeValue("", 9749, "showInPopup(\'", 9749, 13, true);
#nullable restore
#line 182 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 9762, Url.Action("CreateAndOrder", "Main", new{tableNumber = ViewBag.on}, Context.Request.Scheme), 9762, 92, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9854, "\',\'New", 9854, 6, true);
            WriteAttributeValue(" ", 9860, "Customer\')", 9861, 11, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success text-light\"><i class=\"fas fa-plus-square\"></i> New Customer</a>\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 9967, "\"", 10036, 1);
#nullable restore
#line 183 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 9974, Url.Action("Create","Orders", new {tableNumber = ViewBag.on}), 9974, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\"><i class=\"fas fa-arrow-alt-circle-right\"></i> Returned customer</a>\r\n");
#nullable restore
#line 184 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
    if (ViewBag.Status == "wait")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a");
            BeginWriteAttribute("href", " href=\"", 10183, "\"", 10231, 1);
#nullable restore
#line 186 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
WriteAttributeValue("", 10190, Url.Action("ReservationRequest", "Main"), 10190, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\"><i class=\"fas fa-arrow-alt-circle-right\"></i>Check reservation request</a>\r\n");
#nullable restore
#line 187 "C:\Users\Wolf\Downloads\Compressed\Xay dung website quan ly nha hang do Au Adlez bang ASP.NET\Project\AdlezRestaurant\AdlezRestaurant.Web\Areas\Admin\Views\Main\_Detail.cshtml"
    }
    if(ViewBag.Status == "reserved")
    {
        
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    $(document).ready(function () {
        $(""#customerpay"").on('keyup', function () {
            var total = $(""#totalM"").val();
            var pay = $(""#customerpay"").val();
            var rs = (Math.round((pay - total) * 100) / 100).toFixed(2);
            $(""#changemoney"").val(rs);
            if ($(""#customerpay"").val() == """"){
                $(""#changemoney"").val("""");
            }
            if(rs < 0 || $(""#customerpay"").val() == """"){
                $(""#btnPay"").attr(""disabled"", ""disabled"");
            }
            else{
                $(""#btnPay"").removeAttr(""disabled"");
            }
        });

        $('#btnClearSearch').on('click', function () {
            $(""#myInput"").val("""");
            $(""#myInput"").trigger(""keyup"");
        });

        $(""#myInput"").on(""keyup"", function () {
            var value = $(this).val().toLowerCase();
            $(""#myTable tr"").filter(function () {
                $(this).toggle($(this).text().toLowerCase().index");
            WriteLiteral("Of(value) > -1)\r\n            });\r\n        });\r\n    })\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdlezRestaurant.Web.Areas.Admin.ViewModels.GeneralModel> Html { get; private set; }
    }
}
#pragma warning restore 1591