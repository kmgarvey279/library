#pragma checksum "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecaa0d90cc1c8b06f94ea3a8e30db7eb99154e2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_Index), @"mvc.1.0.view", @"/Views/Books/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Books/Index.cshtml", typeof(AspNetCore.Views_Books_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecaa0d90cc1c8b06f94ea3a8e30db7eb99154e2c", @"/Views/Books/Index.cshtml")]
    public class Views_Books_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 41, true);
            WriteLiteral("<h1>Library</h1>\n<hr />\n<h2>Books:</h2>\n\n");
            EndContext();
#line 5 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Index.cshtml"
 if (Model.Count != 0)
{

#line default
#line hidden
            BeginContext(66, 7, true);
            WriteLiteral("  <ul>\n");
            EndContext();
#line 8 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Index.cshtml"
   foreach(var book in Model)
  {

#line default
#line hidden
            BeginContext(107, 10, true);
            WriteLiteral("    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 117, "\'", 144, 2);
            WriteAttributeValue("", 124, "/books/", 124, 7, true);
#line 10 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Index.cshtml"
WriteAttributeValue("", 131, book.GetId(), 131, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(145, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(147, 15, false);
#line 10 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Index.cshtml"
                                  Write(book.GetTitle());

#line default
#line hidden
            EndContext();
            BeginContext(162, 10, true);
            WriteLiteral("</a></li>\n");
            EndContext();
#line 11 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Index.cshtml"
  }

#line default
#line hidden
            BeginContext(176, 8, true);
            WriteLiteral("  </ul>\n");
            EndContext();
#line 13 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Index.cshtml"
}

#line default
#line hidden
            BeginContext(186, 95, true);
            WriteLiteral("\n<h4><a href=\"/books/new\">Add a new book</a></h4>\n<h4><a href=\"/\">Return to home page</a></h4>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
