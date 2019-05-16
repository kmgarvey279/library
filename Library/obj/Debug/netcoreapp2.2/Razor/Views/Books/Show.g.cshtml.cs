#pragma checksum "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11475e4edccce82caeb7ea13049554168e6fa5c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_Show), @"mvc.1.0.view", @"/Views/Books/Show.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Books/Show.cshtml", typeof(AspNetCore.Views_Books_Show))]
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
#line 1 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
using Library.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11475e4edccce82caeb7ea13049554168e6fa5c9", @"/Views/Books/Show.cshtml")]
    public class Views_Books_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 28, true);
            WriteLiteral("\n<h1>Library</h1>\n<h2>Book: ");
            EndContext();
            BeginContext(52, 32, false);
#line 4 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
     Write(Model["selectedBook"].GetTitle());

#line default
#line hidden
            EndContext();
            BeginContext(84, 14, true);
            WriteLiteral("</h2>\n<hr />\n\n");
            EndContext();
#line 7 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
 if (@Model["bookAuthors"].Count != 0)
{

#line default
#line hidden
            BeginContext(139, 47, true);
            WriteLiteral("  <h4>This book has these authors:</h4>\n  <ul>\n");
            EndContext();
#line 11 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
     foreach (Author author in @Model["bookAuthors"])
    {

#line default
#line hidden
            BeginContext(246, 10, true);
            WriteLiteral("      <li>");
            EndContext();
            BeginContext(257, 16, false);
#line 13 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
     Write(author.GetName());

#line default
#line hidden
            EndContext();
            BeginContext(273, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 14 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
    }

#line default
#line hidden
            BeginContext(285, 8, true);
            WriteLiteral("  </ul>\n");
            EndContext();
#line 16 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
}

#line default
#line hidden
            BeginContext(295, 6, true);
            WriteLiteral("\n<form");
            EndContext();
            BeginWriteAttribute("action", " action=\'", 301, "\'", 359, 3);
            WriteAttributeValue("", 310, "/books/", 310, 7, true);
#line 18 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
WriteAttributeValue("", 317, Model["selectedBook"].GetId(), 317, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 347, "/authors/new", 347, 12, true);
            EndWriteAttribute();
            BeginContext(360, 115, true);
            WriteLiteral(" method=\'post\'>\n  <label for=\'authorId\'>Add an author</label>\n  <select id=\'authorId\' name=\'authorId\' type=\'text\'>\n");
            EndContext();
#line 21 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
     foreach (var author in @Model["allAuthors"])
    {

#line default
#line hidden
            BeginContext(531, 13, true);
            WriteLiteral("      <option");
            EndContext();
            BeginWriteAttribute("value", " value=\'", 544, "\'", 567, 1);
#line 23 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
WriteAttributeValue("", 552, author.GetId(), 552, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(568, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(570, 16, false);
#line 23 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
                                 Write(author.GetName());

#line default
#line hidden
            EndContext();
            BeginContext(586, 10, true);
            WriteLiteral("</option>\n");
            EndContext();
#line 24 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
    }

#line default
#line hidden
            BeginContext(602, 166, true);
            WriteLiteral("  </select>\n  <button type=\'submit\'>Add</button>\n</form>\n\n<p><a href=\"/authors/new\">Add new author to catalog</a></p>\n<p><a href=\"/\">Return to Main Page</a></p>\n<p><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 768, "\"", 819, 3);
            WriteAttributeValue("", 775, "/books/", 775, 7, true);
#line 31 "/Users/Guest/Desktop/Library.Solution/Library/Views/Books/Show.cshtml"
WriteAttributeValue("", 782, Model["selectedBook"].GetId(), 782, 30, false);

#line default
#line hidden
            WriteAttributeValue("", 812, "/delete", 812, 7, true);
            EndWriteAttribute();
            BeginContext(820, 25, true);
            WriteLiteral(">Delete this book</a><p>\n");
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
