Vue.config.devtools = true;
var app = new Vue({
    el: '#app',
    data: {

        selectedPost: null,
        
    },


    mounted() {
        this.getQuill();

    },

    methods: {

        getQuill(post) {
            window.addEventListener("load", function () {
                post = JSON.parse(document.getElementById('getPost').value);
                this.selectedPost = post;
                console.log(this.selectedPost);
                var options = {
                    placeholder: 'Waiting for your precious content',
                    theme: 'snow',
                    readOnly: true,
                    modules: {
                        toolbar: false,

                    },
                    formats: ['header', 'font', 'size', 'color',
                        'bold', 'italic', 'underline', 'strike', 'blockquote',
                        'list', 'bullet', 'indent',
                        'link', 'image', 'video',
                        'align']
                };
                var editor = new Quill('#quillEditor', options);
                editor.updateContents(JSON.parse(this.selectedPost.body));
            });
        },
    }

})