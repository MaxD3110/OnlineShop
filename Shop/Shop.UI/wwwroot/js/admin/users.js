Vue.config.devtools = true;
var app = new Vue({
    el: '#app',
    data: {
        editing: false,
        username: "",
        password: "",
        users: [],
        roles: [],
        isAdmin: false,
        role: '',
    },
    mounted() {
        this.getUsers();
        /*this.getRoles();*/
    },
    methods: {

        createUser() {
            this.loading = true;

            if (this.isAdmin === true) {
                this.role = 'Admin'
                console.log('admin');
            }
            else {
                this.role = 'Manager'
            }

            axios.post('/users', { username: this.username, password: this.password, role: this.role })
                .then(res => {
                    console.log(res);
                    toastr["success"]("Аккаунт создан")
                })
                .catch(err => {
                    console.log(err);
                })
        },
        getUsers() {
            this.loading = true;
            axios.get('/users')
                .then(res => {
                    console.log(res);
                    this.users = res.data;
                })
                .catch(err => {
                    console.log(err);
                }).then(() => {

                })
        },
        getRoles() {
            this.loading = true;
           
            axios.get('/roles/' + i)
                .then(res => {
                    console.log(res);
                    this.roles[i] = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
            
        },

        deleteUser(id, index) {
            this.loading = true;
            axios.post('/users/' + id)
                .then(res => {
                    console.log(res);
                    this.users.splice(index, 1);
                    toastr["info"]("Аккаунт удален")
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },

        newAccount() {
            this.editing = true;
        },

        cancel() {
            this.editing = false;
        },
    }
})