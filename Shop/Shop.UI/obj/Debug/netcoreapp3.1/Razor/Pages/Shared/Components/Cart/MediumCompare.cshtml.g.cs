#pragma checksum "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08962803fd5e106ba0e2ef6c395bd7fd61a2f289"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Shop.UI.Pages.Shared.Components.Cart.Pages_Shared_Components_Cart_MediumCompare), @"mvc.1.0.view", @"/Pages/Shared/Components/Cart/MediumCompare.cshtml")]
namespace Shop.UI.Pages.Shared.Components.Cart
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
#line 1 "A:\OnlineShop\Shop\Shop.UI\Pages\_ViewImports.cshtml"
using Shop.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "A:\OnlineShop\Shop\Shop.UI\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08962803fd5e106ba0e2ef6c395bd7fd61a2f289", @"/Pages/Shared/Components/Cart/MediumCompare.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29e0c920645c7bc6af12b05eaabdc8fb9fc041bf", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_Cart_MediumCompare : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Shop.Application.Compare.GetCompare.Response>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"dropdown cart-dropdown\" id=\"compare-med\">\r\n    <a class=\"dropdown-toggle\" role=\"button\" ");
            WriteLiteral(" aria-haspopup=\"true\" aria-expanded=\"false\" data-display=\"static\" href=\"/Compare\">\r\n        <div class=\"icon\">\r\n            <i class=\"icon-random\"></i>\r\n");
#nullable restore
#line 9 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
             if (Model.Count() > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"cart-count\">");
#nullable restore
#line 11 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
                                    Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 12 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <p>Сравнение</p>\r\n    </a>\r\n\r\n");
#nullable restore
#line 17 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
     if (Model.Count() > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"dropdown-menu dropdown-menu-right\">\r\n\r\n                <ul class=\"compare-products\">\r\n");
#nullable restore
#line 22 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
                     foreach (var product in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"compare-product\" data-stockid=\"");
#nullable restore
#line 24 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
                                                             Write(product.StockId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <a href=\"#\" class=\"btn-remove\"");
            BeginWriteAttribute("onclick", " onclick=\"", 901, "\"", 946, 3);
            WriteAttributeValue("", 911, "removeFromCompare(", 911, 18, true);
#nullable restore
#line 25 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
WriteAttributeValue("", 929, product.StockId, 929, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 945, ")", 945, 1, true);
            EndWriteAttribute();
            WriteLiteral(" title=\"Удалить\"><i class=\"icon-close\"></i></a>\r\n                            <h4 class=\"compare-product-title\"><a");
            BeginWriteAttribute("href", " href=\"", 1060, "\"", 1106, 2);
            WriteAttributeValue("", 1067, "Product/", 1067, 8, true);
#nullable restore
#line 26 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
WriteAttributeValue("", 1075, product.Name.Replace(" ", "-"), 1075, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 26 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
                                                                                                           Write(product.ProductDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 26 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
                                                                                                                                       Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 26 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
                                                                                                                                                      Write(product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</a></h4>\r\n                        </li>\r\n");
#nullable restore
#line 28 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n");
            WriteLiteral(@"

            <div class=""compare-actions"">
                <a class=""action-link"" onclick=""removeAllFromCompare()"">Очистить</a>
                <a href=""/Compare"" class=""btn btn-outline-primary-2""><span>Сравнить</span><i class=""icon-long-arrow-right""></i></a>
            </div><!-- End .dropdown-cart-total -->

            </div><!-- End .cart-product -->
");
#nullable restore
#line 45 "A:\OnlineShop\Shop\Shop.UI\Pages\Shared\Components\Cart\MediumCompare.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<script>

    var addOneToCompare = function (e) {
        var stockId = e.target.dataset.stockId;
        axios.post(""/Compare/AddOneCompare/"" + stockId)
            .then(res => {
                updateCompare();
            }).catch(err => {
                alert(err.error);
            })
    }

    var removeOneFromCompare = function (e) {
        var stockId = e.target.dataset.stockId;
        removeFromCompare(stockId);
    }

    var removeAllFromCompare = function () {
        var doc = document.getElementsByClassName(""compare-product"");
        var count = document.getElementsByClassName(""compare-product"").length;
        for (var i = 0; i < count; i++) {

            console.log(doc.length);
            stockId = doc[i].getAttribute(""data-stockid"");
            console.log(stockId);
            axios.post(""/Compare/RemoveCompare/"" + stockId)
            updateCompare();
        }
        updateCompare();
    }

    var removeFromCompare = function (stockId) ");
            WriteLiteral(@"{
        axios.post(""/Compare/RemoveCompare/"" + stockId)
            .then(res => {
                updateCompare();
            }).catch(err => {
                alert(err.error);
            })
    }

    var updateCompare = function () {
        axios.get('/Compare/GetCompareMedium')
            .then(res => {
                var html = res.data;
                var el = document.getElementById('compare-med');

                el.outerHTML = html;
            });
        axios.get('/Compare/GetCompareMain')
            .then(res => {
                var html = res.data;
                var el = document.getElementById('compare-main');

                el.outerHTML = html;
            })

    }

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Shop.Application.Compare.GetCompare.Response>> Html { get; private set; }
    }
}
#pragma warning restore 1591