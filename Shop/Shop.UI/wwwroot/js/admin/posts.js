Vue.config.devtools = true;
var newPost = false;
var app = new Vue({
    el: '#app',
    data: {

        editing: false,
        loading: false,
        selectedPost: null,
        resid: 0,
        objectIndex: 0,
        postModel: {
            id: 0,
            title: " ",
            description: " ",
            body: " ",
            image: '',
            category: " ",
            tags: " ",
            created: '',
            isActive: false,
            imageAdded: "",
            stillImage: "",
        },
        imageurl: "",
        mfile: '',
        quill: "",
        text: "",
        posts: [],

    },

    mounted() {
    this.getPosts();
},
    methods: {

        onFileChange(e) {
            var files = e.target.files[0];
            mfile = files;
            if (!files.length)
                return;
            this.createImage(files[0]);
        },
        createImage(file) {
            var imageurl = new Image(200, 300);
            var reader = new FileReader();
            var vm = this;

            reader.onload = (e) => {
                vm.imageurl = e.target.result;
            };
            reader.readAsDataURL(file);
        },
        removeImage: function (e) {
            this.imageurl = '';
        },

        getPost(id) {
            this.loading = true;
            var post
            axios.get('/posts/' + id)
                .then(res => {
                    console.log(res);
                    post = res.data;
                    this.postModel = {
                        id: post.id,
                        title: post.title,
                        description: post.description,
                        body: post.body,
                        image: post.image,
                        category: post.category,
                        tags: post.tags,
                        isActive: post.isActive,
                        created: post.created,
                    };
                })
                .catch(err => {
                    console.log(err);
                }).then(() => {

                    var json = JSON.parse(post.body);
                    this.quillEditor(json);

                });
        },

            quillEditor(json) {
                var toolbarOptions = [
                    ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
                    ['blockquote', 'code-block'],

                    [{ 'header': 1 }, { 'header': 2 }],               // custom button values
                    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                    [{ 'script': 'sub' }, { 'script': 'super' }, 'image', 'video'],      // superscript/subscript
                    [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
                    [{ 'direction': 'rtl' }],                         // text direction

                    [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
                    [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

                    [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
                    [{ 'font': [] }],
                    [{ 'align': [] }],

                    ['clean']                                         // remove formatting button
                ];
                quill = new Quill('#editor', {
                    modules: {
                        toolbar: toolbarOptions
                    },
                    scrollingContainer: '#scrolling-container',
                    placeholder: 'Описание товара',
                    theme: 'snow'
                });
                quill.updateContents(json);

        },

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
                    if (newPost == true) {
                        this.editPost(resid, this.posts.length - 1)
                        this.selectPost(this.posts[this.posts.length - 1]);
                    }
                    this.loading = false;
                });
        },

        editPost(id, index) {
            this.objectIndex = index;
            this.getPost(id);
            this.editing = true;
            document.getElementById("descr").classList.remove("hidden");
        },
        newPost() {
            this.editing = true;
            this.postModel.id = 0;
            document.getElementById("descr").classList.remove("hidden");
            this.quillEditor();
        },
        cancel() {
            this.editing = false;
            document.getElementById("descr").classList.add("hidden")
        },

        selectPost(post) {
            console.log(post);
            this.selectedPost = post;
            console.log(this.selectedPost);
        },

        createPost() {

            this.loading = true;
            var formData = new FormData();
            var json = JSON.stringify(quill.getContents(0, quill.getLength()));
            formData.append('request.id', this.postModel.id);
            formData.append('request.title', this.postModel.title);
            formData.append('request.description', this.postModel.description);
            formData.append('request.body', json);
            formData.append('request.category', this.postModel.category);
            formData.append('request.tags', this.postModel.tags);
            formData.append('request.isActive', this.postModel.isActive);

            if (typeof mfile === 'undefined') {
                this.postModel.imageAdded = 'not';
            }
            else {
                this.postModel.imageAdded = '';
                formData.append('request.image', mfile);
            }
            formData.append('request.imageAdded', this.postModel.imageAdded);
            axios.post('/posts', formData)
                .then(res => {
                    console.log(res.data);
                    this.posts.push(res.data);
                    toastr["success"]("Пост добавлен")
                    window.location.reload();
                })
                .catch(err => {
                    console.log(err);
                });
        },
        updatePost() {
            this.loading = true;
            var formData = new FormData();
            var json = JSON.stringify(quill.getContents(0, quill.getLength()));
            formData.append('request.id', this.postModel.id);
            formData.append('request.title', this.postModel.title);
            formData.append('request.description', this.postModel.description);
            formData.append('request.body', json);
            formData.append('request.category', this.postModel.category);
            formData.append('request.tags', this.postModel.tags);
            formData.append('request.isActive', this.postModel.isActive);

            if (typeof mfile === 'undefined') {
                this.postModel.imageAdded = 'not';
                formData.append('request.stillImage', this.selectedPost.image);
            }
            else {
                this.postModel.imageAdded = '';
                formData.append('request.image', mfile);
            }
            formData.append('request.imageAdded', this.postModel.imageAdded);

            axios.put('/posts', formData)
                .then(res => {
                    console.log(res.data);
                    this.posts.splice(this.objectIndex, 1, res.data);

                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    toastr["success"]("Пост обновлён")
                    this.loading = false;
                });
        },

        deletePost(id, index) {
            this.loading = true;
            axios.delete('/posts/' + id)
                .then(res => {
                    console.log(res);
                    this.posts.splice(index, 1);
                    toastr["info"]("Пост удалён")
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },



    }

})