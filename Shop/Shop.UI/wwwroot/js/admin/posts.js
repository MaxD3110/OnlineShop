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
            const files = e.target.files[0];
            mfile = files;
            if (!files.length)
                return;
            this.createImage(files[0]);
        },
        createImage(file) {
            const reader = new FileReader();
            const vm = this;
            reader.onload = (e) => {
                vm.imageurl = e.target.result;
            };
            reader.readAsDataURL(file);
        },
        removeImage() {
            this.imageurl = '';
        },

        async getPost(id) {
            this.loading = true;
            let post;
            try {
                post = await http.get('/posts/' + id);
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
            } catch (err) {
                console.log(err);
            }

            const json = JSON.parse(post.body);
            this.quillEditor(json);
        },

        quillEditor(json) {
            const toolbarOptions = [
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

        async getPosts() {
            this.loading = true;
            try {
                this.posts = await http.get('/posts');
            } catch (err) {
                console.log(err);
            }
            if (newPost == true) {
                this.editPost(resid, this.posts.length - 1);
                this.selectPost(this.posts[this.posts.length - 1]);
            }
            this.loading = false;
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
            document.getElementById("descr").classList.add("hidden");
        },

        selectPost(post) {
            this.selectedPost = post;
        },

        async createPost() {
            this.loading = true;
            const formData = new FormData();
            const json = JSON.stringify(quill.getContents(0, quill.getLength()));
            formData.append('request.id', this.postModel.id);
            formData.append('request.title', this.postModel.title);
            formData.append('request.description', this.postModel.description);
            formData.append('request.body', json);
            formData.append('request.category', this.postModel.category);
            formData.append('request.tags', this.postModel.tags);
            formData.append('request.isActive', this.postModel.isActive);

            if (typeof mfile === 'undefined') {
                this.postModel.imageAdded = 'not';
            } else {
                this.postModel.imageAdded = '';
                formData.append('request.image', mfile);
            }
            formData.append('request.imageAdded', this.postModel.imageAdded);

            try {
                const post = await http.post('/posts', formData);
                this.posts.push(post);
                toastr["success"]("Пост добавлен");
                window.location.reload();
            } catch (err) {
                console.log(err);
            }
        },
        async updatePost() {
            this.loading = true;
            const formData = new FormData();
            const json = JSON.stringify(quill.getContents(0, quill.getLength()));
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
            } else {
                this.postModel.imageAdded = '';
                formData.append('request.image', mfile);
            }
            formData.append('request.imageAdded', this.postModel.imageAdded);

            try {
                const post = await http.put('/posts', formData);
                this.posts.splice(this.objectIndex, 1, post);
            } catch (err) {
                console.log(err);
            }
            toastr["success"]("Пост обновлён");
            this.loading = false;
        },

        async deletePost(id, index) {
            this.loading = true;
            try {
                await http.delete('/posts/' + id);
                this.posts.splice(index, 1);
                toastr["info"]("Пост удалён");
            } catch (err) {
                console.log(err);
            }
            this.loading = false;
        },
    }
})
