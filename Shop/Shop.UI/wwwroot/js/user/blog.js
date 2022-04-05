Vue.config.devtools = true;
var globalIndex = 0;
var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        resid: 0,
        objectIndex: 0,
        postCounter: 0,
        salesCounter: 0,
        newsCounter: 0,
        freshCounter: 0,
        reviewsCounter: 0,
        compilCounter: 0,
        posts: [],
    },
    mounted() {
        this.getPosts();
    },
    methods: {
        getPosts() {
            this.loading = true;
            axios.get('/posts')
                .then(res => {
                    console.log(res);
                    this.posts = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {

                    for (var a = 0; a < this.posts.length; a++) {

                        this.postActive(a); //Проверка на доступ

                    }

                    document.getElementById('everything').innerHTML = this.postCounter;
                    document.getElementById('spanSales').innerHTML = this.salesCounter;
                    document.getElementById('spanFresh').innerHTML = this.freshCounter;
                    document.getElementById('spanNews').innerHTML = this.newsCounter;
                    document.getElementById('spanCompil').innerHTML = this.compilCounter;
                    document.getElementById('spanReviews').innerHTML = this.reviewsCounter;
                    this.loading = false;
                });
        },

        postActive(a) {

            if (this.posts[a].isActive == true) {

                if (this.posts[a].category == 'sales') {
                    this.salesCounter++
                }
                else if (this.posts[a].category == 'news') {
                    this.newsCounter++
                }
                else if (this.posts[a].category == 'fresh') {
                    this.freshCounter++
                }
                else if (this.posts[a].category == 'compil') {
                    this.compilCounter++
                }
                else if (this.posts[a].category == 'reviews') {
                    this.reviewsCounter++
                }
                this.postCounter++;
            }
        },
    },

    computed:
    {

    }
});