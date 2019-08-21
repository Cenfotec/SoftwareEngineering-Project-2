function vHotelUpdate() {
    this.service = 'hotel'
    this.ctrlActions = new ControlActions()
    this.slctProvinces = new SelectProvinces()
    this.formId = '#hotelEdit'
    this.formName = 'hotelEdit'
    this.currenModel = {}

    this.Update = function () {
        document.querySelector('#txtStars').value = document.querySelector('#inputStars').value;
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('hotelEdit');

        var methodPut = this.ctrlActions.GetMethodPutToAPI(this.service, customerData);

        methodPut.done(res => {
            localStorage.setItem('Hotel_selected', JSON.stringify(res.Data));
            javascript: location.href = '/dashboard/hotel';
        })

        methodPut.fail(res => {
            alert('La cédula jurídica ya existe');
        })
    }

    this.Cancel = function () {
        javascript: location.href = '/dashboard/hotel';
    }

    this.getFormValidationRules = function () {
        var rules = {
            Name: {
                required: true
            },
            Description: {
                required: true
            },
            LegalNumber: {
                required: true,
                number: true
            },
            HotelEmail: {
                required: true
            },
            PhoneNumber: {
                required: true,
                number: true
            },
            vStars: {
                required: true,
                select_custom: true
            },
            vProvince: {
                required: true,
                select_custom: true
            },
            vCanton: {
                required: true,
                select_custom: true
            },
            vDistrict: {
                required: true,
                select_custom: true
            }
        }
        var onSubmitCallback = this.Update.bind(this)
        var formId = this.formId
        return {
            rules,
            onSubmitCallback,
            formId
        }
    }

}

$(document).ready(function () {

    var vhotel = new vHotelUpdate();
    
    KTFormControls.init(vhotel.getFormValidationRules());

    vhotel.currentModel = JSON.parse(localStorage.getItem('Hotel_selected'));

    vhotel.ctrlActions.BindFields(vhotel.formName, vhotel.currentModel);

    document.querySelector('#inputStars').value = document.querySelector('#txtStars').value;

    document.querySelector('#inputProvincia').value = document.querySelector('#txtHProvincia').value;

    vhotel.slctProvinces.popularCanton();

    document.querySelector('#inputCanton').value = document.querySelector('#txtHCanton').value;

    vhotel.slctProvinces.popularDistrito();

    document.querySelector('#inputDistrito').value = document.querySelector('#txtHDistrito').value;

    $('#ModalMapPreview').locationpicker({
        radius: 0,
        location: {
            latitude: document.querySelector('#txtLat').value,
            longitude: document.querySelector('#txtLng').value
        },
        inputBinding: {
            latitudeInput: $('#txtLat'),
            longitudeInput: $('#txtLng'),
            locationNameInput: $('#ModalMap-address')
        },
        enableAutocomplete: true,
        onchanged: function (currentLocation, radius, isMarkerDropped) {
            $('#ubicacion').html($('#ModalMap-address').val());
        }
    });
    $('#ModalMap').on('shown.bs.modal', function () {
        $('#ModalMapPreview').locationpicker('autosize');
    });
    let imgLocal = document.querySelector('#txtValue').value;
    let sectionImages = document.querySelector('#imageConatiner');
    if (imgLocal != "") {
        console.log(imgLocal);
        imgs = document.querySelector('#txtValue').value.split(',');
        let i = 0;
        $.each(imgs, function (index, value) {
            let imagenNueva = document.createElement('img');
            imagenNueva.setAttribute('id', value);
            imagenNueva.classList.add('d-block');
            imagenNueva.classList.add('w-100');
            imagenUrl = "https://res.cloudinary.com/qubitscenfo/image/upload/" + value;

            if (i == 0) {

                let divCarousel = document.createElement('div');
                divCarousel.setAttribute('id', 'carouselExampleControls');
                divCarousel.setAttribute('class', 'carousel slide');
                divCarousel.setAttribute('data-ride', 'carousel');

                let divInner = document.createElement('div');
                divInner.setAttribute('id', 'divinner');
                divInner.setAttribute('class', 'carousel-inner');

                let overlay = document.createElement('div');
                overlay.classList.add('overlay');

                let text = document.createElement('div');
                text.classList.add('text');
                text.innerHTML = 'Eliminar imagen';

                overlay.appendChild(text);

                let divCarouselActive = document.createElement('div');
                divCarouselActive.setAttribute('id', 'carouseltype');
                divCarouselActive.setAttribute('class', 'item active');

                let aControlPrev = document.createElement('a');
                aControlPrev.setAttribute('class', 'carousel-control-prev');
                aControlPrev.setAttribute('href', '#carouselExampleControls');
                aControlPrev.setAttribute('role', 'button');
                aControlPrev.setAttribute('data-slide', 'prev');

                let spanControlPrev = document.createElement('span');
                spanControlPrev.setAttribute('class', 'carousel-control-prev-icon');
                spanControlPrev.setAttribute('aria-hidden', 'true');

                let spanSrPrevious = document.createElement('span');
                spanSrPrevious.setAttribute('class', 'sr-only');
                spanSrPrevious.innerHTML = 'Previous';

                let aControlNext = document.createElement('a');
                aControlNext.setAttribute('class', 'carousel-control-next');
                aControlNext.setAttribute('href', '#carouselExampleControls');
                aControlNext.setAttribute('role', 'button');
                aControlNext.setAttribute('data-slide', 'next');

                let spanControlNext = document.createElement('span');
                spanControlNext.setAttribute('class', 'carousel-control-next-icon');
                spanControlNext.setAttribute('aria-hidden', 'true');

                let spanSrNext = document.createElement('span');
                spanSrNext.setAttribute('class', 'sr-only');
                spanSrNext.innerHTML = 'Next';

                sectionImages.appendChild(divCarousel);
                divCarousel.appendChild(divInner);
                aControlPrev.appendChild(spanControlPrev);
                aControlPrev.appendChild(spanSrPrevious);
                aControlNext.appendChild(spanControlNext);
                aControlNext.appendChild(spanSrNext);
                divInner.appendChild(divCarouselActive);
                divCarouselActive.appendChild(imagenNueva);
                divCarousel.appendChild(aControlPrev);
                divCarousel.appendChild(aControlNext);
                document.querySelector("#" + value).src = imagenUrl;
                divInner.onclick = function () {
                    let img;
                    for (let i = 0; i < this.childNodes.length; i++) {
                        if (this.childNodes[i].classList.contains('active')) {

                            img = this.childNodes[i].childNodes[0].id;

                            imgsInput = document.querySelector('#txtValue').value.split(',');

                            for (var k = 0; k < imgsInput.length; k++) {

                                if (imgsInput[k] === img) {

                                    imgsInput.splice(k, 1);
                                }

                            }
                            this.removeChild(this.childNodes[i]);
                            document.querySelector('#txtValue').value = imgsInput;
                            this.childNodes[0].classList.add('active');

                            $.notify({
                                // options
                                icon: ' glyphicon glyphicon-ok-sign ',
                                title: 'Imagen eliminada',
                                message: 'La imagen ha sido removida exitosamente'
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

                        }
                    }
                }
                i++
            } else {
                let divCarousel = document.querySelector('#carouselExampleControls');
                let divInner = document.querySelector('#divinner');
                let divCarouselActive = document.createElement('div');
                divCarouselActive.setAttribute('id', 'carouseltype');
                divCarouselActive.setAttribute('class', 'item');
                sectionImages.appendChild(divCarousel);
                divCarousel.appendChild(divInner);
                divInner.appendChild(divCarouselActive);
                divCarouselActive.appendChild(imagenNueva);
                document.querySelector("#" + value).src = imagenUrl;
                $('.carousel').carousel();
            }

        });
    }

    jQuery.validator.addMethod("select_custom", function (value, element) {
        return this.optional(element) || value != "";
    }, 'Este campo es obligatorio.');

});