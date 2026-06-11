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
        async getOrders() {
            this.loading = true;
            this.orders = await http.get('/orders?status=' + this.status);
            this.loading = false;
        },
        async selectOrder(id) {
            this.loading = true;
            this.selectedOrder = await http.get('/orders/' + id);
            for (let i = 0; i < this.selectedOrder.products.length; i++) {
                total = total + this.selectedOrder.products[i].totalValue;
            }
            this.loading = false;
            document.getElementById("total").innerHTML = "Общая цена заказа: " + total + " рублей";
        },
        async decreaseOrderMain(id) {
            this.loading = true;
            await http.put('/orders/' + id);
            this.loading = false;
            this.exitOrder();
            this.getOrders();
        },
        async updateOrderMain(id) {
            this.loading = true;
            await http.put('/orders/' + id);
            this.loading = false;
            this.exitOrder();
            this.getOrders();
            toastr["success"]("Статус заказа повышен");
        },
        async decreaseOrder() {
            this.loading = true;
            await http.put('/orders/' + this.selectedOrder.id);
            this.loading = false;
            this.exitOrder();
            this.getOrders();
        },
        async updateOrder() {
            this.loading = true;
            await http.put('/orders/' + this.selectedOrder.id);
            this.loading = false;
            this.exitOrder();
            this.getOrders();
            toastr["success"]("Статус заказа повышен");
        },
        exitOrder() {
            this.selectedOrder = null;
            total = 0;
        }
    },
    computed: {}
});
