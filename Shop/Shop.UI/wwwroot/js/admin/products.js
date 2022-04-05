Vue.config.devtools = true;
var newProduct = false;
var app = new Vue({
    el: '#app',
    data: {
        editing: false,
        loading: false,
        selectedProduct: null,
        resid: 0,
            objectIndex: 0,
            productModel: {
                id: 0,
                name: " ",
                description: " ",
                value: 0.00,
                image: '',
                category: " ",
                isNew: false,
                dateTime: '',
                isTrending: false,
                isActive: false,
                imageAdded: "",
                stillImage: "",
                fullDescription: " ",
                avRating: 0,
        },
        newStock: {
            productId: 0,
            description: "Тип",
            qty: 10,
            value: 0.00,
            isOnSale: 0,
            isActive: true,
            propimage: "",
            IsImageRequested: '',
            StillImage: '',
            color: "",
        },
        newSpecification: {
            productId: 0,
            accumCapacity: " ",
            screen: " ",
            builtInAccum: " ",
            maxVoltage: " ",
            voltageChange: " ",
            bakValue: " ",
            puffCol: " ",
            flavour: " ",
            vgpg: " ",
            nic: " ",
            nicProp: " ",
            liqValue: " ",
            mtl: " ",
            spiral: " ",
            obduv: " ",
            type: " ",
            amper: " ",
            length: " ",
            size: " ",
            width: " ",
            weigth: " ",
            charghingTime: " ",
        },
        newReview: {
            productId: 0,
            comments: " ",
            commentatorName: " ",
            email: " ",
            title: " ",
            rating: 1
        },

        imageurl: "",
        mfile: '',
        mfileStock: '',
        quill: "",
        text: "",
        resid: 0,
        products: [],
    },
    mounted() {
        this.getProducts();
    },
    methods: {
        onFileChange(e) {
            var files = e.target.files[0];
            mfile = files;
            if (!files.length)
                return;
            this.createImage(files[0]);
        },
        onFileChangeStock(e) {
            var files = e.target.files[0];
            mfileStock = files;
            if (!files.length)
                return;
            this.createImage(files[0]);
        },
        createImage(file) {
            var imageurl = new Image(200,300);
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

        getProduct(id) {
            this.loading = true;
            var product
            axios.get('/products/' + id)
                .then(res => {
                    console.log(res);
                    product = res.data;
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        description: product.description,
                        fullDescription: product.fullDescription,
                        avRating: product.avRating,
                        category: product.category,
                        isNew: product.isNew,
                        isActive: product.isActive,
                        dateTime: product.dateTime,
                        isTrending: product.isTrending,
                        value: product.value,
                        image: product.image
                    };
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    var display = {
                        POD: [1, 2, 3, 4, 5, 6, 18, 19, 20, 21, 22],
                        MOD: [1, 2, 3, 4, 5, 6, 18, 19, 20, 21, 22],
                        Vape: [1, 2, 3, 4, 5, 6, 18, 19, 20, 21, 22],
                        Одноразка: [1, 6, 7],
                        Атомайзер: [16, 15, 14, 13],
                        Испаритель: [14, 16, 4],
                        Аккумулятор: [1, 16, 17],
                        Жидкость: [9, 11, 10, 12],
                    };
                    var sel = document.getElementById("select");
                    for (var i = 1; i < 23; i++) {
                        document.getElementById("box" + i).classList.add("hidden");
                    };
                    display[sel.value].forEach(function (i) {
                        document.getElementById("box" + i).classList.remove("hidden");
                    });                    
                    var json = JSON.parse(product.fullDescription);
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

            $('.color1').colorpicker();
            $('.color1').on('colorpickerChange', function (event) {
                $('.color1 .fa-square').css('color', event.color.toString());
            });

            this.stockColor();
        },
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
                        if (newProduct == true) {
                            this.editProduct(resid, this.products.length - 1)
                            this.selectProduct(this.products[this.products.length - 1]);
                        }
                        this.loading = false;
                    });
        },
        createProduct() {
            this.loading = true;
            /*var json = JSON.stringify(quill.getContents(0, quill.getLength()));*/
            var formData = new FormData();
            formData.append('request.id', this.productModel.id);
            formData.append('request.name', this.productModel.name);
            formData.append('request.description', this.productModel.description);
            formData.append('request.value', parseFloat(this.productModel.value).toFixed(2).replace(".", ","));
            formData.append('request.fullDescription', "null");
            formData.append('request.avRating', this.productModel.avRating);
            formData.append('request.category', this.productModel.category);
            formData.append('request.isOnSale', this.productModel.isOnSale);
            formData.append('request.isNew', this.productModel.isNew);
            formData.append('request.isActive', this.productModel.isActive);
            formData.append('request.isTrending', this.productModel.isTrending);
            if (typeof mfile === 'undefined') {
                this.productModel.imageAdded = 'not';
            }
            else {
                this.productModel.imageAdded = '';
                formData.append('request.image', mfile);
            }
            formData.append('request.imageAdded', this.productModel.imageAdded);
            var value = this.productModel.value;
            axios.post('/products', formData)
                .then(res => {
                    console.log(res.data);
                    this.products.push(res.data);
                    resid = res.data.id;
                    this.newSpecification.productId = resid;
                    console.log(resid);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    axios.post('/specifications', this.newSpecification)
                        .then(res => {
                            console.log(res);
                            this.selectedProduct.specification.push(res.data);
                        })
                        .catch(err => {
                            console.log(err);
                        })
                        .then(() => {
                            var formData = new FormData();
                            formData.append('request.productId', resid);
                            formData.append('request.description', "Стандартный");
                            formData.append('request.qty', 1);
                            formData.append('request.value', parseFloat(value).toFixed(2).replace(".", ","));
                            formData.append('request.isOnSale', 0);
                            formData.append('request.isActive', false);
                            if (typeof mfile === 'undefined') {
                                this.IsImageRequested = 'not';
                                this.stillImage = 'undefined.jpg';
                            }
                            else {
                                this.IsImageRequested = '';
                                formData.append('request.propimage', mfile);
                            }
                            formData.append('request.stillImage', this.stillImage);
                            formData.append('request.IsImageRequested', this.IsImageRequested);
                            formData.append('request.color', "#000000");
                            axios.post('/stocks', formData)
                                .then(res => {
                                    console.log(res);
                                    this.selectedProduct.stock.push(res.data);
                                })
                                .catch(err => {
                                    console.log(err);
                                })
                                .then(() => {
                                    toastr["success"]("Товар создан")
                                    newProduct = true;
                                    this.getProducts();
                                   /* this.loading = false;*/
                                });
                        });
                    this.newStock.productId = resid;
                    this.newReview.productId = resid;
                   // this.editing = false;
                });
        },
        updateProduct() {
            this.loading = true;
            var formData = new FormData();
            var json = JSON.stringify(quill.getContents(0, quill.getLength()));
            formData.append('request.id', this.productModel.id);
            formData.append('request.name', this.productModel.name);
            formData.append('request.description', this.productModel.description);
            formData.append('request.category', this.productModel.category);
            formData.append('request.isOnSale', this.productModel.isOnSale);
            formData.append('request.isNew', this.productModel.isNew);
            formData.append('request.isActive', this.productModel.isActive);
            formData.append('request.isTrending', this.productModel.isTrending);
            formData.append('request.value', parseFloat(this.productModel.value).toFixed(2).replace(".", ","));
            formData.append('request.fullDescription', json);
            var av = 0;
            for (var i = 0; i < this.selectedProduct.review.length; i++) {
                av = av + this.selectedProduct.review[i].rating;
            }
            this.productModel.avRating = (av/this.selectedProduct.review.length);
            formData.append('request.avRating', parseFloat(this.productModel.avRating).toFixed(2).replace(".", ","));
            if (typeof mfile === 'undefined') {
                this.productModel.imageAdded = 'not';
                formData.append('request.stillImage', this.selectedProduct.image);
            }
            else {
                this.productModel.imageAdded = '';
                formData.append('request.image', mfile);
            }
            formData.append('request.imageAdded', this.productModel.imageAdded);

            axios.put('/products', formData)
                .then(res => {
                    console.log(res.data);
                    this.products.splice(this.objectIndex, 1, res.data);

                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    axios.put('/specifications', {
                        specification: this.selectedProduct.specification.map(x => {
                            return {
                                id: x.id,
                                accumCapacity: x.accumCapacity,
                                screen: x.screen,
                                builtInAccum: x.builtInAccum,
                                maxVoltage: x.maxVoltage,
                                voltageChange: x.voltageChange,
                                bakValue: x.bakValue,
                                puffCol: x.puffCol,
                                flavour: x.flavour,
                                vgpg: x.vgpg,
                                nic: x.nic,
                                nicProp: x.nicProp,
                                liqValue: x.liqValue,
                                mtl: x.mtl,
                                spiral: x.spiral,
                                obduv: x.obduv,
                                type: x.type,
                                amper: x.amper,
                                length: x.length,
                                size: x.size,
                                width: x.width,
                                weigth: x.weigth,
                                charghingTime: x.charghingTime,
                                productId: this.selectedProduct.id
                            };
                        }),

                    })
                        .then(res => {
                            console.log(res);
                            this.selectedProduct.specification.splice(index, 1);
                        })
                        .catch(err => {
                            console.log(err);
                        })
                        .then(() => {
                            axios.put('/stocks', {
                                stock: this.selectedProduct.stock.map(x => {
                                    return {
                                        id: x.id,
                                        description: x.description,
                                        qty: x.qty,
                                        value: x.value,
                                        isOnSale: x.isOnSale,
                                        isActive: x.isActive,
                                        productId: this.selectedProduct.id,
                                        propImage: x.propImage,
                                        color: x.color,
                                    };
                                })
                            })
                                .then(res => {
                                    console.log(res);
                                    this.selectedProduct.stock.splice(index, 1);
                                })
                                .catch(err => {
                                    console.log(err);
                                })
                                .then(() => {
                                    toastr["success"]("Товар обновлён")
                                    this.loading = false;
                                });
                        });
                  //  this.editing = false;
                });
        },
        deleteProduct(id, index) {
            this.loading = true;
            axios.delete('/products/' + id)
                .then(res => {
                    console.log(res);
                    this.products.splice(index, 1);
                    toastr["info"]("Товар удалён")
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        editProduct(id, index) {
            this.objectIndex = index;
            this.getProduct(id);
            this.editing = true;
            document.getElementById("descr").classList.remove("hidden");
        },
        newProduct() {
            this.editing = true;
            this.productModel.id = 0;
            //document.getElementById("descr").classList.remove("hidden");
            //this.quillEditor(JSON.parse('"Введите описание товара"'));
        },
        cancel() {
            this.editing = false;
            document.getElementById("descr").classList.add("hidden")
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
        stockColor() {
            for (var i = 0; i < this.selectedProduct.stock.length; i++) {
                document.getElementsByName("colorIndicator")[i].style.color = this.selectedProduct.stock[i].color;
            }
        },
        updateStock() {
            this.loading = true;
            axios.put('/stocks', {
                stock: this.selectedProduct.stock.map(x => {
                    return {
                        id: x.id,
                        description: x.description,
                        qty: x.qty,
                        value: parseFloat(x.value).toFixed(2).replace(".", ","),
                        isOnSale: x.isOnSale,
                        isActive: x.isActive,
                        productId: this.selectedProduct.id,
                        propImage: x.propImage,
                        color: x.color,
                    };
                })
            })
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        addStock() {
            this.loading = true;
            var formData = new FormData();
            if (document.getElementById("customCheckbox2").checked == false) {
                this.newStock.isOnSale = 0;
            }
            formData.append('request.productId', this.newStock.productId);
            formData.append('request.description', this.newStock.description);
            formData.append('request.qty', this.newStock.qty);
            formData.append('request.isOnSale', this.newStock.isOnSale);
            formData.append('request.isActive', this.newStock.isActive);
            formData.append('request.value', parseFloat(this.newStock.value).toFixed(2).replace(".", ","));
            if (typeof mfileStock === 'undefined') {
                this.IsImageRequested = 'not';
            }
            else {
                this.IsImageRequested = '';
                formData.append('request.propimage', mfileStock);
            }
            formData.append('request.stillImage', this.selectedProduct.image);
            formData.append('request.IsImageRequested', this.IsImageRequested);
            if (this.colorIndicate) {
            formData.append('request.color', document.getElementById('colorPicker').value);
            }
            axios.post('/stocks', formData)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.push(res.data);
                    toastr["success"]("Вариация добавлена")
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.newStock.isOnSale = 0;
                    this.loading = false;
                });
        },
        deleteStock(id, index) {
            this.loading = true;
            axios.delete('/stocks/' + id)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.splice(index, 1);
                    toastr["info"]("Вариация удалена")
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
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateSpecification() {
            this.loading = true;
            axios.put('/specifications', {
                specification: this.selectedProduct.specification.map(x => {
                    return {
                        id: x.id,
                        accumCapacity: x.accumCapacity,
                        screen: x.screen,
                        builtInAccum: x.builtInAccum,
                        maxVoltage: x.maxVoltage,
                        voltageChange: x.voltageChange,
                        bakValue: x.bakValue,
                        puffCol: x.puffCol,
                        flavour: x.flavour,
                        vgpg: x.vgpg,
                        nic: x.nic,
                        nicProp: x.nicProp,
                        liqValue: x.liqValue,
                        mtl: x.mtl,
                        spiral: x.spiral,
                        obduv: x.obduv,
                        type: x.type,
                        amper: x.amper,
                        length: x.length,
                        size: x.size,
                        width: x.width,
                        weigth: x.weigth,
                        charghingTime: x.charghingTime,
                        productId: this.selectedProduct.id
                    };
                })
            })
                .then(res => {
                    console.log(res);
                    this.selectedProduct.specification.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        addSpecification() {
            this.loading = true;
            console.log(resid);
            axios.post('/specifications', this.newSpecification)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.specification.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        deleteSpecification(id, index) {
            this.loading = true;
            axios.delete('/specifications/' + id)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.specification.splice(index, 1);
                    
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
        updateReview() {
            this.loading = true;
            axios.put('/reviews', {
                review: this.selectedProduct.review.map(x => {
                    return {
                        id: x.id,
                        comments: x.comments,
                        commentatorName: x.commentatorName,
                        email: x.email,
                        title: x.title,
                        rating: x.rating,
                        productId: this.selectedProduct.id
                    };
                })
            })
                .then(res => {
                    console.log(res);
                    this.selectedProduct.review.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        addReview() {
            this.loading = true;
            axios.post('/reviews', this.newReview)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.review.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    toastr["success"]("Комментарий добавлен")
                    var average = 0;
                    for (var i = 0; i < this.selectedProduct.review.length; i++) {
                        average = average + this.selectedProduct.review[i].rating;
                    }
                    this.productModel.avRating = (average / this.selectedProduct.review.length);
                    document.getElementById('reviewRate').innerHTML = "<i class='fa fa-star'></i> " + this.productModel.avRating.toFixed(2).replace(".", ",");
                    this.loading = false;
                });
        },
        deleteReview(id, index) {
            this.loading = true;
            axios.delete('/reviews/' + id)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.review.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    toastr["info"]("Комментарий удалён")
                    this.loading = false;
                });
        },
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.productId = product.id;
            this.newReview.productId = product.id;
            this.newSpecification.productId = product.id;
        },
    },

    computed:
    {
        colorIndicate() {
            this.selectedProduct.category;
            return this.selectedProduct.category == "POD" ||
                this.selectedProduct.category == "MOD" ||
                this.selectedProduct.category == "Vape";
        },

      
    }
});