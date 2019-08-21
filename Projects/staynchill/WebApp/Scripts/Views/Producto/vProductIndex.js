let cardData = {};

function vProductIndex() {

    this.service = 'GetProductsByHotelServicio';
    this.ctrlActions = new ControlActions();

    this.LoadProducts = function () {
        var idHotel = JSON.parse(localStorage.getItem('Hotel_selected')).Id;
        var idService = JSON.parse(localStorage.getItem('Service_selected')).Id;
        var productRequest = this.ctrlActions.GetMethodGetToApi('producto/' + this.service + '/' + idHotel + '/' + idService, idHotel);
        productRequest.done(response => {
            if (response.Data == null) {
                this.showEmpty();
                cardData = response.Data;
            } else {
                cardData = response.Data;
                CreateCards(response.Data);
            }
        });
    }

    this.showEmpty = function () {
        let parentProductsCards = document.querySelector('#parentProductsCards');
        parentProductsCards.innerHTML = '';

        let div = document.createElement('div');


        div.innerHTML = `

                    <div id="card-nodata" class="col-lg-12 text-center">
                        <h1 style="margin: 10rem 10rem 0 10rem;">No hay productos en este servicio</h1>
                        <p style="font-size: 16px;">Presione el botón de Añadir Producto para iniciar</p>
                    </div>

                `;

        parentProductsCards.appendChild(div);
    }


    this.InitSearch = function (searchId) {
        document.querySelector('#' + searchId).addEventListener('keyup', this.Search);
    }

    this.Search = function (e) {
        let parentProductsCards = document.querySelector('#parentProductsCards');
        parentProductsCards.innerHTML = '';
        CreateCards(cardData, e.srcElement.value);
    }




}

//ON DOCUMENT READY
$(document).ready(function () {
    var vProduct = new vProductIndex();
    vProduct.LoadProducts();
    vProduct.InitSearch('generalSearch');
});

const formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
    minimumFractionDigits: 2
})

CreateCards = function (res, search) {
    let parentProductsCards = document.querySelector('#parentProductsCards');
    parentProductsCards.innerHTML = '';

    for (let i = 0; i < res.length; i++) {
        let searchCriteria = res[i]['Name'];
        if (searchCriteria.toLowerCase().includes(((search == undefined) ? "" : search.trim().toLowerCase())) || search == undefined) {
            let colLG = document.createElement('div');
            let price = res[i]['Price'];
            price = formatter.format(price);
            colLG.innerHTML = `
            <!--Begin::Portlet-->
                <div class="kt-portlet kt-portlet--height-fluid">
                    <div class="kt-widget__head kt-widget__head--noborder">
                        <div class="kt-widget__head-label">
                            <button data-id-delete=${res[i]['Id']} type="button" class="btn btn-danger btn-sm btn-upper float-right">x</button>
                        </div>
                    </div>
                    <div class="kt-portlet__body">

                        <!--begin::Widget -->
                        <div class="kt-widget kt-widget--user-profile-2">
                            <div class="kt-widget__head">
                                <div class="kt-widget__media">
                                    <img class="kt-widget__img kt-hidden-" src="${'https://res.cloudinary.com/qubitscenfo/image/upload/' + res[i]['Value']}" alt="image">                       
                                </div>
                                <div class="kt-widget__info">
                                    <a class="kt-widget__username">
                                        ${res[i]['Name']} (x${res[i]['Cant']})
                                    </a>
                                    <span class="kt-widget__desc">
                                        ${price}
                                    </span>
                                    <div class="kt-widget__contact">
                                        ${res[i]['Description']}
                                    </div>
                                </div>
                            </div>
                            <div class="kt-widget__footer">
                                <button data-id-update=${res[i]['Id']} type="button" class="btn btn-label-success btn-sm btn-upper">modificar</button>
                            </div>
                        </div>

                        <!--end::Widget -->
                    </div>
                </div>

                <!--End::Portlet-->`

            colLG.classList.add('col-xl-4');
            

            parentProductsCards.appendChild(colLG);

            var element = `[data-id-update='${res[i]['Id']}']`
            document.querySelector(element).onclick = function () {
                localStorage.setItem('Product_selected', JSON.stringify(res[i]));
                javascript: location.href = '/dashboard/service/product/edit';
            }

            var deleteElement = `[data-id-delete='${res[i]['Id']}']`
            document.querySelector(deleteElement).onclick = function () {
                ShowDelete(res[i]);
            }
        }

    }
}


ShowDelete = function (res) {
    swal.fire({
        title: 'Eliminar Producto',
        text: "¿Está seguro que desea eliminar este producto?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar'
    }).then(function (result) {
        if (result.value) {
            DeleteCards(res)
        }
    });
}

DeleteCards = function (res) {
    var productRequest = new ControlActions().GetMethodDeleteToAPI('producto', res);
    productRequest.done(response => {
        new vProductIndex().LoadProducts();
    });
}