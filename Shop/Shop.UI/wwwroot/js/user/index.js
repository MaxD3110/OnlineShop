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
        getProducts() {
            this.loading = true;
            axios.get('/products')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {

                    this.getItems()

                });
        },

        getItems() {
            window.addEventListener("load", function () {
                this.loading = false
               
            })
        },



        changeOptions(indexStock, index) {

            if (this.selectedProduct.stock[indexStock].isOnSale > 0) {

                document.getElementsByName("mainValue")[index].setAttribute("hidden", "hidden");
                document.getElementsByClassName("new-price")[index].removeAttribute("hidden", "hidden");
                document.getElementsByClassName("old-price")[index].removeAttribute("hidden", "hidden");
                document.getElementsByClassName("new-price")[index].innerHTML = (this.selectedProduct.stock[indexStock].value - (this.selectedProduct.stock[indexStock].value * (this.selectedProduct.stock[indexStock].isOnSale / 100))).toFixed(2) + " р."
                document.getElementsByClassName("old-price")[index].innerHTML = "<s>" + this.selectedProduct.stock[indexStock].value + " р.</s>";


            }
            else {

                document.getElementsByName("mainValue")[index].innerHTML = this.selectedProduct.stock[indexStock].value + " р.";
                document.getElementsByName("mainValue")[index].removeAttribute("hidden", "hidden");
                document.getElementsByClassName("new-price")[index].setAttribute("hidden", "hidden");
                document.getElementsByClassName("old-price")[index].setAttribute("hidden", "hidden");

            }
            this.stocks[index] = this.selectedProduct.stock[indexStock];
            console.log(this.stocks[index]);
            document.getElementsByClassName("product-image shop")[index].setAttribute("src", "/images/productsfolder/" + this.selectedProduct.stock[indexStock].propImage);
        },

        getStock() {
            this.loading = true;
            axios.get('/stocks')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        getSpecification() {
            this.loading = true;
            axios.get('/specifications')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                    console.log(res.data.id);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        getReview() {
            this.loading = true;
            axios.get('/reviews')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        addOneToWish() {
            axios.post("/Wish/AddOneWish/" + this.selectedStock.id)
                .then(res => {
                    axios.get('/Wish/GetWishComponent')
                        .then(res => {
                            var html = res.data;
                            var el = document.getElementById('wish-nav');
                            el.outerHTML = html;
                            toastr["success"]("Товар добавлен в избранные")
                        })
                }).catch(err => {
                    alert(err.error);
                })
        },
        addOneToCompare() {
            axios.post("/Compare/AddOneCompare/" + (this.selectedStock.id + "," + this.selectedProduct.specification[0].id))
                .then(res => {
                    axios.get('/Compare/GetCompareMedium')
                        .then(res => {
                            var html = res.data;
                            var el = document.getElementById('compare-med');
                            el.outerHTML = html;
                            toastr["success"]("Товар добавлен к сравнению")
                        });
                }).catch(err => {
                    alert(err.error);
                })
        },
        addOneToCart() {
            axios.post("/Cart/AddOne/" + this.selectedStock.id)
                .then(res => {
                    axios.get('/Cart/GetCartMedium')
                        .then(res => {
                            var html = res.data;
                            var el = document.getElementById('cart-med');
                            el.outerHTML = html;
                            toastr["success"]("Товар добавлен в корзину")
                        });
                }).catch(err => {
                    toastr["error"]("Товара нет на складе")
/*                    alert(err.error);*/
                })
        },

        selectProduct(product, index) {
            this.selectedProduct = product;
            this.selectedStock = this.stocks[index];
        },

        selectStock(stock, index) {
            this.stocks[index] = stock;
        },

        activeIndicate(product) {



            if ((product.category === "POD" || product.category === "MOD" || product.category === "Vape") && product.stock.length > 1) {

                return true;
            }
            else {
                return false;
            }

        },

        returnLink(name) {
            return "/Product/" + name.replaceAll(" ", "-");
        },

        saleLabel(product, index) {


            var indicator = false;

            for (var i = 0; i < product.stock.length; i++)
                if (product.stock[i].isOnSale > 0) {

                    indicator = true;
                    this.stocks[index] = product.stock[i];
                    break;
                }
                else {
                    this.stocks[index] = product.stock[0]
                    indicator = false;
                }

            return indicator;
        },
        newValue(index) {
            console.log(index);
            return (this.stocks[index].value - (this.stocks[index].value * (this.stocks[index].isOnSale) / 100)).toFixed(2);
        },
    },

    computed:
    {
    }
});