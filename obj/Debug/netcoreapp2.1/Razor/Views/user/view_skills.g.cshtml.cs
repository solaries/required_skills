#pragma checksum "/home/sphinx/code/required skills/Views/user/view_skills.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd4b2cd61adabfe67020a27a5c626779ca5f3a6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_user_view_skills), @"mvc.1.0.view", @"/Views/user/view_skills.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/user/view_skills.cshtml", typeof(AspNetCore.Views_user_view_skills))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd4b2cd61adabfe67020a27a5c626779ca5f3a6a", @"/Views/user/view_skills.cshtml")]
    public class Views_user_view_skills : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Rs_71.Models.Rs_71skill_count>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 515, true);
            WriteLiteral(@"

<div class=""card"">
    <div class=""card-body"">
        <h4 class=""card-title"">View skills</h4>
        <div class=""table-responsive"">
            <table class=""table table-striped table-bordered zero-configuration"">
                <thead>
                    <tr>
                        <th></th>
                        <th>Site_name</th>
                        <th>skill</th>
                        <th>Count</th>

                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 19 "/home/sphinx/code/required skills/Views/user/view_skills.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
            BeginContext(639, 103, true);
            WriteLiteral("                        <tr>\r\n\r\n                            <td></td>\r\n                            <td>");
            EndContext();
            BeginContext(743, 44, false);
#line 24 "/home/sphinx/code/required skills/Views/user/view_skills.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Site_name));

#line default
#line hidden
            EndContext();
            BeginContext(787, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(827, 40, false);
#line 25 "/home/sphinx/code/required skills/Views/user/view_skills.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Skill));

#line default
#line hidden
            EndContext();
            BeginContext(867, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(907, 39, false);
#line 26 "/home/sphinx/code/required skills/Views/user/view_skills.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Coun));

#line default
#line hidden
            EndContext();
            BeginContext(946, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 28 "/home/sphinx/code/required skills/Views/user/view_skills.cshtml"
                    }

#line default
#line hidden
            BeginContext(1007, 457, true);
            WriteLiteral(@"
                </tbody>
                <tfoot>
                    <tr>
                        <th></th>
                        <th>Site name</th>
                        <th>skill</th>
                        <th>Count</th>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</div>
<script>
    function msg(txt) {
        sweetAlert(""..."", txt, ""info"");
    }
    var statusMessage = """);
            EndContext();
            BeginContext(1465, 14, false);
#line 47 "/home/sphinx/code/required skills/Views/user/view_skills.cshtml"
                    Write(ViewBag.status);

#line default
#line hidden
            EndContext();
            BeginContext(1479, 121, true);
            WriteLiteral("\" || false;\r\n    if (statusMessage != false && statusMessage.length > 0) {\r\n        msg(statusMessage);\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Rs_71.Models.Rs_71skill_count>> Html { get; private set; }
    }
}
#pragma warning restore 1591
