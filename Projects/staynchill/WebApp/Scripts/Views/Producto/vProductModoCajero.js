var productsArray = [];

function vProductModoCajero() {

    this.service = 'GetProductsByHotelServicio';
    this.ctrlActions = new ControlActions();

    this.InitModoCajero = function (modoCajeroId) {
        document.querySelector('#' + modoCajeroId).addEventListener('click', this.showEmpty);
    }

    this.showEmpty = function () {
        let parentProductsCards = document.querySelector('#parentProductsCards');
        parentProductsCards.innerHTML = '';

        let div = document.createElement('div');


        div.innerHTML = `

                    <div id="card-nodata" class="col-lg-12 text-center">
                        <h1 style="margin: 10rem 10rem 0 10rem;">Aquí va la lista de productos</h1>
                        <p style="font-size: 16px;">Presione el botón de abrir cámara y muestre el código QR</p>
                    </div>

                `;

        parentProductsCards.appendChild(div);
        displayProductos();

    }

    

    

    

}

//ON DOCUMENT READY
$(document).ready(function () {
    var vCajero = new vProductModoCajero();
    vCajero.InitModoCajero('btnModoCajero');
});

// Displays modal to read QR Code
displayQRCodeReader = function () {
    let qrCodeScannerModal = document.querySelector('#qrCodeScannerModal');

    let div = document.createElement('div');
    div.classList.add('row');

    qrCodeScannerModal.innerHTML = `
                            <video id="qrCodeReader" style="position:relative"></video>
                            
                            `

    qrCodeScannerModal.appendChild(div);

    initQRCodeReader();
}

// < button type = "button" class="btn btn-brand" data - dismiss="modal" onclick = "getData()" > Asignar roles</button >
    
// Initializes QR Code scanner
initQRCodeReader = function () {
    let scanner = new Instascan.Scanner(
        {
            video: document.getElementById('qrCodeReader')
        }
    );
    scanner.addListener('scan', function (content) {
        ShowProceed(content);
    });
    Instascan.Camera.getCameras().then(cameras => {
        if (cameras.length > 0) {
            scanner.start(cameras[0]);
        } else {
            console.error("¡No hay cámaras!");
        }
    });
}

ShowProceed = function (res) {
    swal.fire({
        title: 'Agregar al carrito',
        text: "¿Está seguro que desea agregar estos productos a esta cuenta?",
        type: 'info',
        showCancelButton: true,
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then(function (result) {
        if (result.value) {
            SendToCarrito(res);
        }
    });
}

















// Displays available products for purchase
displayProductos = function () {
    let parentProductsCards = document.querySelector('#parentProductsCards');
//    parentProductsCards.innerHTML = `

//                                    <button id="btnQRCodeScannerModal" data-toggle="modal" data-target="#kt_select2_modal" type="button" class="btn btn-label-success btn-lg btn-upper">Leer Código QR</button>
                                    





//`


    var idHotel = JSON.parse(localStorage.getItem('Hotel_selected')).Id;
    var idService = JSON.parse(localStorage.getItem('Service_selected')).Id;
    var getProductMethod = new ControlActions().GetMethodGetToApi('producto/' + 'GetProductsByHotelServicio' + '/' + idHotel + '/' + idService, idHotel);

    getProductMethod.then(function (response) {

        var products = response.Data;
        if (response.Data != null) {
            var productsContent = document.querySelector('#parentProductsCards')
            productsContent.innerHTML = ""

            let mainProductRow = document.createElement('div');
            mainProductRow.classList.add('row');

            let rightSide = document.createElement('div');
            rightSide.classList.add('col-2');
            rightSide.style = "border:1px dashed #bebebe;padding:10px;background-color:#FFF;border-radius:5px;-webkit-box-shadow:0px 0px 13px 0px rgba(82, 63, 105, 0.05);border-radius:5px;";
            rightSide.innerHTML +=
                `<div class="row m-auto" style="height: auto">


<button id="btnQRCodeScannerModal" data-toggle="modal" data-target="#kt_select2_modal" type="button" class="btn btn-label-success btn-upper m-auto">Añadir a carrito</button>




                    <!-- begin:: Mycart -->
                    <div id="title__item" class="kt-mycart">
                        <div id="productsContent" class="kt-mycart__body kt-scroll" data-scroll="true" data-height="45" data-mobile-height="200">
                        </div>
                        <div class="kt-mycart__footer">
                            <div class="kt-mycart__section">
                                <div class="kt-mycart__subtitel">
                                    <span>Total</span>
                                </div>
                                <div class="kt-mycart__prices">
                                    <span class="kt-font-brand">$ 0.00</span>
                                </div>
                            </div>
                            <div class="kt-mycart__button kt-align-right">
                                <button type="button" class="btn btn-primary btn-sm" style="visibility:hidden;">Agregar al carro</button>
                            </div>
                        </div>
                    </div>
                </div>


`
            let leftSide = document.createElement('div');
            leftSide.classList.add('col'); 
            leftSide.style.overflowY = 'auto';

            let rowLeftSide = document.createElement('div');
            rowLeftSide.classList.add('row');
            rowLeftSide.style.overflowY = 'auto';

            leftSide.appendChild(rowLeftSide);

            mainProductRow.appendChild(leftSide);

            mainProductRow.appendChild(rightSide);

            productsContent.appendChild(mainProductRow)

            products.forEach(function (obj) {
                console.log(obj);
                    var productDiv = document.createElement('div')
                    productDiv.classList.add('col-3', 'm-3');
                productDiv.innerHTML = `
                                            <div class="kt-mycart__container" style="background-color:#FFF;padding:1rem;-webkit-box-shadow:0px 0px 13px 0px rgba(82, 63, 105, 0.05);border-radius:5px;">
                                                <div class="kt-mycart__info">
                                                    <a class="kt-mycart__title" style="font-weight:bold;">
                                                        ${obj.Name}
                                                    </a>
                                                    
                                                    <div class="kt-mycart__action mt-2">
                                                        <span class="kt-mycart__price${obj.Id}">${formatter.format(obj.Price)}</span>
                                                        <span class="kt-mycart__text">&nbsp;Por&nbsp;</span>
                                                        <span class="kt-mycart__quantity${obj.Id} mr-3">0</span>
                                                        <a id='anchorReduce${obj.Id}' class="btn btn-label-success btn-icon">&minus;</a>
                                                        <a id='anchorAdd${obj.Id}' class="btn btn-label-success btn-icon">&plus;</a>
                                                    </div>
                                                </div>
                                                <div class="row mt-3">
                                                    <a href="#" class="kt-mycart__pic col text-center">
                                                       <img class="kt-widget__img kt-hidden-" style="width:100px;height:100px;border-radius:50%;" src="${'https://res.cloudinary.com/qubitscenfo/image/upload/' + obj.Value}" alt="image">
                                                    </a>
                                                </div>
                                            </div>
                        `
                    rowLeftSide.appendChild(productDiv)
                    document.getElementsByClassName('kt-font-brand')[0].childNodes[0].textContent = '$ 0.00';

                    document.querySelector('#anchorReduce' + obj.Id).onclick = function () {
                        reduceQuantity(obj)
                    }
                    document.querySelector('#anchorAdd' + obj.Id).onclick = function () {
                        addQuantity(obj)
                    }
                    
                })

            
            

            
            
            
            let qrCodeScannerModal = document.querySelector('#btnQRCodeScannerModal');
            qrCodeScannerModal.addEventListener('click', displayQRCodeReader);
        } else {
            var productsContent = document.querySelector('#parentProductsCards')
            productsContent.innerHTML = ""
            var productDiv = document.createElement('div')
            productDiv.innerHTML = `
                                <div id="card-nodata" class="col-lg-12 text-center">
                        <h1 style="margin: 10rem 10rem 0 10rem;">No hay productos en este servicio</h1>
                        <p style="font-size: 16px;">Presione el botón de Añadir Producto para iniciar</p>
                    </div>     
                        
        
`
            productsContent.appendChild(productDiv);
        }
    })
    
}









addQuantity = function (Product) {
    console.log(Product.Id);
    var priceReturn = Product.Price
    var actualQuantity = document.getElementsByClassName('kt-mycart__quantity' + Product.Id)[0].childNodes[0].textContent;
    document.getElementsByClassName('kt-mycart__quantity' + Product.Id)[0].childNodes[0].textContent = (parseInt(actualQuantity) + 1);
    if (actualQuantity != '0') {
        console.log(Product.Price)
        var actualPrice = document.getElementsByClassName('kt-mycart__price' + Product.Id)[0].childNodes[0].textContent;
        actualPrice = actualPrice.replace(/\$/g, '');
        actualPrice = actualPrice.includes(',') ? actualPrice.replace(/\,/g, '') : actualPrice;
        var addPrice = parseFloat(actualPrice) + parseFloat(Product.Price);
        document.getElementsByClassName('kt-mycart__price' + Product.Id)[0].childNodes[0].textContent = formatter.format(addPrice);
        addCarrito(Product, addPrice, (parseInt(actualQuantity) + 1))
        addTotalQuantity(priceReturn)
    } else {
        var actualPrice = document.getElementsByClassName('kt-mycart__price' + Product.Id)[0].childNodes[0].textContent;
        actualPrice = actualPrice.replace(/\$/g, '');
        addCarrito(Product, actualPrice, (parseInt(actualQuantity) + 1))
        addTotalQuantity(priceReturn)
    }
}

reduceQuantity = function (Product) {
    var priceReturn = Product.Price
    var actualQuantity = document.getElementsByClassName('kt-mycart__quantity' + Product.Id)[0].childNodes[0].textContent;
    if (parseInt(actualQuantity) >= 2) {
        document.getElementsByClassName('kt-mycart__quantity' + Product.Id)[0].childNodes[0].textContent = (parseInt(actualQuantity) - 1);
        var actualPrice = document.getElementsByClassName('kt-mycart__price' + Product.Id)[0].childNodes[0].textContent;
        actualPrice = actualPrice.replace(/\$/g, '');
        actualPrice = actualPrice.includes(',') ? actualPrice.replace(/\,/g, '') : actualPrice;
        actualPrice = (actualPrice - parseFloat(Product.Price)).toFixed(2)
        document.getElementsByClassName('kt-mycart__price' + Product.Id)[0].childNodes[0].textContent = formatter.format(actualPrice);
        reduceTotalQuantity(priceReturn)
        reduceCarrito(Product, actualPrice, (parseInt(actualQuantity) - 1))
    } else if (parseInt(actualQuantity) == 1) {
        document.getElementsByClassName('kt-mycart__quantity' + Product.Id)[0].childNodes[0].textContent = (parseInt(actualQuantity) - 1);
        reduceTotalQuantity(priceReturn)
        removeCarrito(Product)
    }
}

addTotalQuantity = function (itemPrice) {
    var actualTotal = document.getElementsByClassName('kt-font-brand')[0].childNodes[0].textContent;
    actualTotal = actualTotal.replace(/\$/g, '');
    actualTotal = actualTotal.includes(',') ? actualTotal.replace(/\,/g, '') : actualTotal;
    var addTotalPrice = parseFloat(actualTotal) + parseFloat(itemPrice);
    document.getElementsByClassName('kt-font-brand')[0].childNodes[0].textContent = formatter.format(addTotalPrice);
}

reduceTotalQuantity = function (itemPrice) {
    var actualTotal = document.getElementsByClassName('kt-font-brand')[0].childNodes[0].textContent;
    actualTotal = actualTotal.replace(/\$/g, '');
    actualTotal = actualTotal.includes(',') ? actualTotal.replace(/\,/g, '') : actualTotal;
    var addTotalPrice = parseFloat(actualTotal) - parseFloat(itemPrice);
    document.getElementsByClassName('kt-font-brand')[0].childNodes[0].textContent = formatter.format(addTotalPrice);
}

addCarrito = function (Product, price, cant) {

    ogPrice = Product.Price

    try {
        //Find index of specific object using findIndex method.    
        var objIndex = productsArray.findIndex((obj => Product.Id == obj.FkProducto));
    } catch (e) {
        console.log(e)
    }

    if (objIndex == -1) {
        var ProductoCarrito = {
            Cant: cant,
            NombreProducto: Product.Name,
            PrecioBruto: Product.Price,
            FkProducto: Product.Id,
            FkCarrito: 0
        };

        productsArray.push(ProductoCarrito)
        var objIndex = productsArray.findIndex((obj => Product.Id == obj.FkProducto));
    } else {
        //Log object to Console.
        console.log("Before update: ", productsArray[objIndex])

        productsArray[objIndex].PrecioBruto = price
        productsArray[objIndex].Cant = cant

        //Log object to console again.
        console.log("After update: ", productsArray[objIndex])
    }

    Product.Price = ogPrice

    console.log(productsArray)

}

reduceCarrito = function (Product, price, cant) {

    ogPrice = Product.Price


    //Find index of specific object using findIndex method.    
    var objIndex = productsArray.findIndex((obj => Product.Id == obj.FkProducto));

    //Log object to Console.
    console.log("Before update: ", productsArray[objIndex])

    productsArray[objIndex].PrecioBruto = price
    productsArray[objIndex].Cant = cant

    //Log object to console again.
    console.log("After update: ", productsArray[objIndex])

    console.log(productsArray)

    Product.Price = ogPrice

}

removeCarrito = function (Product) {
    //Find index of specific object using findIndex method.    
    var objIndex = productsArray.findIndex((obj => Product.Id == obj.Id));
    delete productsArray[objIndex]
    console.log(productsArray)
}

SendToCarrito = function (res) {
    console.log(res);

    // Get FkCarrito
    let idUser = res.split(',')[0];
    console.log(idUser);
    var getUserReservationPost = new ControlActions().GetMethodGetToApi('userreservation' + '/' + idUser);
    getUserReservationPost.done(res => {

        if (res.Data.Carrito != -1) {

            productsArray.forEach(obj => {
                obj.FkCarrito = res.Data.Carrito
                obj.PrecioImpuesto = '0';
            });

            var data = {}
            data.productsArray = productsArray
            console.log(data)


            // POST
            var methodPost = new ControlActions().GetMethodPostToAPI('productocarrito', data);
            methodPost.done(res_2 => {
                $.notify({
                    // options
                    icon: 'glyphicon glyphicon-warning-sign',
                    title: 'Carrito',
                    message: 'Los productos han sido añadidos al carrito.'
                }, {
                        // settings
                        element: 'body',
                        position: null,
                        type: "success",
                        allow_dismiss: true,
                        newest_on_top: false,
                        showProgressbar: false,
                        placement: {
                            from: "top",
                            align: "right",
                            position: "top"
                        },
                        offset: 20,
                        spacing: 10,
                        z_index: 3000,
                        delay: 5000,
                        timer: 1000,
                        url_target: '_blank',
                        mouse_over: null,
                        animate: {
                            enter: 'animated fadeInDown',
                            exit: 'animated fadeOutUp'
                        },
                        onShow: null,
                        onShown: null,
                        onClose: null,
                        onClosed: null,
                        icon_type: 'class',
                        template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                            '<button type="button" aria-hidden="true" class="close" data-notify="dismiss"></button>' +
                            '<span data-notify="icon"></span> ' +
                            '<span data-notify="title">{1}</span> ' +
                            '<span data-notify="message">{2}</span>' +
                            '<div class="progress" data-notify="progressbar">' +
                            '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                            '</div>' +
                            '<a href="{3}" target="{4}" data-notify="url"></a>' +
                            '</div>'
                    });
                $('#btnCerraModalQRCode')[0].click();
                productsArray = [];
                displayProductos();

            });

        } else {

            $.notify({
                // options
                icon: 'glyphicon glyphicon-warning-sign',
                title: 'Compra fallida',
                message: 'No se puede realizar la compra porque este huésped ha cancelado su cuenta.'
            }, {
                    // settings
                    element: 'body',
                    position: null,
                    type: "danger",
                    allow_dismiss: true,
                    newest_on_top: false,
                    showProgressbar: false,
                    placement: {
                        from: "top",
                        align: "right"
                    },
                    offset: 20,
                    spacing: 10,
                    z_index: 1031,
                    delay: 5000,
                    timer: 1000,
                    url_target: '_blank',
                    mouse_over: null,
                    animate: {
                        enter: 'animated fadeInDown',
                        exit: 'animated fadeOutUp'
                    },
                    onShow: null,
                    onShown: null,
                    onClose: null,
                    onClosed: null,
                    icon_type: 'class',
                    template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                        '<button type="button" aria-hidden="true" class="close" data-notify="dismiss"></button>' +
                        '<span data-notify="icon"></span> ' +
                        '<span data-notify="title">{1}</span> ' +
                        '<span data-notify="message">{2}</span>' +
                        '<div class="progress" data-notify="progressbar">' +
                        '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                        '</div>' +
                        '<a href="{3}" target="{4}" data-notify="url"></a>' +
                        '</div>'
                });
            $('#btnCerraModalQRCode')[0].click();
        }

        

    })

    
}