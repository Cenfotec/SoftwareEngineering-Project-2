let cardData = {};

GetHotelsFiltered = function () {
    let hotelFiltrar = {};
    let data = JSON.parse(localStorage.getItem('_searchHotel'));
    hotelFiltrar.HotelNombre = data.hotel;
    hotelFiltrar.TipoHabitacionPersonas = parseInt(data.personas);
    hotelFiltrar.FechaInicio = data.inicio;
    hotelFiltrar.FechaFin = data.fin;
    let getHotelesFiltrarMethod = new ControlActions().GetMethodPostToAPI('hotel/filtrar', hotelFiltrar);
    return getHotelesFiltrarMethod;
}

function vHotelesIndex() {

    this.service = 'hotel';
    this.ctrlActions = new ControlActions();
    this.map = new map();

    this.LoadHoteles = function () {
        GetHotelsFiltered().done(res => {
            console.log(res);
            if (res.Data == null) {
                this.showEmpty();
                cardData = res.Data;
            } else {
                cardData = res.Data;
                CreateCards(res.Data);
            }
        });
        GetHotelsFiltered().fail(res => {
            this.showEmpty();
        });
    }

    this.showEmpty = function () {
        let parentHotelesCards = document.querySelector('#parentHotelesCards');
        parentHotelesCards.innerHTML = '';

        let div = document.createElement('div');


        div.innerHTML = `

                    <div id="card-nodata" class="col-lg-12 text-center">
                        <h1 style="margin: 10rem 10rem 0 10rem;">No hay hoteles disponibles</h1>
                        <p style="font-size: 16px;">Vuelva a intentar buscar un hotel</p>
                    </div>

                `;

        parentHotelesCards.appendChild(div);
    }


    this.InitSearch = function (searchId) {
        document.querySelector('#' + searchId).addEventListener('keyup', this.Search);

        let data = JSON.parse(localStorage.getItem('_searchHotel'));
        if (data) {
            // Fill search inputs
            $('#txtHotelName')[0].value = data.hotel;
            $('#kt_daterangepicker_1')[0].value = data.inicio + ' - ' + data.fin;
            $('#txtNumPeople')[0].value = data.personas;
        }
        
    }

    this.Search = function (e) {
        let parentHotelesCards = document.querySelector('#parentHotelesCards');
        parentHotelesCards.innerHTML = '';
        CreateCards(cardData, e.srcElement.value);
    }

    this.Buscar = function () {
        let numPeople = $('#txtNumPeople')[0];

        // parseInt(numPeople.value) > parseInt(numPeople.max)
        if ($('#kt_daterangepicker_1')[0].value.replace(' ', '') == '' || numPeople.value.replace(' ', '') == '' || parseInt(numPeople.value) < parseInt(numPeople.min)) {
            Swal.fire({
                type: 'warning',
                title: 'Error de búsqueda',
                text: 'Por favor complete los datos de búsqueda.'
            })
        } else {
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
            new vHotelesIndex().LoadHoteles();
        }


    }


}

//ON DOCUMENT READY
$(document).ready(function () {
    var vHoteles = new vHotelesIndex();
    vHoteles.LoadHoteles();
    vHoteles.InitSearch('btnBuscar');
    $('#txtNumPeople')[0].min = 1;
});

calculateHotelStars = function (num) {
    let data = '';
    for (let i = 0; i < num; i++) {
        data += `<i class="flaticon-star mr-1" style="color:#F6AB3F;"></i>`
    }
    return data;
}

CreateCards = function (res, search) {
    
    let parentHotelesCards = document.querySelector('#parentHotelesCards');
    parentHotelesCards.innerHTML = '';

    for (let i = 0; i < res.length; i++) {
        //if (searchCriteria.toLowerCase().includes(((search == undefined) ? "" : search.trim().toLowerCase())) || search == undefined) {
        let img = (res[i].hotel['Value'].split(',')[0]) == 'N/A' ? 'ipoaq4okyqgpdxvwe4np.jpg' : res[i].hotel['Value'].split(',')[0]
        let stars = calculateHotelStars(res[i]['Stars']);

        let colLG = document.createElement('div');

        colLG.innerHTML =
            `
                <div class="snc__card">
                    <div class="snc__hotel_img d-inline-block">
                        <img class="kt-widget__img kt-hidden-" src="${'https://res.cloudinary.com/qubitscenfo/image/upload/' + img}" alt="image">                       
                    </div>

                    <div class="snc__hotel_leftside d-inline-block">
                        <h2> ${res[i].hotel['Name']} </h2>
                        <p class="snc__p"> <i class="flaticon-map-location"></i> ${res[i].hotel['Province']}, ${res[i].hotel['Canton']}, ${res[i].hotel['District']} </p>
                        <p class="snc__p"> <i class="flaticon-email"></i> ${res[i].hotel['HotelEmail']} </p>
                        <p class="snc__p"> ${stars} </p>
                    </div>

                    <div class="snc__hotel_rightside d-inline-block">
                        <button data-id-ver=${res[i].hotel['Id']} type="button" class="btn btn-label-success btn-sm btn-upper">ver hotel</button>
                    </div>
                </div>
            `

        colLG.classList.add('row');
        colLG.style.margin = '0 auto';

        parentHotelesCards.appendChild(colLG);

        var element = `[data-id-ver='${res[i].hotel['Id']}']`
        document.querySelector(element).onclick = function () {
            localStorage.setItem('_searchHotelObj', JSON.stringify(res[i]));
            javascript: location.href = '/hotels/view';
        }
    }
    createHotelLogic(res);
}

createHotelLogic = function(hotels) {

    userLocation = navigator.geolocation;

    userLocation.getCurrentPosition(success, failure);

    function success(position) {
        var myLat = position.coords.latitude;
        var myLong = position.coords.longitude;
        var coords = new google.maps.LatLng(myLat, myLong);
        var infowindow = new google.maps.InfoWindow();
        var markers, i;

        var mapOptions = {
            zoom: 15,
            center: coords
        }

        var map = new google.maps.Map(document.getElementById('map'), mapOptions)

        var locationMarker = new google.maps.Marker({
            map: map,
            position: coords
        });

        // divMarker.setAttribute('data-marker-image', '//cdn6.agoda.net/images/default/current-property-pin.svg');
        // divMarker.setAttribute('data-marker-width', '45');
        // divMarker.setAttribute('data-marker-height', '53');

        for (i = 0; i < hotels.length; i++) {
            var markerIcon = {
                url: '//cdn6.agoda.net/images/default/current-property-pin.svg', // image is 512 x 512
                scaledSize : new google.maps.Size(45, 53)
            };
            markers = new google.maps.Marker({
                position: new google.maps.LatLng(hotels[i].hotel['Latitude'], hotels[i].hotel['Longitude']),
                map: map,
                icon: markerIcon,
                animation: google.maps.Animation.DROP
            });
            google.maps.event.addListener(markers, 'click', (function(marker, i) {
                return function() {
                    let img = (hotels[i].hotel['Value'].split(',')[0]) == 'N/A' ? 'ipoaq4okyqgpdxvwe4np.jpg' : hotels[i].hotel['Value'].split(',')[0]
                    let stars = calculateHotelStars(hotels[i].hotel['Stars']);
                    var markerSelected = new google.maps.LatLng(hotels[i].hotel['Latitude'], hotels[i].hotel['Longitude']);
                    calculateRoute(markerSelected);
                    infowindow.setContent(`<div class="map-card">

                    <div class="snc__hotel_img d-inline-block">

                       <img class="kt-widget__img kt-hidden-" src="${'https://res.cloudinary.com/qubitscenfo/image/upload/' + img}" style = "border-radius: 10px" alt="image">                       

               </div>

                   <h1>${hotels[i].hotel['Name']}</h1>

                   <p>Email: ${hotels[i].hotel['HotelEmail']}</p>

                   <p>Teléfono: ${hotels[i].hotel['PhoneNumber']}</p>

                   <p>Estrellas: ${stars}</p>

               </div>`);
                    infowindow.open(map, marker);
                }
            })(markers, i));
        }
    
        var directionsService = new google.maps.DirectionsService();
        var directionsDisplay = new google.maps.DirectionsRenderer();
        directionsDisplay.setMap(map);
        directionsDisplay.setPanel(document.getElementById('right-panel'));
    
        function calculateRoute(markerSelected) {
            var request = {
                origin: coords,
                destination: markerSelected,
                travelMode: 'DRIVING'
            };
            directionsService.route(request, function(result, status) {
                if (status = "OK") {
                    directionsDisplay.setDirections(result);
                } else {
                    alert('Error de petición al api google maps')
                }
            });
        }
    }

    function failure(){console.log('Permiso de ubiación denegado')}

}