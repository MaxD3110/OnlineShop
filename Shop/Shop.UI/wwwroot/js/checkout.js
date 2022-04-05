let elements;

var mainElement = document.getElementById('main');
var pError = document.getElementById('pError');
var pPaymentIntent = document.getElementById('pPaymentIntent');

const clientSecret = new URLSearchParams(window.location.search).get(
    "payment_intent_client_secret"
);
if (clientSecret) {
    checkStatus();
}
else {
    initialize();
}

document.querySelector("form").addEventListener("submit", handleSubmit);

// Fetches a payment intent and captures the client secret
async function initialize() {
    const response = await fetch("Methods/PaymentIntentCreateHandler.ashx", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(
            {
                "Amount": Amount,
                "Currency": Currency,
                "Description": Description,
            }),
    });
    const { clientSecret } = await response.json();

    const appearance = {
        theme: 'stripe',
    };
    elements = stripe.elements({ appearance, clientSecret });

    const paymentElement = elements.create("payment");
    paymentElement.mount("#payment-element");

    setTimeout(function () {
        mainElement.className = "payment";
    }, 1500);
}

async function handleSubmit(e) {
    e.preventDefault();
    setLoading(true);

    const { error } = await stripe.confirmPayment({
        elements,
        confirmParams: {
            // Make sure to change this to your payment completion page
            return_url: window.location.href,
        },
    });

    // This point will only be reached if there is an immediate error when
    // confirming the payment. Otherwise, your customer will be redirected to
    // your `return_url`. For some payment methods like iDEAL, your customer will
    // be redirected to an intermediate site first to authorize the payment, then
    // redirected to the `return_url`.
    if (error.type === "validation_error") { }
    else if (error.type === "card_error") {
        pError.innerHTML = error.message;
        mainElement.className = "error";
    } else {
        pError.innerHTML = "An unexpected error occured.";
        mainElement.className = "error";
    }

    setLoading(false);
}

// Fetches the payment intent status after payment submission
async function checkStatus() {
    const { paymentIntent } = await stripe.retrievePaymentIntent(clientSecret);
    switch (paymentIntent.status) {
        case "succeeded":
            pPaymentIntent.innerHTML = "Payment Intent: " + paymentIntent.id;
            mainElement.className = "success";
            break;
        case "processing":
            mainElement.className = "processing";
            setTimeout(function () { checkStatus() }, 1000);
            break;
        case "requires_payment_method":
            pError.innerHTML = "Your payment was not successful, please try again.";
            mainElement.className = "error";
            break;
        default:
            pError.innerHTML = "Something went wrong.";
            mainElement.className = "error";
            break;
    }
}

// ------- UI helpers -------
function formatPrice(amount, currency) {
    let price = (amount / 100).toFixed(2);
    let numberFormat = new Intl.NumberFormat(['en-US'], {
        style: 'currency',
        currency: currency,
        currencyDisplay: 'symbol',
    });
    return numberFormat.format(price);
}
var AmountFormated = formatPrice(Amount, Currency);
document.getElementById('button-text').innerHTML = 'Pay Now ' + AmountFormated;

// Show a spinner on payment submission
function setLoading(isLoading) {
    if (isLoading) {
        // Disable the button and show a spinner
        document.querySelector("#submit").disabled = true;
        document.querySelector("#spinner").classList.remove("hidden");
        document.querySelector("#button-text").classList.add("hidden");
    } else {
        document.querySelector("#submit").disabled = false;
        document.querySelector("#spinner").classList.add("hidden");
        document.querySelector("#button-text").classList.remove("hidden");
    }
}