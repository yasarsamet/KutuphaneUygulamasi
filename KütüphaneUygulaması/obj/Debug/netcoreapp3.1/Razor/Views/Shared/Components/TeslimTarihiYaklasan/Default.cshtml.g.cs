#pragma checksum "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\Shared\Components\TeslimTarihiYaklasan\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cdf1fa6fa3af60579f3f2aa1cd9b66d9744c92b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_TeslimTarihiYaklasan_Default), @"mvc.1.0.view", @"/Views/Shared/Components/TeslimTarihiYaklasan/Default.cshtml")]
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
#line 1 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\_ViewImports.cshtml"
using KütüphaneUygulaması;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\_ViewImports.cshtml"
using KütüphaneUygulaması.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdf1fa6fa3af60579f3f2aa1cd9b66d9744c92b5", @"/Views/Shared/Components/TeslimTarihiYaklasan/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"872821a2e2a8dff834ea1df82fe8a5f94b7377a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_TeslimTarihiYaklasan_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KütüphaneUygulaması.ViewModel.TeslimTarihiAlertViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\Shared\Components\TeslimTarihiYaklasan\Default.cshtml"
  
    int sayac = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"messagesDropdown\" role=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n    <i class=\"fas fa-envelope fa-fw\"></i>\r\n    <!-- Counter - Messages -->\r\n");
#nullable restore
#line 11 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\Shared\Components\TeslimTarihiYaklasan\Default.cshtml"
     foreach (var teslim in Model.TeslimTarihiYaklasan)
    {
        DateTime now = DateTime.Now;
        DateTime teslimtarihi = Convert.ToDateTime(teslim.TeslimTarihi);

        if (now.AddDays(5) > teslimtarihi)
        {
            sayac += 1;
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span class=\"badge badge-danger badge-counter\">");
#nullable restore
#line 21 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\Shared\Components\TeslimTarihiYaklasan\Default.cshtml"
                                              Write(sayac);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n</a>\r\n<div class=\"dropdown-list dropdown-menu dropdown-menu-right shadow animated--grow-in\" aria-labelledby=\"messagesDropdown\">\r\n    <h6 class=\"dropdown-header\">\r\n        Teslim Tarihi Yaklaşan Kitaplar\r\n    </h6>\r\n");
#nullable restore
#line 27 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\Shared\Components\TeslimTarihiYaklasan\Default.cshtml"
     foreach (var teslim in Model.TeslimTarihiYaklasan)
    {
        DateTime now = DateTime.Now;
        DateTime teslimtarihi = Convert.ToDateTime(teslim.TeslimTarihi);

        if (now.AddDays(5) > teslimtarihi)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a class=\"dropdown-item d-flex align-items-center\" href=\"#\">\r\n                <div class=\"dropdown-list-image mr-3\">\r\n                    <img class=\"rounded-circle\" src=\"https://source.unsplash.com/fn_BT9fwg_E/60x60\"");
            BeginWriteAttribute("alt", " alt=\"", 1458, "\"", 1464, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"status-indicator bg-success\"></div>\r\n                </div>\r\n                <div class=\"font-weight-bold\">\r\n                    <div class=\"text-truncate\" style=\"font-size:12px;\">");
#nullable restore
#line 40 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\Shared\Components\TeslimTarihiYaklasan\Default.cshtml"
                                                                  Write(teslim.KitapAdı);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Kitabın Teslim Tarihi Yaklaşıyor</div>\r\n                    <div class=\"small text-gray-500\" style=\"font-size:11px;\"><b>Teslim Tarihi: </b>");
#nullable restore
#line 41 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\Shared\Components\TeslimTarihiYaklasan\Default.cshtml"
                                                                                              Write(teslim.TeslimTarihi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </div>\r\n            </a>\r\n");
#nullable restore
#line 44 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\Shared\Components\TeslimTarihiYaklasan\Default.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a class=\"dropdown-item text-center small text-gray-500\" href=\"#\"><marquee>Teslim Tarihi Yaklasan Kitaplar</marquee></a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KütüphaneUygulaması.ViewModel.TeslimTarihiAlertViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
