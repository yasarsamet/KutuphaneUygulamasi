#pragma checksum "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1c1f9ecb0ce6bde6259c6f818a86f7e01fd13b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KitapAl_Index), @"mvc.1.0.view", @"/Views/KitapAl/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1c1f9ecb0ce6bde6259c6f818a86f7e01fd13b6", @"/Views/KitapAl/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"872821a2e2a8dff834ea1df82fe8a5f94b7377a8", @"/Views/_ViewImports.cshtml")]
    public class Views_KitapAl_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KütüphaneUygulaması.ViewModel.KitapListesiViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
  
    List<int> OdüncKitapId = new List<int>();
    foreach (var id in Model.OdüncAlListesi)
    {
        OdüncKitapId.Add(id.KitabId);
    }
    List<int> RezervasyonListesiId = new List<int>();
    foreach (var rezervasyon in Model.RezervasyonListesi)
    {
        if (rezervasyon.IsDeleted==false)
        {
            RezervasyonListesiId.Add(rezervasyon.KitabId);
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>

<div class=""container-fluid"">
    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">Kitap Listesi</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>Kitap Adı</th>
                            <th>Kitap Sayfası</th>
                            <th>Kitap Türü</th>
                            <th>Kitap basım tarihi</th>
                            <th>Kitap Yazarı</th>
                            <th>Detay</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 38 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                         foreach (var kitap in Model.Kitaplistesi)
                        {
                            if (OdüncKitapId.Contains(kitap.Id) == false && RezervasyonListesiId.Contains(kitap.Id) == false)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 43 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                   Write(kitap.KitapAdı);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 44 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                   Write(kitap.KitapSayfası);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 45 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                   Write(kitap.KitapTürü);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 46 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                     foreach (var kitapyazar in Model.KitapYazarListesi)
                                    {
                                        if (kitap.Id == kitapyazar.KitapId)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>");
#nullable restore
#line 50 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                           Write(kitapyazar.KitapBasımTarihi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 51 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                     foreach (var yazar in Model.Yazarlistesi)
                                    {
                                        foreach (var kitapyazar in Model.KitapYazarListesi)
                                        {
                                            if (kitap.Id == kitapyazar.KitapId && yazar.id == kitapyazar.YazarId)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td>");
#nullable restore
#line 59 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                               Write(yazar.Adi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <p>");
#nullable restore
#line 59 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                                             Write(yazar.Soyadi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\r\n");
#nullable restore
#line 60 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                            }
                                        }
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                     foreach (var raf in Model.RafListesi)
                                    {
                                        if (raf.Id == kitap.RafId)
                                        {
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>\r\n\r\n                                                <a data-toggle=\"modal\" data-target=\"#Assign\" style=\"color:white;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3430, "\"", 3472, 5);
            WriteAttributeValue("", 3440, "deleteCompany(", 3440, 14, true);
#nullable restore
#line 70 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
WriteAttributeValue("", 3454, raf.Id, 3454, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3461, ",", 3461, 1, true);
#nullable restore
#line 70 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
WriteAttributeValue("", 3462, kitap.Id, 3462, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3471, ")", 3471, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary"">
                                                    <span class=""svg-icon svg-icon-md"">                                                        
                                                    </span>Raf Bilgileri
                                                </a>
                                            </td>
");
#nullable restore
#line 75 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tr>\r\n");
#nullable restore
#line 78 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
                            }
                            else
                            {
                                continue;
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<div id=""Assign"" class=""modal fade"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Raf Bilgileri</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <i aria-hidden=""true"" class=""ki ki-close""></i>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""form-group row"">
                    <label class=""col-4 col-form-label"">Raf Baslık</label>
                    <div class=""col-8"">
                        <input id=""RafBaslik"" class=""form-control"" type=""text"" readonly>
                    </div>
                </div>
                <div class=""form-group row"">
        ");
            WriteLiteral(@"            <label class=""col-4 col-form-label"">Raf Numarası</label>
                    <div class=""col-8"">
                        <input id=""RafNumarası"" class=""form-control"" type=""text"" readonly>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label class=""col-4 col-form-label"">Bulunduğu Salon</label>
                    <div class=""col-8"">
                        <input id=""BulunduguSalon"" class=""form-control"" type=""text"" readonly>
                    </div>
                </div>
                <div class=""form-group row"">
                    <label class=""col-4 col-form-label"">Bulunduğu Kat</label>
                    <div class=""col-8"">
                        <input id=""BulunduguKat"" class=""form-control"" type=""text"" readonly>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal");
            WriteLiteral("\">Tamam</button>\r\n                <button type=\"button\" class=\"btn btn-primary\" data-dismiss=\"modal\" onclick=\"asy()\">Ayırt Et</button>\r\n");
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n    var kitapid = 0;\r\n    var rafid = 0;\r\n\r\n    function asy(){\r\n        debugger;\r\n        $.get(\"");
#nullable restore
#line 140 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
          Write(Url.Action("Rezervasyon", "KitapAl"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
            {
                kitapId:kitapid
            },
            function (data) {
                //swal(""Rezervasyon Tamam!"", ""1 Saat içerisinde Kitabı Almadığınız Taktirde Rezervasyon İptal Edilir!"", ""warning"");              
                swal(""1 Saat içerisinde Kitabı Almadığınız Taktirde Rezervasyon İptal Edilir!"", {
                    buttons: {
                        catch: {
                            text: ""Tamam!"",
                            value: ""catch"",
                        },                        
                    },
                })
                    .then((value) => {
                        switch (value) {
                            case ""catch"":
                                location.reload();
                                break;
                            default:
                                location.reload();
                        }
                    });
            });
    }
    function deleteCompany(ide,ktpid) {
   ");
                WriteLiteral("     debugger;\r\n        rafid = ide,\r\n        kitapid = ktpid\r\n        debugger;\r\n         $.get(\"");
#nullable restore
#line 170 "C:\Users\samet\source\repos\KütüphaneUygulaması\KütüphaneUygulaması\Views\KitapAl\Index.cshtml"
           Write(Url.Action("Raf", "KitapAl"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
            { id: rafid },
             function (data) {
                 debugger;
                 $('#RafBaslik').val(data.rafBaslik);
                 $('#RafNumarası').val(data.rafNo);
                 $('#BulunduguSalon').val(data.bulunduguSalon);
                 $('#BulunduguKat').val(data.bulunduguKat);
                });
    }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KütüphaneUygulaması.ViewModel.KitapListesiViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
