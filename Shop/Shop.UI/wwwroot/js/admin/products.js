Vue.config.devtools = true;
var newProduct = false;
var app = new Vue({
    el: '#app',
    data: {
        editing: false,
        loading: false,
        selectedProduct: null,
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
            const files = e.target.files[0];
            mfile = files;
            if (!files.length)
                return;
            this.createImage(files[0]);
        },
        onFileChangeStock(e) {
            const files = e.target.files[0];
            mfileStock = files;
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

        async getProduct(id) {
            this.loading = true;
            let product;
            try {
                product = await http.get('/products/' + id);
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
            } catch (err) {
                console.log(err);
            }

            const display = {
                POD: [1, 2, 3, 4, 5, 6, 18, 19, 20, 21, 22],
                MOD: [1, 2, 3, 4, 5, 6, 18, 19, 20, 21, 22],
                Vape: [1, 2, 3, 4, 5, 6, 18, 19, 20, 21, 22],
                Одноразка: [1, 6, 7],
                Атомайзер: [16, 15, 14, 13],
                Испаритель: [14, 16, 4],
                Аккумулятор: [1, 16, 17],
                Жидкость: [9, 11, 10, 12],
            };
            const sel = document.getElementById("select");
            for (let i = 1; i < 23; i++) {
                document.getElementById("box" + i).classList.add("hidden");
            }
            display[sel.value].forEach(function (i) {
                document.getElementById("box" + i).classList.remove("hidden");
            });
            const json = JSON.parse(product.fullDescription);
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

            $('.color1').colorpicker();
            $('.color1').on('colorpickerChange', function (event) {
                $('.color1 .fa-square').css('color', event.color.toString());
            });

            this.stockColor();
        },
        async getProducts() {
            this.loading = true;
            try {
                this.products = await http.get('/products');
            } catch (err) {
                console.log(err);
            }
            if (newProduct == true) {
                this.editProduct(resid, this.products.length - 1);
                this.selectProduct(this.products[this.products.length - 1]);
            }
            this.loading = false;
        },
        async createProduct() {
            this.loading = true;
            const formData = new FormData();
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
            } else {
                this.productModel.imageAdded = '';
                formData.append('request.image', mfile);
            }
            formData.append('request.imageAdded', this.productModel.imageAdded);
            const value = this.productModel.value;

            try {
                const product = await http.post('/products', formData);
                this.products.push(product);
                resid = product.id;
                this.newSpecification.productId = resid;
            } catch (err) {
                console.log(err);
            }

            try {
                const spec = await http.post('/specifications', this.newSpecification);
                this.selectedProduct.specification.push(spec);
            } catch (err) {
                console.log(err);
            }

            const stockData = new FormData();
            stockData.append('request.productId', resid);
            stockData.append('request.description', "Стандартный");
            stockData.append('request.qty', 1);
            stockData.append('request.value', parseFloat(value).toFixed(2).replace(".", ","));
            stockData.append('request.isOnSale', 0);
            stockData.append('request.isActive', false);
            if (typeof mfile === 'undefined') {
                this.IsImageRequested = 'not';
                this.stillImage = 'undefined.jpg';
            } else {
                this.IsImageRequested = '';
                stockData.append('request.propimage', mfile);
            }
            stockData.append('request.stillImage', this.stillImage);
            stockData.append('request.IsImageRequested', this.IsImageRequested);
            stockData.append('request.color', "#000000");

            try {
                const stock = await http.post('/stocks', stockData);
                this.selectedProduct.stock.push(stock);
            } catch (err) {
                console.log(err);
            }

            toastr["success"]("Товар создан");
            newProduct = true;
            this.getProducts();

            this.newStock.productId = resid;
            this.newReview.productId = resid;
        },
        async updateProduct() {
            this.loading = true;
            const formData = new FormData();
            const json = JSON.stringify(quill.getContents(0, quill.getLength()));
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
            let av = 0;
            for (let i = 0; i < this.selectedProduct.review.length; i++) {
                av = av + this.selectedProduct.review[i].rating;
            }
            this.productModel.avRating = (av / this.selectedProduct.review.length);
            formData.append('request.avRating', parseFloat(this.productModel.avRating).toFixed(2).replace(".", ","));
            if (typeof mfile === 'undefined') {
                this.productModel.imageAdded = 'not';
                formData.append('request.stillImage', this.selectedProduct.image);
            } else {
                this.productModel.imageAdded = '';
                formData.append('request.image', mfile);
            }
            formData.append('request.imageAdded', this.productModel.imageAdded);

            try {
                const product = await http.put('/products', formData);
                this.products.splice(this.objectIndex, 1, product);
            } catch (err) {
                console.log(err);
            }

            try {
                await http.put('/specifications', {
                    specification: this.selectedProduct.specification.map(x => ({
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
                    })),
                });
                this.selectedProduct.specification.splice(index, 1);
            } catch (err) {
                console.log(err);
            }

            try {
                await http.put('/stocks', {
                    stock: this.selectedProduct.stock.map(x => ({
                        id: x.id,
                        description: x.description,
                        qty: x.qty,
                        value: x.value,
                        isOnSale: x.isOnSale,
                        isActive: x.isActive,
                        productId: this.selectedProduct.id,
                        propImage: x.propImage,
                        color: x.color,
                    }))
                });
                this.selectedProduct.stock.splice(index, 1);
            } catch (err) {
                console.log(err);
            }

            toastr["success"]("Товар обновлён");
            this.loading = false;
        },
        async deleteProduct(id, index) {
            this.loading = true;
            try {
                await http.delete('/products/' + id);
                this.products.splice(index, 1);
                toastr["info"]("Товар удалён");
            } catch (err) {
                console.log(err);
            }
            this.loading = false;
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
        },
        cancel() {
            this.editing = false;
            document.getElementById("descr").classList.add("hidden");
        },
        stockColor() {
            for (let i = 0; i < this.selectedProduct.stock.length; i++) {
                document.getElementsByName("colorIndicator")[i].style.color = this.selectedProduct.stock[i].color;
            }
        },
        async updateStock() {
            this.loading = true;
            try {
                await http.put('/stocks', {
                    stock: this.selectedProduct.stock.map(x => ({
                        id: x.id,
                        description: x.description,
                        qty: x.qty,
                        value: parseFloat(x.value).toFixed(2).replace(".", ","),
                        isOnSale: x.isOnSale,
                        isActive: x.isActive,
                        productId: this.selectedProduct.id,
                        propImage: x.propImage,
                        color: x.color,
                    }))
                });
                this.selectedProduct.stock.splice(index, 1);
            } catch (err) {
                console.log(err);
            }
            this.loading = false;
        },
        async addStock() {
            this.loading = true;
            const formData = new FormData();
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
            } else {
                this.IsImageRequested = '';
                formData.append('request.propimage', mfileStock);
            }
            formData.append('request.stillImage', this.selectedProduct.image);
            formData.append('request.IsImageRequested', this.IsImageRequested);
            if (this.colorIndicate) {
                formData.append('request.color', document.getElementById('colorPicker').value);
            }

            try {
                const stock = await http.post('/stocks', formData);
                this.selectedProduct.stock.push(stock);
                toastr["success"]("Вариация добавлена");
            } catch (err) {
                console.log(err);
            }
            this.newStock.isOnSale = 0;
            this.loading = false;
        },
        async deleteStock(id, index) {
            this.loading = true;
            try {
                await http.delete('/stocks/' + id);
                this.selectedProduct.stock.splice(index, 1);
                toastr["info"]("Вариация удалена");
            } catch (err) {
                console.log(err);
            }
            this.loading = false;
        },
        async updateSpecification() {
            this.loading = true;
            try {
                await http.put('/specifications', {
                    specification: this.selectedProduct.specification.map(x => ({
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
                    }))
                });
                this.selectedProduct.specification.splice(index, 1);
            } catch (err) {
                console.log(err);
            }
            this.loading = false;
        },
        async addSpecification() {
            this.loading = true;
            try {
                const spec = await http.post('/specifications', this.newSpecification);
                this.selectedProduct.specification.push(spec);
            } catch (err) {
                console.log(err);
            }
            this.loading = false;
        },
        async deleteSpecification(id, index) {
            this.loading = true;
            try {
                await http.delete('/specifications/' + id);
                this.selectedProduct.specification.splice(index, 1);
            } catch (err) {
                console.log(err);
            }
            this.loading = false;
        },
        async updateReview() {
            this.loading = true;
            try {
                await http.put('/reviews', {
                    review: this.selectedProduct.review.map(x => ({
                        id: x.id,
                        comments: x.comments,
                        commentatorName: x.commentatorName,
                        email: x.email,
                        title: x.title,
                        rating: x.rating,
                        productId: this.selectedProduct.id
                    }))
                });
                this.selectedProduct.review.splice(index, 1);
            } catch (err) {
                console.log(err);
            }
            this.loading = false;
        },
        async addReview() {
            this.loading = true;
            try {
                const review = await http.post('/reviews', this.newReview);
                this.selectedProduct.review.push(review);
            } catch (err) {
                console.log(err);
            }
            toastr["success"]("Комментарий добавлен");
            let average = 0;
            for (let i = 0; i < this.selectedProduct.review.length; i++) {
                average = average + this.selectedProduct.review[i].rating;
            }
            this.productModel.avRating = (average / this.selectedProduct.review.length);
            document.getElementById('reviewRate').innerHTML = "<i class='fa fa-star'></i> " + this.productModel.avRating.toFixed(2).replace(".", ",");
            this.loading = false;
        },
        async deleteReview(id, index) {
            this.loading = true;
            try {
                await http.delete('/reviews/' + id);
                this.selectedProduct.review.splice(index, 1);
            } catch (err) {
                console.log(err);
            }
            toastr["info"]("Комментарий удалён");
            this.loading = false;
        },
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.productId = product.id;
            this.newReview.productId = product.id;
            this.newSpecification.productId = product.id;
        },
    },

    computed: {
        colorIndicate() {
            return this.selectedProduct.category == "POD" ||
                this.selectedProduct.category == "MOD" ||
                this.selectedProduct.category == "Vape";
        },
    }
});
