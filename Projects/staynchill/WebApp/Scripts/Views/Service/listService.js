function vListService() {
    this.service = 'service'
    this.ctrlActions = new ControlActions()
    this.formId = '#listService'
    this.formName = 'listService'
    this.currentModel = {}

    this.RetrieveInfo = function () {

        //html
        let type = document.querySelector('#type');
        let openingHour = document.querySelector('#ophour');
        let closingHour = document.querySelector('#clhour');
        let descripcion = document.querySelector('#descripcion');
        let cedula = document.querySelector('#cedula');

        //js
        var data = JSON.parse(localStorage.getItem('Service_selected'));
        //var hotel = { Id: data.Id };
        //var methodPost = this.ctrlActions.GetMethodPostToAPI('service/getbyhotel', hotel);
        //methodPost.done(res => {
        //    this.RetrieveServices(res.Data)
        //})

        nombreServicio.textContent = data['Name'];
        let istatus = document.createElement('i');
        istatus.setAttribute('class', 'flaticon2-correct kt-font-success');
        nombreServicio.appendChild(istatus);

        let itype = document.createElement('i');
        itype.setAttribute('class', 'flaticon-buildings');
        type.appendChild(itype);
        let serviceType = document.createElement('Node');
        serviceType.textContent = data['Type'];
        type.appendChild(serviceType);

        let iopHour = document.createElement('i');
        iopHour.setAttribute('class', 'flaticon-calendar-with-a-clock-time-tools');
        openingHour.appendChild(iopHour);
        let serviceOpHour = document.createElement('Node');
        var date = new Date(data['OpeningSchedule']);
        var opHourTime = date.toTimeString().substr(0, 8)
        serviceOpHour.textContent = opHourTime;
        openingHour.appendChild(serviceOpHour);

        let icloHour = document.createElement('i');
        icloHour.setAttribute('class', 'flaticon-calendar-with-a-clock-time-tools');
        closingHour.appendChild(icloHour);
        let serviceCloHour = document.createElement('Node');
        var date = new Date(data['ClosingSchedule']);
        var clHourTime = date.toTimeString().substr(0, 8)
        serviceCloHour.textContent = clHourTime;
        closingHour.appendChild(serviceCloHour);

        descripcion.textContent = data['Description'];

        if (data['LegalNumber'] = '0') {
            cedula.textContent = 'Cédula jurídica: ' + 'N/A';
        } else {
            cedula.textContent = 'Cédula jurídica: ' + data['LegalNumber'];
        }


    }

    this.RetrieveServices = function (data) {
        let parentServicesCards = document.querySelector('#parentProductsCards');
        for (let i = 0; i < data.length; i++) {
            let serviceName = data[i]['Name'];
            let serviceType = data[i]['Type'];
            let colLG = document.createElement('div');
            colLG.innerHTML = `
                <div class="kt-portlet kt-iconbox kt-iconbox--warning kt-iconbox--animate-fast">
										<div class="kt-portlet__body">
											<div class="kt-iconbox__body">
												<div class="kt-iconbox__icon">
													<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1" class="kt-svg-icon">
    <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
        <rect id="bound" x="0" y="0" width="24" height="24"/>
        <path d="M3.95709826,8.41510662 L11.47855,3.81866389 C11.7986624,3.62303967 12.2013376,3.62303967 12.52145,3.81866389 L20.0429,8.41510557 C20.6374094,8.77841684 21,9.42493654 21,10.1216692 L21,19.0000642 C21,20.1046337 20.1045695,21.0000642 19,21.0000642 L4.99998155,21.0000673 C3.89541205,21.0000673 2.99998155,20.1046368 2.99998155,19.0000673 L2.99999828,10.1216672 C2.99999935,9.42493561 3.36258984,8.77841732 3.95709826,8.41510662 Z M10,13 C9.44771525,13 9,13.4477153 9,14 L9,17 C9,17.5522847 9.44771525,18 10,18 L14,18 C14.5522847,18 15,17.5522847 15,17 L15,14 C15,13.4477153 14.5522847,13 14,13 L10,13 Z" id="Combined-Shape" fill="#000000"/>
    </g>
</svg> </div>
												<div class="kt-iconbox__desc">
													<h3 class="kt-iconbox__title">
														<a class="kt-link" href="#">${serviceName}</a>
													</h3>
													<div class="kt-iconbox__content">
														${serviceType}
													</div>
												</div>
											</div>
										</div>
									</div>
            `;

            colLG.classList.add('col-lg-4');
            

            parentServicesCards.appendChild(colLG);

        }
    }

    this.ShowDelete = function (res) {
        swal.fire({
            title: 'Eliminar Servicios',
            text: "¿Está seguro que desea eliminar este servicio?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Eliminar',
            cancelButtonText: 'Cancelar'
        }).then(function (result) {
            if (result.value) {
                DeleteServiceCards(res)
            }
        });
    }
}
//ON DOCUMENT READY
$(document).ready(function () {

    var vlistService = new vListService();
    vlistService.RetrieveInfo();
    var data = JSON.parse(localStorage.getItem('Service_selected'));
    document.querySelector("#btnEliminarServicio").onclick = function () {
        vlistService.ShowDelete(data);
    }
});

DeleteServiceCards = function (res) {
    var productRequest = new ControlActions().GetMethodDeleteToAPI('service', res);
    productRequest.done(response => {
        javascript: location.href = '/dashboard/hotel';
        localStorage.removeItem('Service_selected');
    });
}