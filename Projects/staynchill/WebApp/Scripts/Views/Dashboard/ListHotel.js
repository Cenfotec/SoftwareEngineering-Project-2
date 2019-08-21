function vListHotel() {
    this.service = 'hotel'
    this.ctrlActions = new ControlActions()
    this.formId = '#listHotel'
    this.formName = 'listHotel'
    this.currentModel = {}

    this.RetrieveInfo = function () {

        //html
        let divCarousel = document.querySelector('#carousel');
        let email = document.querySelector('#email');
        let phone = document.querySelector('#phone');
        let stars = document.querySelector('#stars');
        let descripcion = document.querySelector('#descripcion');
        let cedula = document.querySelector('#cedula');
        let nombreEmpresa = document.querySelector('#nombreEmpresa');
        let nombreCadena = document.querySelector('#nombreCadena');
        let direccion = document.querySelector('#direccion');

        //js
        var data = JSON.parse(localStorage.getItem('Hotel_selected'));
        var hotel = { Id: data.Id };
        var methodPost = this.ctrlActions.GetMethodPostToAPI('service/getbyhotel', hotel);
        methodPost.done(res => {
            this.RetrieveServices(res.Data)
        })



        imgs = data['Value'].split(',');
        let i = 0;
        $.each(imgs, function (index, value) {
            if (i == 0) {
                let divItemActiveCarousel = document.createElement('div');
                divItemActiveCarousel.setAttribute('class', 'item active');
                let img = document.createElement('img');
                img.classList.add('d-block');
                img.classList.add('w-100');
                img.src = 'https://res.cloudinary.com/qubitscenfo/image/upload/' + value;
                divItemActiveCarousel.appendChild(img);
                divCarousel.appendChild(divItemActiveCarousel);
                i++
            } else {
                let divItemActiveCarousel = document.createElement('div');
                divItemActiveCarousel.setAttribute('class', 'item');
                let img = document.createElement('img');
                img.classList.add('d-block');
                img.classList.add('w-100');
                img.src = 'https://res.cloudinary.com/qubitscenfo/image/upload/' + value;
                divItemActiveCarousel.appendChild(img);
                divCarousel.appendChild(divItemActiveCarousel);
            }
        });

        nombreHotel.textContent = data['Name'];
        let istatus = document.createElement('i');
        istatus.setAttribute('class', 'flaticon2-correct kt-font-success');
        nombreHotel.appendChild(istatus);

        let iemail = document.createElement('i');
        iemail.setAttribute('class', 'flaticon2-new-email');
        email.appendChild(iemail);
        let hotelEmail = document.createElement('Node');
        hotelEmail.textContent = data['Email'];
        email.appendChild(hotelEmail);
        console.log(data['Email']);

        let iphone = document.createElement('i');
        iphone.setAttribute('class', 'flaticon2-phone');
        phone.appendChild(iphone);
        let hotelPhone = document.createElement('Node');
        hotelPhone.textContent = data['PhoneNumber'];
        phone.appendChild(hotelPhone);

        let istar = document.createElement('i');
        istar.setAttribute('class', 'flaticon-star');
        stars.appendChild(istar);
        let hotelStars = document.createElement('Node');
        hotelStars.textContent = data['Stars'];
        stars.appendChild(hotelStars);

        descripcion.textContent = data['Description'];

        cedula.textContent = 'Cédula jurídica: ' + data['LegalNumber'];

        nombreEmpresa.textContent = 'Nombre empresa: ' + data['BusinessName'];

        nombreCadena.textContent = 'Nombre cadena: ' + data['BusinessChain'];

        direccion.textContent = 'Dirección: ' + data['Province'] + ', ' + data['Canton'] + ', ' + data['District'];

        document.querySelector('#txtLat').value = data['Latitude'];

        document.querySelector('#txtLng').value = data['Longitude']

    }

    this.RetrieveServices = function (data) {
        let parentServicesCards = document.querySelector('#parentServicesCards');
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

            colLG.onclick = function () {
                localStorage.setItem('Service_selected', JSON.stringify(data[i]));
                javascript: location.href = '/dashboard/service';
            }

            parentServicesCards.appendChild(colLG);

        }
    }

    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2
    })

    this.RetrieveTotalReservationsByMonth = function (id) {
        var methodGet = this.ctrlActions.GetMethodGetToApi('hotelstats' + '/gettotalreservationsbymonth/' + id);
        methodGet.done(res => {
            document.querySelector('#txtTotalresbymonth').textContent = res.Data[0].TotalReservations;
            console.log(res.Data[0])
        })
    }
    this.RetrieveTotalIncome = function (id) {
        var methodGet = this.ctrlActions.GetMethodGetToApi('hotelstats' + '/gethotelyotalincome/' + id);
        methodGet.done(res => {
        })
    }

    this.RetrieveAverageIncome = function (id) {
        var methodGet = this.ctrlActions.GetMethodGetToApi('hotelstats' + '/gethotelanualaverageincome/' + id);
        methodGet.done(res => {
            document.querySelector('#txtTotalIncome').textContent = formatter.format(res.Data[0].AvgTotal);
            console.log(res.Data[0])
        })
    }

    this.RetrieveHotelIncomemonth = function (id) {
        var methodGet = this.ctrlActions.GetMethodGetToApi('hotelstats' + '/getretrievehotelincomebymonth/' + id);
        methodGet.done(res => {

            if (res.Data != null) {

                var parentChart = document.querySelector('#chartInfo');
                var chart = document.createElement('div');
                chart.classList.add('widget12__chart');
                chart.style.height('250px');
                parentChart.appendChild(chart);
            }

            var months = [];
            for (let prop in res.Data) {
                months.push(res.Data[prop].MonthSale);
            }

            var cantVentas = [];
            for (let prop in res.Data) {
                cantVentas.push(res.Data[prop].CantSales);
            }

            var container = KTUtil.getByID('kt_chart_order_statistics');
            if (!container) {
                return;
            }
            var MONTHS = ['1 Jan', '2 Jan', '3 Jan', '4 Jan', '5 Jan', '6 Jan', '7 Jan'];
            var color = Chart.helpers.color;
            var barChartData = {
                labels: months,
                datasets: [
                    {
                        fill: true,
                        //borderWidth: 0,
                        backgroundColor: color(KTApp.getStateColor('brand')).alpha(0.6).rgbString(),
                        borderColor: color(KTApp.getStateColor('brand')).alpha(0).rgbString(),

                        pointHoverRadius: 4,
                        pointHoverBorderWidth: 12,
                        pointBackgroundColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointBorderColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointHoverBackgroundColor: KTApp.getStateColor('brand'),
                        pointHoverBorderColor: Chart.helpers.color('#000000').alpha(0.1).rgbString(),

                        data: cantVentas
                    }
                ]
            };

            var ctx = container.getContext('2d');
            var chart = new Chart(ctx, {
                type: 'line',
                data: barChartData,
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    legend: false,
                    scales: {
                        xAxes: [{
                            categoryPercentage: 0.35,
                            barPercentage: 0.70,
                            display: true,
                            scaleLabel: {
                                display: false,
                                labelString: 'Month'
                            },
                            gridLines: false,
                            ticks: {
                                display: true,
                                beginAtZero: true,
                                fontColor: KTApp.getBaseColor('shape', 3),
                                fontSize: 13,
                                padding: 10
                            }
                        }],
                        yAxes: [{
                            categoryPercentage: 0.35,
                            barPercentage: 0.70,
                            display: true,
                            scaleLabel: {
                                display: false,
                                labelString: 'Value'
                            },
                            gridLines: {
                                color: KTApp.getBaseColor('shape', 2),
                                drawBorder: false,
                                offsetGridLines: false,
                                drawTicks: false,
                                borderDash: [3, 4],
                                zeroLineWidth: 1,
                                zeroLineColor: KTApp.getBaseColor('shape', 2),
                                zeroLineBorderDash: [3, 4]
                            },
                            ticks: {
                                max: 70,
                                stepSize: 10,
                                display: true,
                                beginAtZero: true,
                                fontColor: KTApp.getBaseColor('shape', 3),
                                fontSize: 13,
                                padding: 10
                            }
                        }]
                    },
                    title: {
                        display: false
                    },
                    hover: {
                        mode: 'index'
                    },
                    tooltips: {
                        enabled: true,
                        intersect: false,
                        mode: 'nearest',
                        bodySpacing: 5,
                        yPadding: 10,
                        xPadding: 10,
                        caretPadding: 0,
                        displayColors: false,
                        backgroundColor: KTApp.getStateColor('brand'),
                        titleFontColor: '#ffffff',
                        cornerRadius: 4,
                        footerSpacing: 0,
                        titleSpacing: 0
                    },
                    layout: {
                        padding: {
                            left: 0,
                            right: 0,
                            top: 5,
                            bottom: 5
                        }
                    }
                }
            });
        })
    }

    this.RetrieveHotelhotelanual = function (id) {
        var methodGet = this.ctrlActions.GetMethodGetToApi('hotelstats' + '/gethotelanualtotalincome/' + id);
        methodGet.done(res => {
            console.log(res.Data[0])
            document.querySelector('#txtAnualAverageIncome').textContent = formatter.format(res.Data[0].SumBasePrice);
        })
    }


    var now = moment().format('LLLL');
    document.querySelector('#txtCurrentDate').textContent = now;
}
//ON DOCUMENT READY
$(document).ready(function () {

    var vlisthotel = new vListHotel();
    vlisthotel.RetrieveInfo();

    var data = JSON.parse(localStorage.getItem('Hotel_selected'));

    document.querySelector("#btnEliminar").onclick = function () {
        ShowDelete(data);
    }

    $('#ModalMapPreview').locationpicker({
        radius: 0,
        location: {
            latitude: document.querySelector('#txtLat').value,
            longitude: document.querySelector('#txtLng').value
        },
        inputBinding: {
            latitudeInput: $('#txtLat'),
            longitudeInput: $('txtLng'),
            locationNameInput: $('#ModalMap-address')
        },
        enableAutocomplete: true,
        draggable: false,
        onchanged: function (currentLocation, radius, isMarkerDropped) {
            $('#ubicacion').html($('#ModalMap-address').val());
        }
    });
    $('#ModalMap').on('shown.bs.modal', function () {
        $('#ModalMapPreview').locationpicker('autosize');
    });
    vlisthotel.RetrieveTotalReservationsByMonth(data.Id);
    vlisthotel.RetrieveTotalIncome(data.Id);
    vlisthotel.RetrieveAverageIncome(data.Id);
    vlisthotel.RetrieveHotelIncomemonth(data.Id);
    vlisthotel.RetrieveHotelhotelanual(data.Id);
});


ShowDelete = function (res) {
    swal.fire({
        title: 'Eliminar Hotel',
        text: "¿Está seguro que desea eliminar este hotel?",
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
    var productRequest = new ControlActions().GetMethodDeleteToAPI('hotel', res);
    productRequest.done(response => {
        javascript: location.href = '/dashboard';
        localStorage.removeItem('Hotel_selected');
    });
}