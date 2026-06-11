Vue.config.devtools = true;
var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        selectedProduct: null,
        selectedStock: null,
        productCounter: 0,
        products: [],
        stocks: [],
    },
    mounted() {
        this.getProducts();
    },
    methods: {
        async getProducts() {
            this.loading = true;
            try {
                this.products = await http.get('/products');
            } catch (err) {
                console.log(err);
            }
            this.getItems();
        },

        getItems() {
            window.addEventListener("load", function () {
                this.loading = false;
            });
        },

        changeOptions(indexStock, index) {
            const stock = this.selectedProduct.stock[indexStock];

            if (stock.isOnSale > 0) {
                document.getElementsByName("mainValue")[index].setAttribute("hidden", "hidden");
                document.getElementsByClassName("new-price")[index].removeAttribute("hidden", "hidden");
                document.getElementsByClassName("old-price")[index].removeAttribute("hidden", "hidden");
                document.getElementsByClassName("new-price")[index].innerHTML = (stock.value - (stock.value * (stock.isOnSale / 100))).toFixed(2) + " р."
                document.getElementsByClassName("old-price")[index].innerHTML = "<s>" + stock.value + " р.</s>";
            } else {
                document.getElementsByName("mainValue")[index].innerHTML = stock.value + " р.";
                document.getElementsByName("mainValue")[index].removeAttribute("hidden", "hidden");
                document.getElementsByClassName("new-price")[index].setAttribute("hidden", "hidden");
                document.getElementsByClassName("old-price")[index].setAttribute("hidden", "hidden");
            }
            this.stocks[index] = stock;
            document.getElementsByClassName("product-image shop")[index].setAttribute("src", "/images/productsfolder/" + stock.propImage);
        },

        async addOneToWish() {
            try {
                await http.post("/Wish/AddOneWish/" + this.selectedStock.id);
                const html = await http.get('/Wish/GetWishComponent');
                document.getElementById('wish-nav').outerHTML = html;
                toastr["success"]("Товар добавлен в избранные");
            } catch (err) {
                alert(err.error);
            }
        },
        async addOneToCompare() {
            try {
                await http.post("/Compare/AddOneCompare/" + (this.selectedStock.id + "," + this.selectedProduct.specification[0].id));
                const html = await http.get('/Compare/GetCompareMedium');
                document.getElementById('compare-med').outerHTML = html;
                toastr["success"]("Товар добавлен к сравнению");
            } catch (err) {
                alert(err.error);
            }
        },
        async addOneToCart() {
            try {
                await http.post("/Cart/AddOne/" + this.selectedStock.id);
                const html = await http.get('/Cart/GetCartMedium');
                document.getElementById('cart-med').outerHTML = html;
                toastr["success"]("Товар добавлен в корзину");
            } catch (err) {
                toastr["error"]("Товара нет на складе");
            }
        },

        selectProduct(product, index) {
            this.selectedProduct = product;
            this.selectedStock = this.stocks[index];
        },

        selectStock(stock, index) {
            this.stocks[index] = stock;
        },

        activeIndicate(product) {
            return (product.category === "POD" || product.category === "MOD" || product.category === "Vape") && product.stock.length > 1;
        },

        returnLink(name) {
            return "/Product/" + name.replaceAll(" ", "-");
        },

        saleLabel(product, index) {
            let indicator = false;
            for (let i = 0; i < product.stock.length; i++) {
                if (product.stock[i].isOnSale > 0) {
                    indicator = true;
                    this.stocks[index] = product.stock[i];
                    break;
                } else {
                    this.stocks[index] = product.stock[0];
                    indicator = false;
                }
            }
            return indicator;
        },
        newValue(index) {
            const stock = this.stocks[index];
            return (stock.value - (stock.value * (stock.isOnSale) / 100)).toFixed(2);
        },
    },

    computed: {}
});
