let cardData = {};

function vSubadministrator() {

    this.service = 'GetSubAdminByIdHotel';
    this.ctrlActions = new ControlActions();

    this.LoadSubadministrators = function () {
        var idHotel = JSON.parse(localStorage.getItem('Hotel_selected')).Id;
        var userLoginRequest = this.ctrlActions.GetMethodGetToApi('user/GetSubAdminByIdHotel/' + idHotel, idHotel);
        userLoginRequest.done(response => {if (response.Data == null) {
                this.showEmpty();
            } else {
                cardData = response.Data;
                CreateCards(response.Data);              
            }
            

            
        });
    }

    this.showEmpty = function () {
        let parentSubadministratorCards = document.querySelector('#parentSubadministratorCards');
        
        let div = document.createElement('div');


        div.innerHTML = `

                    <div id="card-nodata" class="col-lg-12 text-center">
                        <h1 style="margin: 10rem 10rem 0 10rem;">No hay subadministradores en este hotel</h1>
                        <p style="font-size: 16px;">Presione el botón de Añadir Subadministrador para iniciar</p>
                    </div>

                `;

        parentSubadministratorCards.appendChild(div);
    }


    this.InitSearch = function (searchId) {
        document.querySelector('#' + searchId).addEventListener('keyup', this.Search);
    }

    this.Search = function (e) {
        let parentSubadministratorCards = document.querySelector('#parentSubadministratorCards');
        parentSubadministratorCards.innerHTML = '';
        CreateCards(cardData, e.srcElement.value);
    }



    
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vSubAdmin = new vSubadministrator();
    vSubAdmin.LoadSubadministrators();
    vSubAdmin.InitSearch('generalSearch');
});




CreateCards = function (res, search) {
    let parentSubadministratorCards = document.querySelector('#parentSubadministratorCards');

    for (let i = 0; i < res.length; i++) {
        let searchCriteria = res[i]['Nombre'] + ' ' + res[i]['Apellido'];
        if (searchCriteria.toLowerCase().includes( ((search == undefined) ? "" : search.trim().toLowerCase()) ) || search == undefined) {
            let colLG = document.createElement('div');
            colLG.innerHTML = `

    <!--Begin::Portlet-->
    <div class="kt-portlet kt-portlet--height-fluid">
        <div class="kt-portlet__head kt-portlet__head--noborder">
            <div class="kt-portlet__head-label">
                <h3 class="kt-portlet__head-title"></h3>
            </div>
        </div>
        <div class="kt-portlet__body">

            <!--begin::Widget -->
            <div class="kt-widget kt-widget--user-profile-2">
                <div class="kt-widget__head">
                    <div class="kt-widget__media">
                        <img class="kt-widget__img kt-hidden-" src="${'https://res.cloudinary.com/qubitscenfo/image/upload/' + res[i]['Contrasenna']}" alt="image">
                        <div class="kt-widget__pic kt-widget__pic--warning kt-font-warning kt-font-boldest kt-hidden">
                            TF
                        </div>
                    </div>
                    <div class="kt-widget__info">
                        <a href="#" class="kt-widget__username">
                            ${res[i]['Nombre']} ${res[i]['Apellido']}
                        </a>
                        <span class="kt-widget__desc">
                            Subadministrador
                        </span>
                    </div>
                </div>
                <div class="kt-widget__body">
                    <div class="kt-widget__item">
                        <div class="kt-widget__contact">
                            <span class="kt-widget__label">Correo:</span>
                            <a href="#" class="kt-widget__data">${res[i]['Correo']}</a>
                        </div>
                        <div class="kt-widget__contact">
                            <span class="kt-widget__label">Teléfono:</span>
                            <a href="#" class="kt-widget__data">${res[i]['Telefono']}</a>
                        </div>
                        <div class="kt-widget__contact">
                            <span class="kt-widget__label">Provincia:</span>
                            <span class="kt-widget__data">${res[i]['Provincia']}</span>
                        </div>
                    </div>
                </div>
                <div class="kt-widget__footer">
                    <button data-toggle="modal" data-target="#kt_select2_modal" data-id-asignar=${res[i]['Id']} type="button" class="btn btn-label-success btn-lg btn-upper">asignar rol</button>
                </div>
            </div>

            <!--end::Widget -->
        </div>
    </div>

    <!--End::Portlet-->`

            colLG.classList.add('col-xl-3');


            parentSubadministratorCards.appendChild(colLG);

            var element = `[data-id-asignar='${res[i]['Id']}']`
            document.querySelector(element).onclick = function () {
            localStorage.setItem('Subadministrator_selected_id', res[i].Id);
            localStorage.setItem('Subadministrator_selected_correo', res[i].Correo);
            fillAsignarRolData();
            }
        }

    }
}