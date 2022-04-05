Vue.config.devtools = true
var total = 0;
var app = new Vue({
    el: '#app',
    data: {
        status: 0,
        loading: false,
        orders: [],
        selectedOrder: null,
    },
    mounted() {
        this.getOrders();
    },

    watch: {
        status: function () {
            this.getOrders();
        }
    },

    methods: {
        getOrders() {
            this.loading = true;
            axios.get('/orders?status=' + this.status)
                .then(result => {
                    this.orders = result.data;
                    this.loading = false;
                });

        },
        selectOrder(id) {
            this.loading = true;
            axios.get('/orders/' + id)
                .then(result => {
                    this.selectedOrder = result.data;
                    for (var i = 0; i < this.selectedOrder.products.length; i++) {
                        total = total + this.selectedOrder.products[i].totalValue;
                    };
                    this.loading = false;
                }).then(() =>{
                    document.getElementById("total").innerHTML = "Общая цена заказа: " + total + " рублей";
            });
        },
        decreaseOrderMain(id) {
            this.loading = true;
            axios.put('/orders/' + id)
                .then(result => {
                    this.loading = false;
                    this.exitOrder();
                    this.getOrders();
                });
        },
        updateOrderMain(id) {
            this.loading = true;
            axios.put('/orders/' + id)
                .then(result => {
                    this.loading = false;
                    this.exitOrder();
                    this.getOrders();
                    toastr["success"]("Статус заказа повышен")
                });
        },
        decreaseOrder() {
            this.loading = true;
            axios.put('/orders/' + this.selectedOrder.id, null)
                .then(result => {
                    this.loading = false;
                    this.exitOrder();
                    this.getOrders();
                });
        },
        updateOrder() {
            this.loading = true;
            axios.put('/orders/' + this.selectedOrder.id, null)
                .then(result => {
                    this.loading = false;
                    this.exitOrder();
                    this.getOrders();
                    toastr["success"]("Статус заказа повышен")
                });
        },
            exitOrder() {
                this.selectedOrder = null;
                total = 0;
            }
    },
    computed: {
    }
});