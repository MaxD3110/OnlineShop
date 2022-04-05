Vue.config.devtools = true;
var option;
var colorIndex = 0;
var app = new Vue({
    el: '#app',
    data: {
        viewing: false,
        /*loading: false,*/
        selectedProduct: null,
        newReview: {
            productId: 0,
            comments: "",
            commentatorName: "",
            email: "",
            title: "",
            rating: 1,
        },
    /*products: [],*/
    },


    mounted() {
        this.update();
/*        this.getProducts();*/
        this.getQuill();
        this.getSpecs();
        document.getElementById("rateval").style.width = ((document.getElementById("getavRate").value).replace(",", ".") * 20) + "%";

    },

    methods: {

        //getProducts() {
        //    this.loading = true;
        //    axios.get('/products')
        //        .then(res => {
        //            console.log(res);
        //            this.products = res.data;
        //        })
        //        .catch(err => {
        //            console.log(err);
        //        })
        //        .then(() => {

        //            this.loading = false;
        //        });
        //},



        update(colorIn) {

            if (Number.isInteger(colorIn)) {
            colorIndex = colorIn - 1;
            }

            var category = document.getElementById('productCategory').innerHTML;
            var select = document.getElementById('selector');

            if (category === "POD" || category === "MOD" || category === "Vape") {

                select.selectedIndex = colorIndex;
                document.getElementById('stock').style.display = 'none';
            }
            else {
                document.getElementById('color').style.display = 'none';
            }

            option = select.options[select.selectedIndex];
            console.log(select.selectedIndex);
            for (var i = 0; i < select.length; i++) {
                if (i == colorIndex || i == select.selectedIndex) {
                    document.getElementsByName('colors')[i].classList.add('active');
                    if (document.getElementById('CompareViewModel_Key').value > 1) {

                    document.getElementsByClassName('product-gallery-item')[i].classList.add('active');
                    }
                }
                else {
                    document.getElementsByName('colors')[i].classList.remove('active');
                    if (document.getElementById('CompareViewModel_Key').value > 1) {

                        document.getElementsByClassName('product-gallery-item')[i].classList.remove('active');
                    }
                }
            }

            document.getElementById('CompareViewModel_Key').value = option.getAttribute('data-id');
            document.getElementById('WishViewModel_StockId').value = option.getAttribute('data-id'); 
            document.getElementById('CartViewModel_StockId').value = option.getAttribute('data-id');

            this.stockCounter(option.getAttribute('data-qty')); //Надпись о количестве товара на складе

            document.getElementById('stockSpan').innerHTML = "(" + option.getAttribute('data-name') + ")"; //Отображение варианта в названии ()

            this.saleEnable(option.getAttribute('data-sale'), option.getAttribute('data-value'), document.getElementById('qty').value); //Подсчет и вывод скидки

            this.elevate(option) //Изображение (зум, полный экран)

        },

        elevate(option) {

            document.getElementById('product-zoom').setAttribute("src", "/images/productsfolder/" + option.getAttribute('data-stockImage'));

            if ($.fn.elevateZoom) {
                $('#product-zoom').data('zoom-image', "/images/productsfolder/" + option.getAttribute('data-stockImage')).elevateZoom({
                    gallery: 'product-zoom-gallery',
                    galleryActiveClass: 'active',
                    zoomType: "inner",
                    cursor: "crosshair",
                    zoomWindowFadeIn: 400,
                    zoomWindowFadeOut: 400,
                    responsive: true
                });

                // On click change thumbs active item
                $('.product-gallery-item').on('click', function (e) {
                    $('#product-zoom-gallery').find('a').removeClass('active');
                    $(this).addClass('active');

                    e.preventDefault();
                });

                var ez = $('#product-zoom').data('elevateZoom');

                // Open popup - product images
                $('#btn-product-gallery').on('click', function (e) {
                    if ($.fn.magnificPopup) {
                        $.magnificPopup.open({
                            items: ez.getGalleryList(),
                            type: 'image',
                            gallery: {
                                enabled: true
                            },
                            fixedContentPos: false,
                            removalDelay: 600,
                            closeBtnInside: false
                        }, 0);

                        e.preventDefault();
                    }
                });
            }
        },

        saleEnable(sale, value, qty) {

            if (sale == 0) {

                document.getElementById('stockValue').innerHTML = ((value).replace(",", ".") * qty).toFixed(2) + " р.";
                document.getElementById('stockValueOnSale').setAttribute('hidden', 'hidden');
                document.getElementById('stockValue').removeAttribute('hidden', 'hidden');
                document.getElementById('saleBage').setAttribute('hidden', 'hidden');
            }
            else {

                document.getElementById('saleBage').removeAttribute('hidden', 'hidden');
                document.getElementById('stockValue').setAttribute('hidden', 'hidden');
                document.getElementById('stockValueOnSale').removeAttribute('hidden', 'hidden');
                var costSale = (value).replace(",", ".") * (sale / 100)
                document.getElementById('stockValueOnSale').innerHTML =
                    "<span class='new-price'>" +
                    (((value).replace(",", ".") - costSale) * qty).toFixed(2)
                    + " р. </span> <span class='old-price'> <s>" +
                    ((value).replace(",", ".") * qty).toFixed(2)
                    + "</s> р. </span>";
            }

            /*$('.zoomWindowContainer div').stop().css("background-image", "url(" + "/images/productsfolder/" + option.getAttribute('data-stockImage') + ")");*/

            

        },

        stockCounter(qty) {

            document.getElementById('qty').setAttribute('max', qty);

            if (qty <= 0) {
                document.getElementById('qtycheck').classList.add('out-of-stock');
                document.getElementById('qtycheck').classList.remove('in-stock');
                document.getElementById('qtycheck').innerHTML = "Под заказ";
            }
            else if (qty < 10) {
                document.getElementById('qtycheck').classList.remove('out-of-stock');
                document.getElementById('qtycheck').classList.add('in-stock');
                document.getElementById('qtycheck').innerHTML = "Мало";
            }
            else {
                document.getElementById('qtycheck').classList.remove('out-of-stock');
                document.getElementById('qtycheck').classList.add('in-stock');
                document.getElementById('qtycheck').innerHTML = "В наличии";
            }
        },


        addOneToWish() {
            axios.post("/Wish/AddOneWish/" + option.getAttribute('data-id'))
                .then(res => {
                    this.updateWish();
                    toastr["success"]("Товар добавлен в избранное")
                }).catch(err => {
                    alert(err.error);
                })
        },
        updateWish() {
            axios.get('/Wish/GetWishComponent')
                .then(res => {
                    var html = res.data;
                    var el = document.getElementById('wish-nav');

                    el.outerHTML = html;
                });
        },

        addOneToCompare() {
            this.selectedProduct = JSON.parse(document.getElementById('getObject').value);
            console.log(this.selectedProduct.specification[0].id);
            axios.post("/Compare/AddOneCompare/" + (option.getAttribute('data-id') + "," + this.selectedProduct.specification[0].id))
                .then(res => {
                    axios.get('/Compare/GetCompareMedium')
                        .then(res => {
                            var html = res.data;
                            var el = document.getElementById('compare-med');
                            el.outerHTML = html;
                            toastr["success"]("Товар добавлен к сравнению")
                        });
                }).catch(err => {
                    alert(err.error);
                })
        },

        addReview(product) {
            this.loading = true;
            product = JSON.parse(document.getElementById('getObject').value);
            this.selectedProduct = product;
            this.newReview.productId = parseInt(document.getElementById('getId').value);

            var formData = new FormData();

            axios.post('/reviews', this.newReview)
                .then(res => {
                    this.selectedProduct.review.push(res.data);

                    if (this.selectedProduct.review.length > 0) {

                        var i = 0;

                        for (var b = 0; b < this.selectedProduct.review.length; b++) {
                            i = i + this.selectedProduct.review[b].rating;
                        }

                        this.selectedProduct.avRating = parseFloat(i / this.selectedProduct.review.length).toFixed(2).replace(".", ",");
                    }
                    else {
                        this.selectedProduct.avRating = parseFloat(this.selectedProduct.review[0]).toFixed(2).replace(".", ",");
                        console.log(this.selectedProduct.review[0]);
                    }
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    formData.append('request.id', this.selectedProduct.id);
                    formData.append('request.name', this.selectedProduct.name);
                    formData.append('request.description', this.selectedProduct.description);
                    formData.append('request.category', this.selectedProduct.category);
                    formData.append('request.isOnSale', this.selectedProduct.isOnSale);
                    formData.append('request.isNew', this.selectedProduct.isNew);
                    formData.append('request.isActive', this.selectedProduct.isActive);
                    formData.append('request.isTrending', this.selectedProduct.isTrending);
                    formData.append('request.value', parseFloat(this.selectedProduct.value).toFixed(2).replace(".", ","));
                    formData.append('request.fullDescription', this.selectedProduct.fullDescription);
                    formData.append('request.avRating', this.selectedProduct.avRating);
                    formData.append('request.stillImage', this.selectedProduct.image);
                    formData.append('request.imageAdded', 'not');
                    console.log(this.selectedProduct.value);
                    console.log(parseFloat(this.selectedProduct.value).toFixed(2).replace(".", ","));
                    axios.put('/products', formData)
                        .then(res => {
                            console.log(res.data);
                            /*this.products.splice(0 ,1, res.data);*/

                        })
                        .catch(err => {
                            console.log(err);
                        })
                    /*toastr["success"]("Комментарий добавлен")*/
                    this.loading = false;
                });
        },

        getQuill(product) {
            window.addEventListener("load", function () {
            product = JSON.parse(document.getElementById('getObject').value);
            this.selectedProduct = product;
                var options = {
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
            editor.updateContents(JSON.parse(this.selectedProduct.fullDescription));
            });
        },

        getSpecs() {
            window.addEventListener("load", function () {

                var table = document.getElementById("specTable");

                var result = Object.values(this.selectedProduct.specification[0]);
                var info = [
                    'id',
                    'Емкость аккумулятора',
                    'Дисплей',
                    'Встроенный аккумулятор',
                    'Максимальная мощность',
                    'Регулировка мощности',
                    'Объем бака',
                    'Количество затяжек',
                    'Вкус',
                    'VG/PG',
                    'Тип никотина',
                    'Крепость жидкости',
                    'Объем',
                    'MTL',
                    'Количество спиралей',
                    'Обдув',
                    'Тип',
                    'Напряжение',
                    'Длина',
                    'Высота',
                    'Ширина',
                    'Вес',
                    'Время зарядки',

                ];
                console.log(result);
                    for (var i = 1; i < result.length; i++) {
                        if (result[i] != " ") {
                            let row = table.insertRow();
                            let caption = row.insertCell(0);
                            let value = row.insertCell(1);
                            caption.innerHTML = "<b>" + info[i] + "</b>";
                            value.innerHTML = result[i];
                        }
                    }
            })
        }
    },

        computed:
        {

        },
})