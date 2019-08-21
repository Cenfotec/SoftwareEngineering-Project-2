let cardData = {};

function vVerHotelesIndex() {

    this.service = 'hotel';
    this.ctrlActions = new ControlActions();

    this.LoadHotel = function () {
        var hotel = JSON.parse(localStorage.getItem('_searchHotelObj'));
        console.log(hotel);
        $('#snc__hotel_name')[0].innerText = hotel.hotel.Name;
        let starsEle = $('#snc__hotel_stars')[0];
        for (let i = 0; i < hotel.hotel.Stars; i++) {
            starsEle.innerHTML += '<i class="flaticon-star mr-1" style="color:#6B7499;font-size:12px;"></i>';
        }
        $('#snc__hotel_description')[0].innerText = hotel.hotel.Description;
        $('#snc__hotel_contact')[0].innerHTML = '<i class="flaticon2-new-email mr-1"></i>' + hotel.hotel.HotelEmail;
        $('#snc__hotel_location')[0].innerHTML = '<i class="flaticon2-placeholder mr-1"></i>' + hotel.hotel.Province + ', ' + hotel.hotel.Canton + ', ' + hotel.hotel.District;

        let divCarousel = document.querySelector('#carousel');

        imgs = hotel.hotel.Value.split(',');
        let i = 0;
        $.each(imgs, function (index, value) {
            if (i == 0) {
                let divItemActiveCarousel = document.createElement('div');
                divItemActiveCarousel.setAttribute('class', 'item active');
                let img = document.createElement('img');
                img.src = 'https://res.cloudinary.com/qubitscenfo/image/upload/' + value;
                img.style.width = '100%';
                img.style.height = '400px';
                divItemActiveCarousel.appendChild(img);
                divCarousel.appendChild(divItemActiveCarousel);
                i++
            } else {
                let divItemActiveCarousel = document.createElement('div');
                divItemActiveCarousel.setAttribute('class', 'item');
                let img = document.createElement('img');
                img.style.width = '100%';
                img.style.height = '400px';
                img.src = 'https://res.cloudinary.com/qubitscenfo/image/upload/' + value;
                divItemActiveCarousel.appendChild(img);
                divCarousel.appendChild(divItemActiveCarousel);
            }
        });


        console.log(hotel);
    }



    this.GenerateCards = function () {
        var cards = [];
        var infoTipoHabitacion = {};
        var infoHabitacion = {};

        var hotel = JSON.parse(localStorage.getItem('_searchHotelObj'));
        var availableRooms = hotel.availableRooms;

        var parentHabitacionesCards = document.querySelector('#parentHabitacionesCards');
        

                // Generate Cards
                for (let i = 0; i < availableRooms.length; i++) {
                    
                        let cardHabitacion = document.createElement('div');
                        // Validation
                        
                    let img = (availableRooms[i].Value.split(',')[0]) == '' ? 'ipoaq4okyqgpdxvwe4np.jpg' : availableRooms[i].Value.split(',')[0]
                    let amountPeopleText = (availableRooms[i].CantPersonas > 1) ? 'personas' : 'persona';
                    let amountBedsText = (availableRooms[i].CantCamas > 1) ? 'camas' : 'cama';
                    let petsAllowed = (availableRooms[i].PetsAllowed == 'Permitir') ? 'mascotas son permitidas' : 'mascotas son prohibidas';
                            
                            cardHabitacion.innerHTML = `
                                <div class="kt-portlet kt-portlet--height-fluid snc__habitacion_portlet">
                                    <div class="kt-portlet__body d-inline-block p-0" style="overflow:hidden;">

                                        <div class="row" style="border-bottom: 1px solid #DFE0E6;">
                                            <div class="col-5 pr-0">
                                                <img style="width:100%;height:200px;" src="https://res.cloudinary.com/qubitscenfo/image/upload/${img}">
                                            </div>

                                            <div class="col" style="height:100px !important;border-bottom: 1px solid #DFE0E6;" >
                                                <div>
                                                    <h4 class="d-inline-block pt-2 mb-0"> ${availableRooms[i].Nombre} </h4>
                                                    <span class="snc__pill_float float-right m-3 rounded-pill p-2 pl-4 pr-4" style="font-weight:bold;letter-spacing:1px;color:#0ABB87; background-color:#DAEBE7;">$${availableRooms[i].Precio.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,')}</span>
                                                </div>
                                                <div>
                                                    <p class="d-inline-block mb-0" style="font-size:14px"> <svg class="mr-2" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" id="Layer_1" x="0px" y="0px" viewBox="0 0 512 512" style="enable-background:new 0 0 512 512;" xml:space="preserve" width="16px" height="16px"><g><g>
	<g>
		<path d="M451.72,237.26c-17.422-8.71-50.087-8.811-51.469-8.811c-4.142,0-7.5,3.358-7.5,7.5c0,4.142,3.358,7.5,7.5,7.5    c8.429,0.001,32.902,1.299,44.761,7.228c1.077,0.539,2.221,0.793,3.348,0.793c2.751,0,5.4-1.52,6.714-4.147    C456.927,243.618,455.425,239.113,451.72,237.26z" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/>
	</g>
</g><g>
	<g>
		<path d="M489.112,344.041l-30.975-8.85c-1.337-0.382-2.271-1.62-2.271-3.011v-10.339c2.52-1.746,4.924-3.7,7.171-5.881    c10.89-10.568,16.887-24.743,16.887-39.915v-14.267l2.995-5.989c3.287-6.575,5.024-13.936,5.024-21.286v-38.65    c0-4.142-3.358-7.5-7.5-7.5H408.27c-26.244,0-47.596,21.352-47.596,47.596v0.447c0,6.112,1.445,12.233,4.178,17.699l3.841,7.682    v12.25c0,19.414,9.567,36.833,24.058,47.315l0.002,10.836c0,1.671,0,2.363-6.193,4.133l-15.114,4.318l-43.721-15.898    c0.157-2.063-0.539-4.161-2.044-5.742l-13.971-14.678v-24.64c1.477-1.217,2.933-2.467,4.344-3.789    c17.625-16.52,27.733-39.844,27.733-63.991v-19.678c5.322-11.581,8.019-23.836,8.019-36.457v-80.19c0-4.142-3.358-7.5-7.5-7.5    H232.037c-39.51,0-71.653,32.144-71.653,71.653v16.039c0,12.621,2.697,24.876,8.019,36.457v16.931    c0,28.036,12.466,53.294,32.077,69.946v25.22l-13.971,14.678c-1.505,1.581-2.201,3.679-2.044,5.742l-46.145,16.779    c-3.344,1.216-6.451,2.863-9.272,4.858l-7.246-3.623c21.57-9.389,28.403-22.594,28.731-23.25c1.056-2.111,1.056-4.597,0-6.708    c-5.407-10.814-6.062-30.635-6.588-46.561c-0.175-5.302-0.341-10.311-0.658-14.771c-2.557-35.974-29.905-63.103-63.615-63.103    s-61.059,27.128-63.615,63.103c-0.317,4.461-0.483,9.47-0.658,14.773c-0.526,15.925-1.182,35.744-6.588,46.558    c-1.056,2.111-1.056,4.597,0,6.708c0.328,0.656,7.147,13.834,28.76,23.234l-20.127,10.063C6.684,358.176,0,368.991,0,381.02    v55.409c0,4.142,3.358,7.5,7.5,7.5s7.5-3.358,7.5-7.5V381.02c0-6.312,3.507-11.987,9.152-14.81l25.063-12.531l8.718,8.285    c6.096,5.793,13.916,8.688,21.739,8.688c7.821,0,15.645-2.897,21.739-8.688l8.717-8.284l8.172,4.086    c-3.848,6.157-6.032,13.377-6.032,20.94v57.725c0,4.142,3.358,7.5,7.5,7.5c4.142,0,7.5-3.358,7.5-7.5v-57.725    c0-10.296,6.501-19.578,16.178-23.097l48.652-17.691l20.253,30.381c2.589,3.884,6.738,6.375,11.383,6.835    c0.518,0.051,1.033,0.076,1.547,0.076c4.098,0,8.023-1.613,10.957-4.546l12.356-12.356v78.124c0,4.142,3.358,7.5,7.5,7.5    c4.142,0,7.5-3.358,7.5-7.5v-78.124l12.356,12.356c2.933,2.934,6.858,4.547,10.957,4.547c0.513,0,1.029-0.025,1.546-0.076    c4.646-0.46,8.795-2.951,11.384-6.835l20.254-30.38l48.651,17.691c9.676,3.519,16.178,12.801,16.178,23.097v57.725    c0,4.142,3.358,7.5,7.5,7.5c4.142,0,7.5-3.358,7.5-7.5v-57.725c0-10.428-4.143-20.208-11.093-27.441l1.853-0.529    c1.869-0.534,4.419-1.265,6.979-2.52l19.149,19.149v69.066c0,4.142,3.358,7.5,7.5,7.5c4.142,0,7.5-3.358,7.5-7.5v-69.066    l19.016-19.016c1.011,0.514,2.073,0.948,3.191,1.267l30.976,8.85c7.07,2.02,12.009,8.567,12.009,15.921v62.044    c0,4.142,3.358,7.5,7.5,7.5c4.142,0,7.5-3.358,7.5-7.5v-62.044C512,360.371,502.588,347.892,489.112,344.041z M48.115,330.794    c-14.029-5.048-21.066-11.778-24.07-15.453c2.048-5.354,3.376-11.486,4.275-17.959c4.136,9.917,11.063,18.383,19.795,24.423    V330.794z M91.08,351.092c-6.397,6.078-16.418,6.077-22.813-0.001l-6.975-6.628c1.177-2.205,1.824-4.705,1.824-7.324v-7.994    c5.232,1.635,10.794,2.517,16.558,2.517c5.757,0,11.316-0.886,16.557-2.512l-0.001,7.988c0,2.62,0.646,5.121,1.824,7.327    L91.08,351.092z M79.676,316.662c-22.396,0-40.615-18.22-40.615-40.615c0-4.142-3.358-7.5-7.5-7.5c-0.42,0-0.83,0.043-1.231,0.11    c0.022-0.645,0.043-1.291,0.065-1.93c0.167-5.157,0.328-10.028,0.625-14.206c0.958-13.476,6.343-25.894,15.163-34.968    c8.899-9.156,20.793-14.198,33.491-14.198s24.591,5.042,33.491,14.198c8.82,9.074,14.205,21.492,15.163,34.968    c0.296,4.177,0.458,9.047,0.628,14.203c0.015,0.443,0.03,0.892,0.045,1.338c-8.16-12.572-20.762-21.837-37.045-27.069    c-15.043-4.833-27.981-4.534-28.527-4.52c-1.964,0.055-3.828,0.877-5.191,2.291l-13.532,14.034    c-2.875,2.982-2.789,7.73,0.193,10.605s7.73,2.788,10.605-0.193l11.26-11.677c9.697,0.474,40.894,4.102,53.027,30.819    C116.738,302.04,99.816,316.662,79.676,316.662z M111.229,330.819l0.001-8.945c8.725-6.007,15.662-14.457,19.801-24.449    c0.899,6.458,2.226,12.576,4.27,17.918C132.314,318.983,125.244,325.773,111.229,330.819z M183.403,209.145v-18.608    c0-1.129-0.255-2.244-0.746-3.261c-4.826-9.994-7.273-20.598-7.273-31.518V139.72c0-31.239,25.415-56.653,56.653-56.653h104.769    v72.692c0,10.92-2.447,21.524-7.273,31.518c-0.491,1.017-0.746,2.132-0.746,3.261v21.355c0,20.311-8.165,39.15-22.991,53.047    c-1.851,1.734-3.772,3.36-5.758,4.875c-0.044,0.03-0.086,0.063-0.129,0.094c-13.889,10.545-30.901,15.67-48.667,14.519    C213.201,281.965,183.403,248.897,183.403,209.145z M225.632,360.056c-0.052,0.052-0.173,0.175-0.418,0.149    c-0.244-0.024-0.34-0.167-0.381-0.229l-23.325-34.988l7.506-7.887l35.385,24.187L225.632,360.056z M256.095,331.113    l-40.615-27.762v-14c10.509,5.681,22.276,9.234,34.791,10.044c1.977,0.128,3.942,0.191,5.901,0.191    c14.341,0,28.143-3.428,40.538-9.935v13.7L256.095,331.113z M287.357,359.978c-0.041,0.062-0.137,0.205-0.381,0.229    c-0.245,0.031-0.365-0.098-0.418-0.149l-18.767-18.767l35.385-24.188l7.507,7.887L287.357,359.978z M424.308,353.65l-17.02-17.019    c0.297-1.349,0.465-2.826,0.464-4.455l-0.001-3.165c4.723,1.55,9.701,2.47,14.852,2.624c0.578,0.018,1.151,0.026,1.727,0.026    c5.692,0,11.248-0.86,16.536-2.501v3.02c0,1.496,0.188,2.962,0.542,4.371L424.308,353.65z M452.591,305.196    c-7.949,7.714-18.45,11.788-29.537,11.446c-21.704-0.651-39.361-19.768-39.361-42.613v-14.021c0-1.165-0.271-2.313-0.792-3.354    l-4.633-9.266c-1.697-3.395-2.594-7.195-2.594-10.991v-0.447c0-17.974,14.623-32.596,32.596-32.596h64.673v31.15    c0,5.034-1.19,10.075-3.441,14.578l-3.786,7.572c-0.521,1.042-0.792,2.189-0.792,3.354v16.038    C464.924,287.126,460.544,297.478,452.591,305.196z" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/>
	</g>
</g><g>
	<g>
		<path d="M472.423,380.814c-4.142,0-7.5,3.358-7.5,7.5v48.115c0,4.142,3.358,7.5,7.5,7.5c4.142,0,7.5-3.358,7.5-7.5v-48.115    C479.923,384.173,476.565,380.814,472.423,380.814z" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/>
	</g>
</g><g>
	<g>
		<path d="M39.577,390.728c-4.142,0-7.5,3.358-7.5,7.5v38.201c0,4.142,3.358,7.5,7.5,7.5c4.142,0,7.5-3.358,7.5-7.5v-38.201    C47.077,394.087,43.719,390.728,39.577,390.728z" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/>
	</g>
</g><g>
	<g>
		<path d="M317.532,158.475c-28.366-28.366-87.715-22.943-111.917-19.295c-7.623,1.149-13.155,7.6-13.155,15.339v17.278    c0,4.142,3.358,7.5,7.5,7.5c4.142,0,7.5-3.358,7.5-7.5v-17.279c0-0.255,0.168-0.473,0.392-0.507    c9.667-1.457,28.85-3.705,48.725-2.38c23.388,1.557,40.328,7.428,50.349,17.45c2.929,2.929,7.678,2.929,10.606,0    C320.461,166.152,320.461,161.403,317.532,158.475z" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/>
	</g>
</g><g>
	<g>
		<path d="M167.884,396.853c-4.142,0-7.5,3.358-7.5,7.5v32.077c0,4.142,3.358,7.5,7.5,7.5c4.142,0,7.5-3.358,7.5-7.5v-32.077    C175.384,400.212,172.026,396.853,167.884,396.853z" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/>
	</g>
</g><g>
	<g>
		<path d="M344.306,396.853c-4.142,0-7.5,3.358-7.5,7.5v32.077c0,4.142,3.358,7.5,7.5,7.5c4.142,0,7.5-3.358,7.5-7.5v-32.077    C351.806,400.212,348.448,396.853,344.306,396.853z" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/>
	</g>
</g></g> </svg>${availableRooms[i].CantPersonas} ${amountPeopleText}</p>
                                                </div>

                                                <div>
                                                    <p class="d-inline-block mb-0" style="font-size:14px"> <svg class="mr-2" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" id="Capa_1" x="0px" y="0px" viewBox="0 0 480 480" style="enable-background:new 0 0 480 480;" xml:space="preserve" width="16px" height="16px"><g><g>
	<g>
		<path d="M472,272h-8v-24c-0.021-15.886-9.44-30.254-24-36.608V88c-0.002-3.18-1.886-6.056-4.8-7.328    c3.121-5.002,4.783-10.776,4.8-16.672c0-17.673-14.327-32-32-32c-17.673,0-32,14.327-32,32c0.033,5.634,1.569,11.157,4.448,16    H99.552c2.879-4.843,4.415-10.366,4.448-16c0-17.673-14.327-32-32-32S40,46.327,40,64c0.017,5.896,1.679,11.67,4.8,16.672    C41.886,81.944,40.002,84.82,40,88v123.392C25.44,217.746,16.021,232.114,16,248v24H8c-4.418,0-8,3.582-8,8v112    c0,4.418,3.582,8,8,8h8v40c0,4.418,3.582,8,8,8h32c4.418,0,8-3.582,8-8v-40h352v40c0,4.418,3.582,8,8,8h32c4.418,0,8-3.582,8-8    v-40h8c4.418,0,8-3.582,8-8V280C480,275.582,476.418,272,472,272z M408,48c8.837,0,16,7.163,16,16s-7.163,16-16,16    s-16-7.163-16-16S399.163,48,408,48z M72,48c8.837,0,16,7.163,16,16s-7.163,16-16,16s-16-7.163-16-16S63.163,48,72,48z M56,96h368    v112h-32.208c5.294-6.883,8.179-15.316,8.208-24v-16c-0.026-22.08-17.92-39.974-40-40h-64c-22.08,0.026-39.974,17.92-40,40v16    c0.029,8.684,2.914,17.117,8.208,24h-48.416c5.294-6.883,8.179-15.316,8.208-24v-16c-0.026-22.08-17.92-39.974-40-40h-64    c-22.08,0.026-39.974,17.92-40,40v16c0.029,8.684,2.914,17.117,8.208,24H56V96z M384,168v16c0,13.255-10.745,24-24,24h-64    c-13.255,0-24-10.745-24-24v-16c0-13.255,10.745-24,24-24h64C373.255,144,384,154.745,384,168z M208,168v16    c0,13.255-10.745,24-24,24h-64c-13.255,0-24-10.745-24-24v-16c0-13.255,10.745-24,24-24h64C197.255,144,208,154.745,208,168z     M32,248c0-13.255,10.745-24,24-24h368c13.255,0,24,10.745,24,24v24H32V248z M48,432H32v-32h16V432z M448,432h-16v-32h16V432z     M464,384H16v-96h448V384z" data-original="#000000" class="active-path" fill="#000000"/>
	</g>
</g><g>
	<g>
		<path d="M72,352H40c-4.418,0-8,3.582-8,8s3.582,8,8,8h32c4.418,0,8-3.582,8-8S76.418,352,72,352z" data-original="#000000" class="active-path" fill="#000000"/>
	</g>
</g><g>
	<g>
		<path d="M440,352H104c-4.418,0-8,3.582-8,8s3.582,8,8,8h336c4.418,0,8-3.582,8-8S444.418,352,440,352z" data-original="#000000" class="active-path" fill="#000000"/>
	</g>
</g></g> </svg>${availableRooms[i].CantCamas} ${amountBedsText}</p>
                                                </div>

                                                <div>
                                                    <p class="d-inline-block mb-0" style="font-size:14px"> <svg class="mr-2" xmlns="http://www.w3.org/2000/svg" height="16px" viewBox="0 -32 512.00001 512" width="16px"><g><path d="m342.382812 239.351562c-23.039062-35.941406-62.277343-57.402343-104.964843-57.402343-42.683594 0-81.925781 21.460937-104.960938 57.402343l-55.515625 86.605469c-9.210937 14.371094-13.460937 30.96875-12.292968 47.996094 1.167968 17.03125 7.648437 32.890625 18.738281 45.871094 11.097656 12.976562 25.761719 21.84375 42.40625 25.648437 16.644531 3.800782 33.707031 2.179688 49.339843-4.691406l1.019532-.453125c39.339844-16.957031 84.304687-16.804687 123.546875.453125 10.121093 4.449219 20.84375 6.699219 31.664062 6.699219 5.882813 0 11.800781-.667969 17.664063-2.003907 16.644531-3.800781 31.308594-12.667968 42.410156-25.644531 11.09375-12.976562 17.578125-28.839843 18.75-45.871093 1.171875-17.035157-3.078125-33.632813-12.289062-48.007813zm26.246094 160.972657c-14.121094 16.507812-36.964844 21.726562-56.847656 12.984375-23.632812-10.394532-49-15.589844-74.375-15.589844-25.351562 0-50.714844 5.191406-74.332031 15.574219l-.671875.296875c-19.730469 8.34375-42.238282 3.058594-56.203125-13.265625-14.105469-16.511719-15.710938-39.886719-3.992188-58.171875l55.519531-86.605469c17.492188-27.289063 47.28125-43.582031 79.691407-43.582031 32.410156 0 62.203125 16.292968 79.699219 43.582031l55.511718 86.601563c11.722656 18.292968 10.113282 41.671874-4 58.175781zm0 0" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/><path d="m91.894531 239.238281c16.515625-6.34375 29.0625-19.652343 35.332031-37.476562 5.960938-16.960938 5.472657-36.109375-1.382812-53.921875-6.859375-17.800782-19.335938-32.332032-35.128906-40.921875-16.597656-9.019531-34.828125-10.488281-51.316406-4.132813-33.171876 12.753906-48.394532 53.746094-33.929688 91.398438 11.554688 29.96875 38.503906 48.886718 65.75 48.886718 6.957031 0 13.933594-1.234374 20.675781-3.832031zm-58.417969-55.835937c-8.523437-22.1875-1.035156-45.789063 16.703126-52.609375 3.203124-1.234375 6.589843-1.847657 10.046874-1.847657 5.335938 0 10.847657 1.457032 16.152344 4.34375 9.539063 5.183594 17.160156 14.183594 21.457032 25.335938 4.292968 11.160156 4.675781 22.941406 1.074218 33.179688-3.300781 9.382812-9.617187 16.28125-17.78125 19.417968l-.015625.007813c-17.714843 6.828125-39.085937-5.660157-47.636719-27.828125zm0 0" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/><path d="m199.613281 171.386719c41.46875 0 75.207031-38.4375 75.207031-85.683594 0-47.257813-33.738281-85.703125-75.207031-85.703125-41.464843 0-75.199219 38.445312-75.199219 85.703125 0 47.246094 33.734376 85.683594 75.199219 85.683594zm0-141.375c24.917969 0 45.195313 24.984375 45.195313 55.691406 0 30.695313-20.277344 55.671875-45.195313 55.671875s-45.1875-24.976562-45.1875-55.671875c0-30.707031 20.269531-55.691406 45.1875-55.691406zm0 0" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/><path d="m329.496094 192.4375h.003906c6.378906 2.117188 12.886719 3.128906 19.367188 3.128906 30.242187 0 59.714843-22.011718 70.960937-55.839844 6.476563-19.472656 6.050781-40.0625-1.199219-57.972656-7.585937-18.746094-21.644531-32.355468-39.589844-38.324218-17.945312-5.960938-37.363281-3.476563-54.664062 7-16.527344 10.011718-29.191406 26.246093-35.65625 45.71875-13.652344 41.078124 4.640625 84.273437 40.777344 96.289062zm-12.296875-86.824219c4.222656-12.714843 12.292969-23.191406 22.726562-29.511719 9.652344-5.847656 20.183594-7.335937 29.648438-4.191406 9.460937 3.148438 17 10.640625 21.234375 21.101563 4.574218 11.304687 4.769531 24.53125.539062 37.246093-8.433594 25.375-31.933594 40.492188-52.382812 33.699219-20.433594-6.796875-30.199219-32.96875-21.765625-58.34375zm0 0" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/><path d="m487.875 182.4375-.011719-.011719c-28.597656-21.125-71.367187-11.96875-95.347656 20.421875-23.957031 32.40625-20.210937 75.972656 8.34375 97.113282 10.414063 7.714843 22.71875 11.402343 35.3125 11.402343 21.949219 0 44.785156-11.203125 60.046875-31.804687 23.957031-32.40625 20.214844-75.972656-8.34375-97.121094zm-15.777344 79.265625c-14.160156 19.113281-38.101562 25.453125-53.378906 14.136719-15.265625-11.300782-16.195312-36.042969-2.074219-55.144532 9.386719-12.679687 23.097657-19.734374 35.734375-19.734374 6.390625 0 12.507813 1.804687 17.648438 5.605468 15.253906 11.3125 16.179687 36.046875 2.070312 55.136719zm0 0" data-original="#000000" class="active-path" data-old_color="#000000" fill="#171820"/></g> </svg>${petsAllowed}</p>
                                                </div>


                                                <div class="mt-3">
                                                    <p>${availableRooms[i].Description}</p>
                                                </div>
                                            </div>

                                         </div>
                                           
                                         <div class="pt-2" style="text-align:right;">
                                            <h5 class="mr-5" style="color:#005AEB;">Reservar habitación ></h5>
                                         </div>
                                                                

                                    </div>
                                </div>`;
                            parentHabitacionesCards.appendChild(cardHabitacion);

                            
                                cardHabitacion.addEventListener('click', function () {


                                    

                                    let commissionHotelData = {};
                                    commissionHotelData.Percentage = hotel.hotel.LegalNumber;
                                    var getCommissionMethod = new ControlActions().GetMethodPostToAPI('commission/administrador', commissionHotelData);
                                    getCommissionMethod.done(res_3 => {


                                        let infoUser = JSON.parse(localStorage.getItem('_userLogged'));
                                        let searchData = JSON.parse(localStorage.getItem('_searchHotel'));
                                        let searchDataFormatted = {};
                                        searchDataFormatted.Start = searchData.inicio;
                                        searchDataFormatted.End = searchData.fin;

                                        // Validación de check-in
                                        //var isCheckedInRequest = this.ctrlActions.GetMethodGetToApi('userreservation' + '/' + infoUser.Id);
                                        //let isCheckedIn = (res_4.Data == null) ? 0 : 1;
                                        //if (isCheckedIn == 0) {

                                        //}
                                            
                                        //});

                                        let data = {};

                                        if (infoUser != null) {
                                            data.User = infoUser;
                                            data.Hotel = hotel.hotel;
                                            data.Hotel.Commission = parseFloat(res_3.Data[0]['Percentage']);
                                            data.AvailableRoom = hotel.availableRooms[i];
                                            data.Date = searchDataFormatted;

                                            localStorage.setItem('_reservationSearchData', JSON.stringify(data));
                                            console.log(JSON.parse(localStorage.getItem('_reservationSearchData')));
                                            javascript: location.href = '/hotels/view/reservation';

                                        } else {
                                            $.notify({
                                                // options
                                                icon: 'glyphicon glyphicon-warning-sign',
                                                title: 'Error al reservar',
                                                message: 'Por favor inicie sesión en la aplicación.'
                                            }, {
                                                    // settings
                                                    element: 'body',
                                                    position: null,
                                                    type: "warning",
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
                                        }


                                    });
                                });
                        
                    
                }







    }



}

//ON DOCUMENT READY
$(document).ready(function () {
    var vVerHoteles = new vVerHotelesIndex();
    vVerHoteles.LoadHotel();
    vVerHoteles.GenerateCards();
});
