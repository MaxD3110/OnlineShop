#pragma checksum "A:\OnlineShop\Shop\Shop.UI\Pages\Checkout\Payment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a0cda7ed9550b02a58041d0013738b754642570"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Shop.UI.Pages.Checkout.Pages_Checkout_Payment), @"mvc.1.0.razor-page", @"/Pages/Checkout/Payment.cshtml")]
namespace Shop.UI.Pages.Checkout
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a0cda7ed9550b02a58041d0013738b754642570", @"/Pages/Checkout/Payment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29e0c920645c7bc6af12b05eaabdc8fb9fc041bf", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Checkout_Payment : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("payment-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("justify-content:center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    .paymentform {
        min-height: 450px;
        margin: 20px auto;
        visibility: hidden;
        opacity: 0;
        transition: visibility 0s, opacity 0.5s linear 0.5s;
        display: flex;
        align-items: center;
        justify-content: center;
        height: 100%;
        max-width: 500px;
        align-self: center;
        box-shadow: 0px 0px 0px 0.5px rgba(50, 50, 93, 0.1), 0px 2px 5px 0px rgba(50, 50, 93, 0.1), 0px 1px 1.5px 0px rgba(0, 0, 0, 0.07);
        border-radius: 7px;
        padding: 40px;
        margin: 20px auto;
    }

    .formSign {
        border: 1px solid #ebebeb;
        max-width: 550px;
        max-height: 400px;
        position: relative;
        top: 50%;
        left: 50%;
        padding: 60px;
        margin-top: 300px;
        transform: translate(-50%, -50%);
    }
</style>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a0cda7ed9550b02a58041d0013738b7546425705084", async() => {
                WriteLiteral(@"
    <div class=""formSign"">
        <h4 style=""text-align: center"">?????????????? ????????????</h4>
        <div id=""card-element"" style=""width: 30em; padding-top: 3.6rem"">
            <!-- A Stripe Element will be inserted here. -->
        </div>
        <!-- Used to display form errors. -->
        <div id=""card-errors"" role=""alert""></div>

        <div class=""form-footer"" style=""padding-top: 5.6rem"">
            <button type=""submit"" class=""btn btn-outline-primary-2"" name=""name"">
                <span>????????????????</span>
                <i class=""icon-long-arrow-right""></i>
            </button>
        </div><!-- End .form-footer -->
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n    <script src=\"https://js.stripe.com/v3/\"></script>\r\n    <script>\r\n        // A reference to Stripe.js initialized with a fake API key.\r\n        var stripe = Stripe(\'");
#nullable restore
#line 66 "A:\OnlineShop\Shop\Shop.UI\Pages\Checkout\Payment.cshtml"
                        Write(Model.PublicKey);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');

        // Create an instance of Elements.
        var elements = stripe.elements();
        // Custom styling can be passed to options when creating an Element.
        // (Note that this d???mo uses a wider set of styles than the guide below.)
        var style = {
            base: {
                color: '#32325d',
                lineHeight: '18px',
                fontFamily: '""Helvetica Neue"", Helvetica, sans-serif',
    fontSmoothing: 'antialiased',
            fontSize: '16px',
            '::placeholder': {
                color: '#aab7c4'
            }
        },
            invalid: {
                color: '#fa755a',
                iconcolor: '#fa755a'
            }
        };

        // Create an instance of the card Element.
        var card = elements.create('card', {style: style});
        // Add an instance of the card Element into the card-element <div>.
        card.mount('#card-element');
        // Handle real-time validation errors from the card Element.");
                WriteLiteral(@"
        card.addEventListener('change', function (event) {
            var displayError = document.getElementById('card-errors');
            if (event.error) {
                displayError.textContent = event.error.message;
            } else {
                displayError.textContent = '';
            }
            });
        // Handle form submission.
        var form = document.getElementById('payment-form');
        form.addEventListener('submit', function (event) {
            event.preventDefault();

            stripe.createToken(card).then(function (result) {
                if (result.error) {
                    // Inform the user if there was an error.
                    var errorElement = document.getElementById('card-errors');
   errorElement.textContent = result.error.message;
                } else {

                    // Send the token to your server.
                    stripeTokenHandler(result.token);
                }
            });
        });
        // S");
                WriteLiteral(@"ubmit the form with the token ID.
        function stripeTokenHandler(token) {
            // Insert the token ID into the form so it gets submitted to the server
            var form = document.getElementById('payment-form');
            var hiddenInput = document.createElement('input');
            hiddenInput.setAttribute('type', 'hidden');
            hiddenInput.setAttribute('name', 'stripeToken');
            hiddenInput.setAttribute('value', token.id);
            form.appendChild(hiddenInput);
            // Submit the form

            form.submit();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Shop.UI.Pages.Checkout.PaymentModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Shop.UI.Pages.Checkout.PaymentModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Shop.UI.Pages.Checkout.PaymentModel>)PageContext?.ViewData;
        public Shop.UI.Pages.Checkout.PaymentModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
