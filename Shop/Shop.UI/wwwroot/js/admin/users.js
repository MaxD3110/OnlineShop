Vue.config.devtools = true;
var app = new Vue({
    el: '#app',
    data: {
        editing: false,
        username: "",
        password: "",
        users: [],
        isAdmin: false,
        role: '',
    },
    mounted() {
        this.getUsers();
    },
    methods: {

        async createUser() {
            this.loading = true;
            this.role = this.isAdmin === true ? 'Admin' : 'Manager';

            try {
                await http.post('/users', { username: this.username, password: this.password, role: this.role });
                toastr["success"]("Аккаунт создан");
            } catch (err) {
                console.log(err);
            }
        },
        async getUsers() {
            this.loading = true;
            try {
                this.users = await http.get('/users');
            } catch (err) {
                console.log(err);
            }
        },

        async deleteUser(id, index) {
            this.loading = true;
            try {
                await http.post('/users/' + id);
                this.users.splice(index, 1);
                toastr["info"]("Аккаунт удален");
            } catch (err) {
                console.log(err);
            }
            this.loading = false;
        },

        newAccount() {
            this.editing = true;
        },

        cancel() {
            this.editing = false;
        },
    }
})
