#pragma checksum "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77395c9bef6df85330bbcae80d2b69488d437cab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/admin/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\_ViewImports.cshtml"
using Finsa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\_ViewImports.cshtml"
using Finsa.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\_ViewImports.cshtml"
using Finsa.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\_ViewImports.cshtml"
using Finsa.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77395c9bef6df85330bbcae80d2b69488d437cab", @"/Areas/admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3fda1024405cd84f6fda2a4a8cfdf941646edbf", @"/Areas/admin/Views/_ViewImports.cshtml")]
    public class Areas_admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration: none;color: #fff;font-size: 22px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Team", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Blog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Service", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Project", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container-fluid"">
        <div class=""block-header"">
            <h2>DASHBOARD</h2>
        </div>
        <!-- #END# Widgets -->
        <!-- CPU Usage -->
        <div class=""row clearfix"">
            <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12"">
                <div class=""card"">
                    <div class=""header"">
                        <div class=""row clearfix"">
                            <div class=""col-lg-3 col-md-3 col-sm-6 col-xs-12"">
                                <div class=""info-box bg-pink hover-expand-effect"">
                                    <div class=""icon"">
                                        <i class=""material-icons"">playlist_add_check</i>
                                    </div>
                                    <div class=""content"">
                                        <div class=""text"" style=""margin-top: 0;"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77395c9bef6df85330bbcae80d2b69488d437cab7414", async() => {
                WriteLiteral("Teams");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n                                        <div class=\"number count-to\" data-from=\"0\" data-to=\"");
#nullable restore
#line 24 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml"
                                                                                       Write(ViewBag.Teams);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-speed=\"1\" data-fresh-interval=\"20\">");
#nullable restore
#line 24 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml"
                                                                                                                                               Write(ViewBag.Teams);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg-3 col-md-3 col-sm-6 col-xs-12"">
                                <div class=""info-box bg-cyan hover-expand-effect"">
                                    <div class=""icon"">
                                        <i class=""material-icons"">help</i>
                                    </div>
                                    <div class=""content"">
                                        <div class=""text"" style=""margin-top: 0;"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77395c9bef6df85330bbcae80d2b69488d437cab10516", async() => {
                WriteLiteral("Blogs");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n                                        <div class=\"number count-to\" data-from=\"0\" data-to=\"");
#nullable restore
#line 35 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml"
                                                                                       Write(ViewBag.Blogs);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-speed=\"1\" data-fresh-interval=\"20\">");
#nullable restore
#line 35 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml"
                                                                                                                                               Write(ViewBag.Blogs);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg-3 col-md-3 col-sm-6 col-xs-12"">
                                <div class=""info-box bg-light-green hover-expand-effect"">
                                    <div class=""icon"">
                                        <i class=""material-icons"">forum</i>
                                    </div>
                                    <div class=""content"">
                                        <div class=""text"" style=""margin-top: 0;"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77395c9bef6df85330bbcae80d2b69488d437cab13627", async() => {
                WriteLiteral("Services");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n                                        <div class=\"number count-to\" data-from=\"0\" data-to=\"");
#nullable restore
#line 46 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml"
                                                                                       Write(ViewBag.Services);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-speed=\"1\" data-fresh-interval=\"20\">");
#nullable restore
#line 46 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml"
                                                                                                                                                  Write(ViewBag.Services);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>
                                </div>
                            </div>
                            <div class=""col-lg-3 col-md-3 col-sm-6 col-xs-12"">
                                <div class=""info-box bg-orange hover-expand-effect"">
                                    <div class=""icon"">
                                        <i class=""material-icons"">person_add</i>
                                    </div>
                                    <div class=""content"">
                                        <div class=""text"" style=""margin-top: 0;"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77395c9bef6df85330bbcae80d2b69488d437cab16750", async() => {
                WriteLiteral("Projects");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n                                        <div class=\"number count-to\" data-from=\"0\" data-to=\"");
#nullable restore
#line 57 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml"
                                                                                       Write(ViewBag.Projects);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-speed=\"1\" data-fresh-interval=\"20\">");
#nullable restore
#line 57 "C:\Users\TUF DASH\Desktop\Final Full Project\Finsa\Finsa\Areas\admin\Views\Home\Index.cshtml"
                                                                                                                                                  Write(ViewBag.Projects);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""row clearfix"">
                            <div class=""col-xs-12 col-sm-6"">
                                <h2>CPU USAGE (%)</h2>
                            </div>
                            <div class=""col-xs-12 col-sm-6 align-right"">
                                <div class=""switch panel-switch-btn"">
                                    <span class=""m-r-10 font-12"">REAL TIME</span>
                                    <label>OFF<input type=""checkbox"" id=""realtime"" checked><span class=""lever switch-col-cyan""></span>ON</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""body"">
                        <div id=""real_time_chart"" class=""dashboard-flot-chart""></div>
                    <");
            WriteLiteral("/div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!-- #END# CPU Usage -->\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
