#pragma checksum "A:\OnlineShop\Shop\Shop.UI\Pages\Compare.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce51b0d340d5b7f7552086013b00321420da05a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Shop.UI.Pages.Pages_Compare), @"mvc.1.0.razor-page", @"/Pages/Compare.cshtml")]
namespace Shop.UI.Pages
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce51b0d340d5b7f7552086013b00321420da05a9", @"/Pages/Compare.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29e0c920645c7bc6af12b05eaabdc8fb9fc041bf", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Compare : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ComparePartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "A:\OnlineShop\Shop\Shop.UI\Pages\Compare.cshtml"
  
    ViewData["Title"] = "Сравнение";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .table th {
        
        border-bottom: 2px solid;
        border-left: 1px solid;
        border-color: #ebebeb;
    }
    .table td {
        border-left: 1px solid;
        border-color: #ebebeb;
    }
    .table td:nth-child(1) {
        text-align: left;
        border-left: none;
    }
</style>


<div class=""page-header text-center"" style=""background-image: url('/images/page-header-bg.jpg')"">
    <div class=""container"">
        <h1 class=""page-title"">Сравнение товаров</h1>
    </div><!-- End .container -->
</div><!-- End .page-header -->
<nav aria-label=""breadcrumb"" class=""breadcrumb-nav"">
    <div class=""container"">
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce51b0d340d5b7f7552086013b00321420da05a94947", async() => {
                WriteLiteral("Главная");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce51b0d340d5b7f7552086013b00321420da05a96148", async() => {
                WriteLiteral("Магазин");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li class=\"breadcrumb-item active\" aria-current=\"page\">Сравнение</li>\r\n        </ol>\r\n    </div><!-- End .container -->\r\n</nav><!-- End .breadcrumb-nav -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ce51b0d340d5b7f7552086013b00321420da05a97488", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 39 "A:\OnlineShop\Shop\Shop.UI\Pages\Compare.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.Compare;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <script src=""https://unpkg.com/axios/dist/axios.min.js""></script>


    <script>
        var products = [];

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
            var doc = document.getElementsByClassName(""icon-close"");
            var count = document.getElementsByClassName(""icon-close"").length;
            for (var i = 0; i < count; i++) {

                console.log(doc.length);
                stockId = doc[i].getAttribute(""data-stockid"");
                console.log(stockId);
             ");
                WriteLiteral(@"   axios.post(""/Compare/RemoveCompare/"" + stockId)

            updateCompare();
            }
            updateCompare();
        }

        var removeFromCompare = function (stockId) {
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
                    window.location.reload();
  ");
                WriteLiteral("              })\r\n\r\n        }\r\n\r\n        window.onload = function () {\r\n\r\n            updateTable(JSON.stringify(");
#nullable restore
#line 113 "A:\OnlineShop\Shop\Shop.UI\Pages\Compare.cshtml"
                                  Write(Json.Serialize(Model.Compare));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"));
        }

        function updateTable(product) {

            document.getElementById('getObject').value = product;
            var newstringreplaced = product.replace(/},{/gi, ""}%%%,{"");
            products = JSON.parse(newstringreplaced.split(""%%%,""));

            console.log(products);
            for (var i = 0; i < products.length; i++) {
                console.log(products[i]);
            }
            console.log('log');

            var table = document.getElementById(""specTable"");
            var result = [];
            for (var a = 0; a < products.length; a++) {

                result[a] = Object.values(products[a]);

                console.log(result[a]);
            }

            var info = [
                'id',
                'Емкость аккумулятора',
                'Дисплей',
                'Встроенный аккумулятор',
                'Максимальная мощность',
                'Регулировка мощности',
                'Объем бака',
                'Колич");
                WriteLiteral(@"ество затяжек',
                'Вкус',
                'VG/PG',
                'Тип никотина',
                'Крепость жидкости',
                'Объем',
                'MTL',
                'Количество спиралей',
                'Обдув',
                'Тип',
                'Напряжение',
                'Длина',
                'Высота',
                'Ширина',
                'Вес',
                'Время зарядки',

            ];

            console.log(result);
            if (products.length > 0) {

                let arr = [];

                for (var i = 0; i < products.length; i++) {
                    arr[i] = [i];

                    var p = 0;
                    var trash = 0;
                    for (let val of result[i]) {
                        if (trash > 9) {

                            arr[i][p] = val;
                            p++;

                        }
                        trash++;
                    }
                }

");
                WriteLiteral(@"            var counter = 0;
                var empty = 0;
                var p = 0;
                for (var i = 0; i < result[0].length; i++) {

                    if (i > 9) {


                        counter++;
                        let row = table.insertRow();
                        let caption = row.insertCell(0);
                        caption.innerHTML = ""<b>"" + info[counter] + ""</b>"";

                        var emptyCount = 0;

                        for (var a = 0; a < products.length; a++) {
                            let value = row.insertCell(a + 1);
                            value.innerHTML = arr[a][p];

                            if (value.innerHTML === "" "") {

                                value.innerHTML = ""Не указано""
                                emptyCount++;
                            }
                        }
                        if (emptyCount == products.length) {

                            table.deleteRow((i - 9) - empty);
       ");
                WriteLiteral("                     empty++;\r\n\r\n                        }\r\n\r\n                        p++;\r\n                    }\r\n                }\r\n                }\r\n\r\n\r\n        }\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Shop.UI.Pages.CompareModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Shop.UI.Pages.CompareModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Shop.UI.Pages.CompareModel>)PageContext?.ViewData;
        public Shop.UI.Pages.CompareModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591