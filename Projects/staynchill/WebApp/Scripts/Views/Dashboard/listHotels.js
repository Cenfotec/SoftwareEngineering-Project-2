let cardData = {};
function listarHoteles() {
    this.service = 'hotel';
    this.ctrlActions = new ControlActions();
    var user = JSON.parse(localStorage.getItem('_userLogged'));

    this.LoadHotels = function () {
        var usuario = { Id: user.Id };
        var data = this.ctrlActions.GetMethodPostToAPI('hotel/getbyid', usuario);
        data.done(response => {
            if (response.Data == null) {
                this.showEmpty();
            } else {
                cardData = response.Data;
                CreateCards(response.Data);
            }
        });
    }

    this.showEmpty = function () {
        let parentProductsCards = document.querySelector('#parentHotelCards');
        parentProductsCards.innerHTML = '';

        let div = document.createElement('div');

        if (JSON.parse(localStorage.getItem('_userLogged')).Rol != 'Administrador de plataforma') {
            div.innerHTML = `

                    <div id="card-nodata" class="col-lg-12 text-center">
                        <h1 style="margin: 10rem 10rem 0 10rem;">Bienvenido ${user.Nombre} ${user.Apellido}</h1>
                        <p style="font-size: 16px;">${user.Rol}</p>
                    </div>

                `;

            parentProductsCards.appendChild(div);
        }
        
    }

    this.InitSearch = function (searchId) {
        document.querySelector('#' + searchId).addEventListener('keyup', this.Search);
    }

    this.Search = function (e) {
        let parentProductsCards = document.querySelector('#parentHotelCards');
        parentProductsCards.innerHTML = '';
        CreateCards(cardData, e.srcElement.value);
    }
}


jQuery(function () {
    if (JSON.parse(localStorage.getItem('_userLogged')).Rol != 'Administrador de plataforma') {
        var vlistarHoteles = new listarHoteles();
        vlistarHoteles.LoadHotels();
        vlistarHoteles.InitSearch('generalSearch');
    }
});


CreateCards = function (data, search) {
    let parentHotelCards = document.querySelector('#parentHotelCards');
    parentHotelCards.innerHTML += `
`
    for (let i = 0; i < data.length; i++) {

        let searchCriteria = data[i]['Name'];
        if (searchCriteria.toLowerCase().includes(((search == undefined) ? "" : search.trim().toLowerCase())) || search == undefined) {

            let hotelName = data[i]['Name'];

            let colLG = document.createElement('div');


            colLG.innerHTML = `

                <div class= "kt-portlet kt-iconbox kt-iconbox--animate">

                <div class="kt-portlet__body">

                    <div class="kt-iconbox__body">

                        <div class="kt-iconbox__icon">

                            <svg xmlns="http://www.w3.org/2000/svg" xmlns: xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
                            <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                <rect id="bound" x="0" y="0" width="24" height="24" />
                                <path d="M13.5,21 L13.5,18 C13.5,17.4477153 13.0522847,17 12.5,17 L11.5,17 C10.9477153,17 10.5,17.4477153 10.5,18 L10.5,21 L5,21 L5,4 C5,2.8954305 5.8954305,2 7,2 L17,2 C18.1045695,2 19,2.8954305 19,4 L19,21 L13.5,21 Z M9,4 C8.44771525,4 8,4.44771525 8,5 L8,6 C8,6.55228475 8.44771525,7 9,7 L10,7 C10.5522847,7 11,6.55228475 11,6 L11,5 C11,4.44771525 10.5522847,4 10,4 L9,4 Z M14,4 C13.4477153,4 13,4.44771525 13,5 L13,6 C13,6.55228475 13.4477153,7 14,7 L15,7 C15.5522847,7 16,6.55228475 16,6 L16,5 C16,4.44771525 15.5522847,4 15,4 L14,4 Z M9,8 C8.44771525,8 8,8.44771525 8,9 L8,10 C8,10.5522847 8.44771525,11 9,11 L10,11 C10.5522847,11 11,10.5522847 11,10 L11,9 C11,8.44771525 10.5522847,8 10,8 L9,8 Z M9,12 C8.44771525,12 8,12.4477153 8,13 L8,14 C8,14.5522847 8.44771525,15 9,15 L10,15 C10.5522847,15 11,14.5522847 11,14 L11,13 C11,12.4477153 10.5522847,12 10,12 L9,12 Z M14,12 C13.4477153,12 13,12.4477153 13,13 L13,14 C13,14.5522847 13.4477153,15 14,15 L15,15 C15.5522847,15 16,14.5522847 16,14 L16,13 C16,12.4477153 15.5522847,12 15,12 L14,12 Z" id="Combined-Shape" fill="#000000" />
                                <rect id="Rectangle-Copy-2" fill="#FFFFFF" x="13" y="8" width="3" height="3" rx="1" />
                                <path d="M4,21 L20,21 C20.5522847,21 21,21.4477153 21,22 L21,22.4 C21,22.7313708 20.7313708,23 20.4,23 L3.6,23 C3.26862915,23 3,22.7313708 3,22.4 L3,22 C3,21.4477153 3.44771525,21 4,21 Z" id="Rectangle-2" fill="#000000" opacity="0.3" />
                            </g>
                        </svg>
                    </div>

                    <div class="kt-iconbox__desc">

                        <h3 class="kt-iconbox__title">

                            <a class="kt-link">${hotelName}</a>

                        </h3>

                        <div class="kt-iconbox__content">

                        </div>

                    </div>

                </div>

            </div >

        </div >

            `;

            colLG.classList.add('col-lg-4');

            colLG.onclick = function () {
                localStorage.setItem('Hotel_selected', JSON.stringify(data[i]));
                javascript: location.replace('/dashboard/hotel')
            }

            parentHotelCards.appendChild(colLG);
        }
    }

}

//<script>
//    $(document).ready(function () {
//        var table = $('#-#Id-').DataTable();
//        $('#-#Id- tbody').on('click', 'tr', function () { //haceruna funcion de onclick que haga la redireccion
//            var data = table.row(this).data(); //este data es el que carga los elementos del card
//    localStorage.setItem('-#Id-_selected', JSON.stringify(data)); //se setea la data
//}
//});
//});
//</script>