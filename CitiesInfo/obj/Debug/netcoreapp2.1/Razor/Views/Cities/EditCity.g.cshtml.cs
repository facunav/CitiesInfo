#pragma checksum "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c8e51a41ac0880ee96a6800cfd65dbcc9c022ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cities_EditCity), @"mvc.1.0.view", @"/Views/Cities/EditCity.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cities/EditCity.cshtml", typeof(AspNetCore.Views_Cities_EditCity))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c8e51a41ac0880ee96a6800cfd65dbcc9c022ad", @"/Views/Cities/EditCity.cshtml")]
    public class Views_Cities_EditCity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dtos.City>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
            BeginContext(60, 42, true);
            WriteLiteral("\r\n<h1>Edit</h1>\r\n\r\n<h4>City</h4>\r\n<hr />\r\n");
            EndContext();
#line 11 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(137, 23, false);
#line 13 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(164, 59, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(224, 64, false);
#line 17 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(288, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(299, 37, false);
#line 18 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
   Write(Html.HiddenFor(model => model.CityId));

#line default
#line hidden
            EndContext();
            BeginContext(336, 50, true);
            WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(387, 93, false);
#line 21 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
       Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(480, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(536, 93, false);
#line 23 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
           Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(629, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(648, 82, false);
#line 24 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(730, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(817, 100, false);
#line 29 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
       Write(Html.LabelFor(model => model.Description, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(917, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(973, 100, false);
#line 31 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
           Write(Html.EditorFor(model => model.Description, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1073, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1092, 89, false);
#line 32 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
           Write(Html.ValidationMessageFor(model => model.Description, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1181, 253, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-default\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 42 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
}

#line default
#line hidden
            BeginContext(1437, 11, true);
            WriteLiteral("<div>\r\n    ");
            EndContext();
            BeginContext(1449, 44, false);
#line 44 "C:\Users\Colo\source\repos\CitiesInfo\CitiesInfo\Views\Cities\EditCity.cshtml"
Write(Html.ActionLink("Back to List", "GetCities"));

#line default
#line hidden
            EndContext();
            BeginContext(1493, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dtos.City> Html { get; private set; }
    }
}
#pragma warning restore 1591