function vRequestCreate() {

    this.service = 'hotel'
    this.ctrlActions = new ControlActions()
    this.formId = '#requestCreate'
    this.formName = 'requestCreate'

    // Jquery Dependency

    $("input[data-type='currency']").on({
        keyup: function () {
            formatCurrency($(this));
        },
        blur: function () {
            formatCurrency($(this), "blur");
        }
    });


    function formatNumber(n) {
        // format number 1000000 to 1,234,567
        return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }

    // Jquery Dependency

    $("input[data-type='currency']").on({
        keyup: function () {
            formatCurrency($(this));
        },
        blur: function () {
            formatCurrency($(this), "blur");
        }
    });

    function formatNumber(n) {
        // format number 1000000 to 1,234,567
        return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }


    function formatCurrency(input, blur) {
        // appends $ to value, validates decimal side
        // and puts cursor back in right position.

        // get input value
        var input_val = input.val();

        // don't validate empty input
        if (input_val === "") { return; }

        // original length
        var original_len = input_val.length;

        // initial caret position 
        var caret_pos = input.prop("selectionStart");

        // check for decimal
        if (input_val.indexOf(".") >= 0) {

            // get position of first decimal
            // this prevents multiple decimals from
            // being entered
            var decimal_pos = input_val.indexOf(".");

            // split number by decimal point
            var left_side = input_val.substring(0, decimal_pos);
            var right_side = input_val.substring(decimal_pos);

            // add commas to left side of number
            left_side = formatNumber(left_side);

            // validate right side
            right_side = formatNumber(right_side);

            // Limit decimal to only 2 digits
            right_side = right_side.substring(0, 2);

            // join number by .
            input_val = left_side + "." + right_side;

        } else {
            // no decimal entered
            // add commas to number
            // remove all non-digits
            input_val = formatNumber(input_val);
        }

        // send updated string to input
        input.val(input_val);

        // put caret back in the right position
        var updated_len = input_val.length;
        caret_pos = updated_len - original_len + caret_pos;
        input[0].setSelectionRange(caret_pos, caret_pos);
    }

    this.Create = function () {
        document.querySelector('#txtStars').value = document.querySelector('#inputStars').value;
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('requestCreate');
        let dSales = customerData.DailySales;
        var price = dSales.replace(/,/g, '.');
        if (price > 9.99 || price == 1.000) {
            price = price.split('.').join("");
        }
        console.log(price);
        customerData.DailySales = price;

        let mSales = customerData.MonthlySales;
        var price2 = mSales.replace(/,/g, '.');
        if (price2 > 9.99 || price == 1.000) {
            price2 = price2.split('.').join("");
        }
        console.log(price2);
        customerData.MonthlySales = price2;
        //Hace el post al create

        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, customerData);

        methodPost.done(res => {
            Swal.fire({
                title: 'Solicitud de Hotel',
                text: "Su solicitud ha sido enviada a los administradores de plataforma. Se le enviará la respuesta al correo del administrador.",
                type: 'success',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Continuar'
            }).then((result) => {
                if (result.value) {
                    location.href = '/dashboard'
                }
            })
        })

        methodPost.fail(res => {
            res = res.responseJSON;

            $.notify({
                // options
                icon: ' glyphicon glyphicon-ok-sign ',
                title: 'Error solicitud de inscripción',
                message: res.ExceptionMessage
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
        })
    }

    this.Update = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm(this.formName);
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, customerData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Cancel = function () {
        javascript: location.href = '/dashboard';
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
            },
            DailySales: {
                required: true,
                number: true
            },
            MonthlySales: {
                required: true,
                number: true
            },
            Email: {
                required: true
            }
        }
        var onSubmitCallback = this.Create.bind(this)
        var formId = this.formId
        return {
            rules,
            onSubmitCallback,
            formId
        }
    }
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vrequest = new vRequestCreate();

    $('#ModalMapPreview').locationpicker({
        radius: 0,
        location: {
            latitude: 9.9323162,
            longitude: -84.0332226
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

    jQuery.validator.addMethod("select_custom", function (value, element) {
        return this.optional(element) || value != "";
    }, 'Este campo es obligatorio.');

    KTFormControls.init(vrequest.getFormValidationRules());

});