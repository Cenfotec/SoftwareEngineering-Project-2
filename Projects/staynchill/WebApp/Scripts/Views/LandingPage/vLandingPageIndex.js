let data = {};
var productsArray = [];

function vLandingPageIndex() {
    this.service = 'hotel'
    this.ctrlActions = new ControlActions()
    this.formId = '#buscarHotel'
    this.formName = 'buscarHotel'

    this.Buscar = function () {
        let numPeople = $('#txtNumPeople')[0];

        // parseInt(numPeople.value) > parseInt(numPeople.max)
        if ($('#kt_daterangepicker_1')[0].value.replace(' ', '') == '' || numPeople.value.replace(' ', '') == '' || parseInt(numPeople.value) < parseInt(numPeople.min)) {
            Swal.fire({
                type: 'warning',
                title: 'Error de búsqueda',
                text: 'Por favor complete los datos de búsqueda. (Fechas de reservación y cantidad de personas)'
            })
        }
        //else if (new Date($('#kt_daterangepicker_1')[0].value.replace(/ /g, '').split('-')[0]) < new Date()) {
        //    Swal.fire({
        //        type: 'warning',
        //        title: 'Error de búsqueda',
        //        text: 'La fecha de inicio no puede ser anterior al día de hoy.'
        //    })
        //}
        else {
            let hotelName = $('#txtHotelName')[0].value;
            let fechaInicio = $('#kt_daterangepicker_1')[0].value.replace(/ /g, '').split('-')[0];
            let fechaFin = $('#kt_daterangepicker_1')[0].value.replace(/ /g, '').split('-')[1];

            data = {
                hotel: hotelName,
                inicio: fechaInicio,
                fin: fechaFin,
                personas: numPeople.value
            };

            localStorage.setItem('_searchHotel', JSON.stringify(data));
            location.href = '/hotels';
        }
    }

    this.getReservationInfo = function () {
        var user = JSON.parse(localStorage.getItem('_userLogged'));
        if (user.Rol == 'Administrador de plataforma' || user.Rol == 'Administrador de hotel') {

        } else {
            var methodPost = this.ctrlActions.GetMethodGetToApi('userreservation' + '/' + user.Id);
            methodPost.done(res => {
                localStorage.setItem('_userReservation', JSON.stringify(res.Data))
                res.Data != null ? this.FillAppModal(res.Data) : null



                var methodHotelCommissionGet = new ControlActions().GetMethodGetToApi('hotel/getCommission?hotel=' + JSON.parse(localStorage.getItem('_userReservation')).Hotel);
                methodHotelCommissionGet.done(res => {
                    hotelPaymentInfo = {
                        commission: res.Data.Commission,
                        email: res.Data.HotelEmail
                    }
                    localStorage.setItem('_hotelPaymentInfo', JSON.stringify(hotelPaymentInfo));
                });

            })
        }
        
    }

    this.getServicesInfo = function (hotel) {
        var methodGet = this.ctrlActions.GetMethodPostToAPI('service/getbyhotel', hotel);
        return methodGet;
    }


    this.getProductsInfo = function (idHotel, idService) {
        var methodGet = this.ctrlActions.GetMethodGetToApi('producto/' + 'GetProductsByHotelServicio' + '/' + idHotel + '/' + idService, idHotel);
        return methodGet;
    }

    this.getUserReservations = function () {
        var user = JSON.parse(localStorage.getItem('_userLogged'));
        if (user.Rol == 'Administrador de plataforma' || user.Rol == 'Administrador de hotel') {

        } else {
            var methodGet = this.ctrlActions.GetMethodGetToApi('reservation' + '/' + user.Id);
            methodGet.done(res => {
                this.FillReservationsModal(res.Data)
            })
        }
    }

    this.getProductosCarrito = function () {
        var carrito = JSON.parse(localStorage.getItem('_userReservation')).Carrito
        if(carrito != -1) {
            var prod = { FkCarrito: carrito }
            var methodGet = this.ctrlActions.GetMethodPostToAPI('productocarrito/getbycar/', prod);
            methodGet.done(res => {
                this.FillCarrito(res.Data)
            })
        } else {
            this.DontFillCarrito()
        }
    }

    this.getInfoPriceButton = function () {
        var estadoSub = JSON.parse(localStorage.getItem('_userReservation')).QRState;
        var subReservacion = JSON.parse(localStorage.getItem('_userReservation')).Subreservacion;
        var sub = { FkSubReservacion: subReservacion }
        var methodPost = this.ctrlActions.GetMethodPostToAPI('check/fechaOut/', sub);
        methodPost.done(res => {
            var date = new Date(res.Data.FkSubReservacion);
            var dd = date.getDate() + 1;
            var mm = date.getMonth() + 1;
            var y = date.getFullYear();

            var someFormattedDate = mm + '/' + dd + '/' + y;
            var actualDate = new Date();
            actualDate = actualDate.toLocaleDateString();
            var myDate = new Date(someFormattedDate)
            console.log(myDate.toLocaleDateString())
            console.log(actualDate)
            if(estadoSub == 'INVITADO_ENA'){
                document.querySelector('#btn-Check-out').style.display = "none"   
            }
            if (actualDate >= myDate.toLocaleDateString()) {
                console.log('dfsds')
                document.querySelector('#paypal-button-container2').style.display = "block"
                document.querySelector('#btn-Check-out').style.display = "none"
                document.querySelector('#btnAddCarrito').disabled = true

                document.querySelector('#btnAddCarrito').disabled = true    
                $('#btnAddCarrito')[0].innerText = 'Ya no se puede comprar';
                $('#btnAddCarrito')[0].style.backgroundColor = '#FD397A';
                document.querySelector('#btnInvitar').disabled = true;
                $('#btnInvitar')[0].innerText = 'No se puede invitar';
                $('#btnInvitar')[0].style.backgroundColor = '#FD397A';
            
            } else if (actualDate <= myDate.toLocaleDateString() && estadoSub == 'INVITADO_ENA'){
                document.querySelector('#btn-Check-out').style.display = "none"
                document.querySelector('#paypal-button-container2').style.display = "none"
                document.querySelector('#btnAddCarrito').disabled = false
            }else if (actualDate <= myDate.toLocaleDateString() && estadoSub == 'PROPIO_ENA'){
                document.querySelector('#btn-Check-out').style.display = "block"
                document.querySelector('#paypal-button-container2').style.display = "none"
                document.querySelector('#btnAddCarrito').disabled = false
            }
        })
    }

    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2
    })

    addCarrito = function (Product, price, cant) {

        ogPrice = Product.Price

        try {
            //Find index of specific object using findIndex method.    
            var objIndex = productsArray.findIndex((obj => Product.Id == obj.FkProducto));
        } catch (e) {
            console.log(e)
        }

        var carrito = JSON.parse(localStorage.getItem('_userReservation')).Carrito

        if (objIndex == -1) {
            var ProductoCarrito = {
                Cant: cant,
                NombreProducto: Product.Name,
                PrecioBruto: Product.Price,
                PrecioImpuesto: '0',
                FkProducto: Product.Id,
                FkCarrito: carrito
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
    }

    addQuantity = function (Product) {
        var priceReturn = Product.Price
        var actualQuantity = document.getElementsByClassName('kt-mycart__quantity' + Product.Id)[0].childNodes[0].textContent;
        document.getElementsByClassName('kt-mycart__quantity' + Product.Id)[0].childNodes[0].textContent = (parseInt(actualQuantity) + 1);
        if (actualQuantity != '0') {
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

    this.DontFillCarrito = function() {
        let parentCart = document.querySelector('#userCart')
        try {
            parentCart.innerHTML = ''
        } catch (e) {
            console.log(e)
        }
        let formCarrito = document.createElement('form')
        formCarrito.innerHTML = `
            <div class="kt-mycart">
                <div class="kt-mycart__head kt-head" style="background-image: url(./assets/media/misc/bg-1.jpg);">
                    <div class="kt-mycart__info">
                        <span class="kt-mycart__icon"><i class="flaticon2-shopping-cart-1 kt-font-success"></i></span>
                        <h3 class="kt-mycart__title">Mi Carrito</h3>
                    </div>
                    <div class="kt-mycart__button">
                        <button id="totalItems" type="button" class="btn btn-success btn-sm" style=" "></button>
                    </div>
                </div>
                <div id="userCartContent" class="kt-mycart__body kt-scroll" data-scroll="true" data-height="245" data-mobile-height="200">
                </div>
                            </div>
                                
                </div>
                </div>
        `
        parentCart.appendChild(formCarrito)

        var productsContent = document.querySelector('#userCartContent')
        productsContent.innerHTML = ""

        var productsContent = document.querySelector('#userCartContent')
            productsContent.innerHTML = ""
            var productDiv = document.createElement('div')
            productDiv.classList.add('kt-mycart__item')
            productDiv.innerHTML = `
                                <div class="kt-mycart__container">
                                <div class="kt-mycart__info">
                                    <a href="#" class="kt-mycart__title">
                                        Su fecha de reservación ha expirado, realice el check-out
                                    </a>
                                </div>
                                </div>        
                                `
            productsContent.appendChild(productDiv)
    }

    this.FillCarrito = function (productosCarrito) {
        var totalQuantity = 0;
        var totalPrice = 0;
        let parentCart = document.querySelector('#userCart')
        try {
            parentCart.innerHTML = ''
        } catch (e) {
            console.log(e)
        }
        let formCarrito = document.createElement('form')
        formCarrito.innerHTML = `
            <div class="kt-mycart">
                <div class="kt-mycart__head kt-head" style="background-image: url(./assets/media/misc/bg-1.jpg);">
                    <div class="kt-mycart__info">
                        <span class="kt-mycart__icon"><i class="flaticon2-shopping-cart-1 kt-font-success"></i></span>
                        <h3 class="kt-mycart__title">Mi Carrito</h3>
                    </div>
                    <div class="kt-mycart__button">
                        <button id="totalItems" type="button" class="btn btn-success btn-sm" style=" "></button>
                    </div>
                </div>
                <div id="userCartContent" class="kt-mycart__body kt-scroll" data-scroll="true" data-height="245" data-mobile-height="200">
                </div>
                                        <div class="kt-mycart__footer">
                            <div class="kt-mycart__section">
                                <div class="kt-mycart__subtitel">
                                    <span>Total</span>
                                </div>
                                <div class="kt-mycart__prices">
                                    <span id="spanTotalPrice" class="kt-font-brand">$ 0.00</span>
                                </div>
                            </div>
                                
                            <div class="kt-mycart__button kt-align-right">
                            <button type="button" id="btn-Check-out" onClick= "onCheckOutButtonPressed()" class="btn btn-primary btn-sm">Reducir estadía</button>
                            <div id="paypal-button-container2" class="">
                                
                                
                            </div>
                </div>
                </div>
        `
        parentCart.appendChild(formCarrito)

        var productsContent = document.querySelector('#userCartContent')
        productsContent.innerHTML = ""

        
        if(productosCarrito != null) {
            productosCarrito.forEach(function (obj) {
                totalPrice += obj.PrecioBruto
                totalQuantity++
                var fecha = new Date(obj.Fecha).toLocaleDateString();
                var productDiv = document.createElement('div')
                productDiv.classList.add('kt-mycart__item')
                productDiv.innerHTML = `
                            <div class="kt-mycart__container">
                                <div class="kt-mycart__info">
                                    <a href="#" class="kt-mycart__title">
                                        ${obj.NombreProducto}
                                    </a>
                                    <span class="kt-mycart__desc">
                                            Fecha de compra: ${fecha}
                                        </span>
                                    <div class="kt-mycart__action">
                                        <span class="kt-mycart__price${obj.Id}">Precio: ${formatter.format(obj.PrecioBruto)}</span>
                                        <span class="kt-mycart__text">&nbsp;Por&nbsp;</span>
                                        <span class="kt-mycart__quantity${obj.Cant}">${obj.Cant} unidades</span>
                                    </div>
                                </div>
                            </div>
                `
                productsContent.appendChild(productDiv)
            })
            document.querySelector('#totalItems').innerHTML = totalQuantity + ' items'
            document.querySelector('#spanTotalPrice').innerHTML = formatter.format(totalPrice);
            vLandingPage = new vLandingPageIndex();
            vLandingPage.getInfoPriceButton();
        } else {
            var productsContent = document.querySelector('#userCartContent')
            productsContent.innerHTML = ""
            var productDiv = document.createElement('div')
            productDiv.classList.add('kt-mycart__item')
            productDiv.innerHTML = `
                                <div class="kt-mycart__container">
                                <div class="kt-mycart__info">
                                    <a href="#" class="kt-mycart__title">
                                        No hay productos en su carrito
                                    </a>
                                </div>
                                </div>        
                                `
            productsContent.appendChild(productDiv)
            vLandingPage = new vLandingPageIndex();
            vLandingPage.getInfoPriceButton();

        }


        //=============================================//


        var PayPalClientSideLogicV3 = function () {
            var divId = ""
            var ctrlActions = new ControlActions()
            var service = 'paymentTransactionv2'

            var createOrder = function (data, actions) {
                var userReservation = JSON.parse(localStorage.getItem('_userReservation'));

                var cartData = {
                    basePrice: parseFloat($('#spanTotalPrice')[0].innerText.replace('$', ''))
                }

                var newOrder = {
                    amount: {
                        value: String(cartData.basePrice)
                    }
                }
                return actions.order.create({
                    purchase_units: [newOrder]
                });
            }

            var postPaymentTransaction = details => {

                console.log("details: ", details);

                var userReservation = JSON.parse(localStorage.getItem('_userReservation'));

                var totalPrice = parseFloat($('#spanTotalPrice')[0].innerText.replace('$', ''));


                var hotelPaymentInfo = JSON.parse(localStorage.getItem('_hotelPaymentInfo'));

                var cartData = {
                    basePrice: totalPrice,
                    comissionPercentageHotel: hotelPaymentInfo.commission
                }

                var CommissionTotal = (totalPrice / 100) * cartData.comissionPercentageHotel;

                var paymentTransactionV3 = {
                    OrderId: details.id,
                    PayerId: details.payer.payer_id,
                    TotalAmount: details.purchase_units[0] ? details.purchase_units[0].amount.value : "0",
                    CommissionPercentage: cartData.comissionPercentageHotel,
                    CommissionTotal,
                    BasePrice: totalPrice + CommissionTotal,
                    PaypalEmail: hotelPaymentInfo.email,
                    FkHotel: userReservation.Hotel,
                    Category: 'carrito'

                }

                var jqxhr = ctrlActions.GetMethodPostToAPI(service, paymentTransactionV3)

                return jqxhr
            }

            var onApprove = (data, actions) => {
                var logFunc = actions.order.capture();

                logFunc.then(details => {

                    var jqxhr2 = postPaymentTransaction(details)
                        .done((res) => {

                            // Product Logic

                            let userReservation = JSON.parse(localStorage.getItem('_userReservation'));

                            var prod = { FkCarrito: userReservation.Carrito }
                            var methodGetCarrito = ctrlActions.GetMethodPostToAPI('productocarrito/getbycar/', prod);
                            methodGetCarrito.done(res => {
                                let cartData = {
                                    productsArray: res.Data,
                                    correo: JSON.parse(localStorage.getItem('_userLogged')).Correo,
                                    hotel: userReservation.Hotel
                                };

                                var methodGetCarrito = ctrlActions.GetMethodPostToAPI('productocarrito/SendEmail', cartData);
                                methodGetCarrito.done(res_2 => {

                                    // Delete cart
                                    var methodDeleteCarrito = ctrlActions.GetMethodPostToAPI('check/deleteCar', { FkSubReservacion: userReservation.Carrito });
                                    methodDeleteCarrito.done(res_3 => {
                                        new vLandingPageIndex().DontFillCarrito();

                                        $.notify({
                                            // options
                                            icon: ' glyphicon glyphicon-ok-sign ',
                                            title: 'Compra exitosa',
                                            message: 'El pago de check-out ha sido realizado exitosamente.'
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
                                    });

                                });

                            });
                        })
                    return jqxhr2
                })
                return logFunc
            }
            var logic = {
                // Set up the transaction
                createOrder,

                // Finalize the transaction
                onApprove
            }
            return {
                getLogic: () => logic
            }
        }();

        paypal.Buttons(PayPalClientSideLogicV3.getLogic()).render('#paypal-button-container2');

        //=============================================//
    }

    this.FillReservationsModal = function (userReservations) {

        let parentMenuReservation = document.querySelector('#reservationsMenu');

        let formReservations = document.createElement('form');
        formReservations.innerHTML = `
        <div class="kt-head kt-head--skin-dark kt-head--fit-x kt-head--fit-b" style="background-image: url(./assets/media/misc/bg-1.jpg)">
        <h3 class="kt-head__title">Menú de Reservación</h3>
        <ul class="nav nav-tabs nav-tabs-line nav-tabs-bold nav-tabs-line-3x nav-tabs-line-success kt-notification-item-padding-x" role="tablist">
            </ul>
        </div>
        
        <div id="tabMenuParent" class="tab-content">

        <div class="tab-pane active" id="topbar_user_reservations" role="tabpanel">
        <div id="reservationsContent" class="kt-notification kt-margin-t-10 kt-margin-b-10 kt-scroll" data-scroll="true" data-height="300" data-mobile-height="200">

        </div>
        </div>
        </div>
        `

        parentMenuReservation.appendChild(formReservations)

        var tabReservationsContent = document.querySelector('#reservationsContent')

        if (userReservations != null) {
            userReservations.forEach(obj => {
                var beginDate = new Date(obj.BeginDate).toLocaleDateString();
                var endDate = new Date(obj.EndDate).toLocaleDateString();
                if (obj.Status == 'Finished') {
                    obj.Status = 'Reservación Finalizada'
                } else {
                    obj.Status = 'Reservación Activa'
                }

                var anchorReservation = document.createElement('a');
                anchorReservation.setAttribute('data-toggle', 'tab')
                anchorReservation.setAttribute('href', '#topbar_products')
                anchorReservation.setAttribute('role', 'tab')
                anchorReservation.setAttribute('data-target', obj.Id)
                anchorReservation.classList.add('kt-notification__item')
                anchorReservation.innerHTML = `
                        <div class="kt-notification__item-icon"> <i class="
                        flaticon-menu-button"></i> </div>
                        <div class="kt-notification__item-details">
                            <div class="kt-notification__item-title">${obj.Hotel} </div>
                            <div class="kt-notification__item-time">Número de cuarto: ${obj.RoomNum} </div>
                            <div class="kt-notification__item-time">Fecha: ${beginDate} a ${endDate} </div>
                            <div class="kt-notification__item-time-details">${obj.Status} </div>
                        </div>
            `

                tabReservationsContent.appendChild(anchorReservation)
            })
        } else {
            var anchorReservation = document.createElement('a');
            anchorReservation.setAttribute('data-toggle', 'tab')
            anchorReservation.setAttribute('role', 'tab')
            anchorReservation.classList.add('kt-notification__item')
            anchorReservation.innerHTML = `
                        <div class="kt-notification__item-icon"> <i class="
                        flaticon-menu-button"></i> </div>
                        <div class="kt-notification__item-details">
                            <div class="kt-notification__item-title">No ha realizado reservaciones</div>
                        </div>
            `

            tabReservationsContent.appendChild(anchorReservation)
        }

    }

    buttonPressed = function () {
        swal.fire({
            title: 'Agregar al carrito',
            text: "¿Está seguro que desea agregar estos productos?",
            type: 'info',
            showCancelButton: true,
            confirmButtonText: 'Aceptar',
            cancelButtonText: 'Cancelar'
        }).then(function (result) {
            if (result.value) {
                var vLandingPage = new vLandingPageIndex();
                var data = {}
                data.productsArray = productsArray
                //var myJsonString = JSON.stringify(productsArray);
                //console.log(myJsonString)
                var methodPost = vLandingPage.ctrlActions.GetMethodPostToAPI('productocarrito', data);
                methodPost.done(res => {
                    $.notify({
                        // options
                        icon: ' glyphicon glyphicon-ok-sign ',
                        title: 'Productos agregados',
                        message: 'Los productos han sido agregados exitosamente'
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
                    vLandingPage.getProductosCarrito();
                })
            }
        });
    }

    onCheckOutButtonPressed = function () {

        swal.fire({
            title: '¿Está seguro que desea reducir su estadía?',
            text: "Al reducir su estadía, su cuenta cambiará la fecha del desalojo del hotel al día de hoy",
            type: 'info',
            showCancelButton: true,
            confirmButtonText: 'Aceptar',
            cancelButtonText: 'Cancelar'
        }).then( (result) => {
            if (result.value) {
                var vLandingPage = new vLandingPageIndex();
                var subReservacion = JSON.parse(localStorage.getItem('_userReservation')).Subreservacion;
                var sub = { FkSubReservacion: subReservacion }
                
                var methodPost = vLandingPage.ctrlActions.GetMethodPostToAPI('check/changeOut/', sub);
                methodPost.done(res => {
                    console.log('checkout has changed')
                    document.querySelector('#paypal-button-container2').style.display = "block"
                    document.querySelector('#btn-Check-out').style.display = "none"

                    document.querySelector('#btnAddCarrito').disabled = true
                    $('#btnAddCarrito')[0].innerText = 'Ya no se puede comprar';
                    $('#btnAddCarrito')[0].style.backgroundColor = '#FD397A';
                    document.querySelector('#btnInvitar').disabled = true;
                    $('#btnInvitar')[0].innerText = 'No se puede invitar';
                    $('#btnInvitar')[0].style.backgroundColor = '#FD397A';
                })
            }
        }
    )}

    this.FillAppModal = function (reservationInfo) {

        let img = reservationInfo.QRCode;
        let inviteButton = (reservationInfo.QRState != 'INVITADO_ENA') ?
            `<button id="btnInvitar" data-toggle="modal" data-target="#kt_select2_modal" type="button" 
             onclick="getGeneratedQRCodes()" class="snc__search_button2">Invitar</button>` : ``;

        let parentMenu = document.querySelector('#userMenu');
        if (parentMenu != null) {
            parentMenu.innerHTML = "";

            let formMenu = document.createElement('form');
            formMenu.innerHTML = `

            <div class="kt-head kt-head--skin-dark kt-head--fit-x kt-head--fit-b" style="background-image: url(./assets/media/misc/bg-1.jpg)">
            <h3 class="kt-head__title">Menú de hotel</h3>
            <ul class="nav nav-tabs nav-tabs-line nav-tabs-bold nav-tabs-line-3x nav-tabs-line-success kt-notification-item-padding-x" role="tablist">
        
                <li class="nav-item"> <a class="nav-link active show" data-toggle="tab" href="#topbar_qr_codes" role="tab" aria-selected="true">Códigos QR</a> </li>
        
                <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#topbar_hotel_services" role="tab" aria-selected="true">Servicios</a> </li>
        
            </ul>
        </div>
        <div id="tabMenuParent" class="tab-content">
        
            <div class="tab-pane active" id="topbar_qr_codes" role="tabpanel">
                <div class="kt-notification kt-margin-t-10 kt-margin-b-10 kt-margin-l-60 kt-scroll" data-scroll="true" data-height="300" data-mobile-height="200">
                    <img class="kt-widget__img kt-hidden-" src="${'https://res.cloudinary.com/qubitscenfo/image/upload/' + img}" alt="image" style=" width: 250px; height: 250px;">
                </div>
                
                ${inviteButton}
                
            </div>
        
            <div class="tab-pane" id="topbar_hotel_services" role="tabpanel">
                <div id="servicesContent" class="kt-notification kt-margin-t-10 kt-margin-b-10 kt-scroll" data-scroll="true" data-height="300" data-mobile-height="200">
                </div>
            </div>
        
            <div class="tab-pane" id="topbar_products" role="tabpanel">
                <div class="kt-notification kt-margin-t-10 kt-margin-b-10 kt-scroll" data-scroll="true" data-height="300" data-mobile-height="200">
                    <a id="anchorVolver" data-toggle="tab" href="#topbar_hotel_services" role="tab"> <i class="flaticon2-back-1"></i> Volver</a>
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
                                <button id="btnAddCarrito" type="button" class="btn btn-primary btn-sm" onclick='buttonPressed()'>Agregar al carrito</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        `

            parentMenu.appendChild(formMenu);

            var hotel = {
                Id: reservationInfo.Hotel
            };

            this.getServicesInfo(hotel).done(function (result) {

                var services = result.Data

                //Se obtiene el parent donde van los servicios
                var tabServicesContent = document.querySelector('#servicesContent')

                if (result.Data != null) {

                    services.forEach(obj => {

                        var horaInicio = new Date(obj.OpeningSchedule).toTimeString().substr(0, 5)
                        var horaCierre = new Date(obj.ClosingSchedule).toTimeString().substr(0, 5)
                        var anchorService = document.createElement('a');
                        anchorService.setAttribute('data-toggle', 'tab')
                        anchorService.setAttribute('href', '#topbar_products')
                        anchorService.setAttribute('role', 'tab')
                        anchorService.setAttribute('data-target', obj.Id)
                        anchorService.classList.add('kt-notification__item')
                        anchorService.innerHTML = `
                        <div class="kt-notification__item-icon"> <i class="flaticon-buildings"></i> </div>
                        <div class="kt-notification__item-details">
                            <div class="kt-notification__item-title"> ${obj.Name} </div> <!--Nombre del servicio-->
                            <div class="kt-notification__item-time"> ${obj.Type} </div>
                            <div class="kt-notification__item-time"> Abierto de: ${horaInicio} a ${horaCierre}</div>
                        </div>
            `

                        tabServicesContent.appendChild(anchorService)

                        var element = `[data-target='${obj.Id}']`

                        document.querySelector(element).onclick = function () {

                            var vLandingPage = new vLandingPageIndex();
                            var getProductMethod = vLandingPage.getProductsInfo(reservationInfo.Hotel, obj.Id);

                            getProductMethod.then(function (response) {
                                var products = response.Data;
                                if (response.Data != null) {
                                    var productsContent = document.querySelector('#productsContent')
                                    productsContent.innerHTML = ""
                                    products.forEach(function (obj) {
                                        var productDiv = document.createElement('div')
                                        productDiv.classList.add('kt-mycart__item')
                                        productDiv.innerHTML = `
                                            <div class="kt-mycart__container">
                                                <div class="kt-mycart__info">
                                                    <a href="#" class="kt-mycart__title">
                                                        ${obj.Name}
                                                    </a>
                                                    <span class="kt-mycart__desc">
                                                            ${obj.Description}
                                                        </span>
                                                    <div class="kt-mycart__action">
                                                        <span class="kt-mycart__price${obj.Id}">${formatter.format(obj.Price)}</span>
                                                        <span class="kt-mycart__text">&nbsp;Por&nbsp;</span>
                                                        <span class="kt-mycart__quantity${obj.Id}">0</span>
                                                        <a id='anchorReduce${obj.Id}' class="btn btn-label-success btn-icon">&minus;</a>
                                                        <a id='anchorAdd${obj.Id}' class="btn btn-label-success btn-icon">&plus;</a>
                                                    </div>
                                                </div>
                                                <a href="#" class="kt-mycart__pic">
                                                   <img class="kt-widget__img kt-hidden-" src="${'https://res.cloudinary.com/qubitscenfo/image/upload/' + obj.Value}" alt="image">
                                                </a>
                                            </div>
                        `
                                        productsContent.appendChild(productDiv)
                                        document.getElementsByClassName('kt-font-brand')[0].childNodes[0].textContent = '$ 0.00';

                                        document.querySelector('#anchorReduce' + obj.Id).onclick = function () {
                                            reduceQuantity(obj)
                                        }
                                        document.querySelector('#anchorAdd' + obj.Id).onclick = function () {
                                            addQuantity(obj)
                                        }
                                    })
                                    document.getElementsByClassName('kt-font-brand')[0].childNodes[0].textContent = '$ 0.00';
                                    document.querySelector('#topbar_hotel_services').classList.remove('active')
                                    document.querySelector('#topbar_products').classList.add('active')
                                    productsArray.length = 0
                                } else {
                                    var productsContent = document.querySelector('#productsContent')
                                    productsContent.innerHTML = ""
                                    var productDiv = document.createElement('div')
                                    productDiv.classList.add('kt-mycart__item')
                                    productDiv.innerHTML = `
                                <div class="kt-mycart__container">
                                <div class="kt-mycart__info">
                                    <a href="#" class="kt-mycart__title">
                                        Actualmente no hay productos en este servicio
                                    </a>
                                </div>
                                </div>        
                                `
                                    productsContent.appendChild(productDiv)
                                    document.querySelector('#topbar_hotel_services').classList.remove('active')
                                    document.querySelector('#topbar_products').classList.add('active')
                                    document.getElementsByClassName('kt-font-brand')[0].childNodes[0].textContent = '$ 0.00';
                                }
                            })
                        }
                    })
                } else {
                    var anchorService = document.createElement('a')
                    anchorService.setAttribute('data-toggle', 'tab')
                    anchorService.setAttribute('role', 'tab')
                    anchorService.classList.add('kt-notification__item')
                    anchorService.innerHTML = `
                        <div class="kt-notification__item-details">
                            <div class="kt-notification__item-title"> Actualmente no hay servicios en el hotel </div>
                        </div>
            `

                    tabServicesContent.appendChild(anchorService)
                }
            })
            new vLandingPageIndex().getProductosCarrito();
            var carrito = JSON.parse(localStorage.getItem('_userReservation')).Carrito
            if(carrito == -1) {
                document.querySelector('#btnAddCarrito').disabled = true    
                $('#btnAddCarrito')[0].innerText = 'Ya no se puede comprar';
                $('#btnAddCarrito')[0].style.backgroundColor = '#FD397A';
                document.querySelector('#btnInvitar').disabled = true;
                $('#btnInvitar')[0].innerText = 'No se puede invitar';
                $('#btnInvitar')[0].style.backgroundColor = '#FD397A';
            }
        }
    }
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vLandingPage = new vLandingPageIndex();
    vLandingPage.getReservationInfo();
    vLandingPage.getUserReservations();
    //vLandingPage.getProductosCarrito();
    $('#txtNumPeople')[0].min = "1";
    //$('#txtNumPeople')[0].max = "20";

    // Get Commission Hotel
    
});