#pragma checksum "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c80be675b2d81c1c0647e661f0e7720f78a6d7cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authors_Show), @"mvc.1.0.view", @"/Views/Authors/Show.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Authors/Show.cshtml", typeof(AspNetCore.Views_Authors_Show))]
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
#line 1 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
using Library.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c80be675b2d81c1c0647e661f0e7720f78a6d7cb", @"/Views/Authors/Show.cshtml")]
    public class Views_Authors_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 30, true);
            WriteLiteral("\n<h1>Library</h1>\n<h2>Author: ");
            EndContext();
            BeginContext(54, 25, false);
#line 4 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
       Write(Model["author"].GetName());

#line default
#line hidden
            EndContext();
            BeginContext(79, 14, true);
            WriteLiteral("</h2>\n<hr />\n\n");
            EndContext();
#line 7 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
 if (@Model["authorBooks"].Count != 0)
{

#line default
#line hidden
            BeginContext(134, 65, true);
            WriteLiteral("  <h4>Here are all the books written by this author:</h4>\n  <ul>\n");
            EndContext();
#line 11 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
     foreach (var book in @Model["authorBooks"])
    {

#line default
#line hidden
            BeginContext(254, 10, true);
            WriteLiteral("      <li>");
            EndContext();
            BeginContext(265, 15, false);
#line 13 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
     Write(book.GetTitle());

#line default
#line hidden
            EndContext();
            BeginContext(280, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 14 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
    }

#line default
#line hidden
            BeginContext(292, 8, true);
            WriteLiteral("  </ul>\n");
            EndContext();
#line 16 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
}

#line default
#line hidden
            BeginContext(302, 28, true);
            WriteLiteral("\n<h4>Add a book:</h4>\n\n<form");
            EndContext();
            BeginWriteAttribute("action", " action=\'", 330, "\'", 382, 3);
            WriteAttributeValue("", 339, "/authors/", 339, 9, true);
#line 20 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
WriteAttributeValue("", 348, Model["author"].GetId(), 348, 24, false);

#line default
#line hidden
            WriteAttributeValue("", 372, "/books/new", 372, 10, true);
            EndWriteAttribute();
            BeginContext(383, 110, true);
            WriteLiteral(" method=\'post\'>\n  <label for=\'bookId\'>Select a book</label>\n  <select id=\'bookId\' name=\'bookId\' type=\'text\'>\n\n");
            EndContext();
#line 24 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
     foreach (var book in @Model["allBooks"])
    {

#line default
#line hidden
            BeginContext(545, 13, true);
            WriteLiteral("      <option");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 558, "\'", 579, 1);
#line 26 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
WriteAttributeValue("", 566, book.GetId(), 566, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(580, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(582, 15, false);
#line 26 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
                               Write(book.GetTitle());

#line default
#line hidden
            EndContext();
            BeginContext(597, 10, true);
            WriteLiteral("</option>\n");
            EndContext();
#line 27 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
    }

#line default
#line hidden
            BeginContext(613, 126, true);
            WriteLiteral("\n  </select>\n  <button type=\'submit\'>Add</button>\n</form>\n\n<p><a href=\"/books/new\">add a new book to the catalog</a></p>\n<p><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 739, "\"", 785, 3);
            WriteAttributeValue("", 746, "/author/", 746, 8, true);
#line 34 "/Users/Guest/Desktop/Library.Solution/Library/Views/Authors/Show.cshtml"
WriteAttributeValue("", 754, Model["author"].GetId(), 754, 24, false);

#line default
#line hidden
            WriteAttributeValue("", 778, "/delete", 778, 7, true);
            EndWriteAttribute();
            BeginContext(786, 55, true);
            WriteLiteral(">Delete this author</a><p>\n<p><a href=\"/\">Home</a></p>\n");
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
