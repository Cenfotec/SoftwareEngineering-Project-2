getGeneratedQRCodes = function () {
    var user = JSON.parse(localStorage.getItem('_userLogged'));
    var methodPost = new ControlActions().GetMethodGetToApi('userreservation' + '/' + user.Id);
    methodPost.done(res => {

        var getLlavesGeneradasMethod = new ControlActions().GetMethodGetToApi('qrcode/llavesgeneradas?' + 'idReservation=' + res.Data.Id);
        getLlavesGeneradasMethod.done(res_2 => {
            console.log(res_2);
            fillGeneratedQRCodesModal(res_2.Data);
        });
    });
}

fillGeneratedQRCodesModal = function (data) {
    let modalGeneratedQRCodes = $('#modalGeneratedQRCodes')[0];
    let modalGeneratedQRCodesTitle = $('#modalGeneratedQRCodesTitle')[0];

    let amountQRCodes = (data != null) ? data.length : 0;
    modalGeneratedQRCodesTitle.innerText = `Códigos Generados (${amountQRCodes})`;

    modalGeneratedQRCodes.innerHTML = '';
    document.getElementsByName('btnUserCodigoQR')[0].checked = true;
    document.querySelector('#txtCorreo').value = '';
    
    if (data != null) {
        for (let i = 0; i < data.length; i++) {
            let col = document.createElement('div');
            col.classList.add('col-3', 'text-center', 'm-2', 'position-relative');
            col.innerHTML +=
                `<span style="cursor:default;transform: translateX(0%);z-index:1000;position:absolute;bottom:-20px;display:none;background-color:#FAFAFA;color:#000;padding:5px;border-radius:25px;border:1px dashed #BEBEBE;">${data[i].State}</span>
             <img style="border:1px dashed #BEBEBE;width:100px;height:100px" src="${'https://res.cloudinary.com/qubitscenfo/image/upload/' + data[i].Value}" />
            `
            col.addEventListener('mouseover', () => {
                col.childNodes[0].style.display = 'block';
            });

            col.addEventListener('mouseout', () => {
                col.childNodes[0].style.display = 'none';
            });

            modalGeneratedQRCodes.appendChild(col);
        }
    } else {

        let col = document.createElement('div');
        col.classList.add('col', 'text-center', 'm-2', 'position-relative');
        col.innerHTML +=
            `
                <div class="" style="cursor:default;padding:2rem 1rem;margin:0 auto;border:1px dashed #BEBEBE"> <p class="m-0" style="font-size:22px;color:#646c9a;font-weight:500;">No se han generado códigos</p></div>
            `
        modalGeneratedQRCodes.appendChild(col);
        
    }
    
}



function vQRCodeModal() {

    this.service = 'qrcode'
    this.ctrlActions = new ControlActions()
    this.formId = '#invitarUsuarioQR'
    this.formName = 'invitarUsuarioQR'

    this.Create = function () {
        var email = document.querySelector('#txtCorreo').value;
        document.querySelector('#txtCorreo').value = '';
        var elementCollection = document.getElementsByName('btnUserCodigoQR');
        var elementsArray = Array.prototype.slice.call(elementCollection, 0);
        var info = (elementsArray.filter(x => x.checked))
        var value = info[0];

        var user = JSON.parse(localStorage.getItem('_userLogged'));
        var methodPost = this.ctrlActions.GetMethodGetToApi('userreservation' + '/' + user.Id);
        methodPost.done(res => {
            if (value.value == 'Invitado sin cuenta') {

                // User Not Registered
                let qrCode = {
                    Id: res.Data.Id,
                    Value: '',
                    State: email,
                    FK_SubReservation: 0
                };
                var inviteUserQRCode = this.ctrlActions.GetMethodPostToAPI(this.service + '/enviar_no_registrado', qrCode);
                inviteUserQRCode.done(res_2 => {
                    $.notify({
                        // options
                        icon: 'glyphicon glyphicon-warning-sign',
                        title: 'Código QR Enviado',
                        message: 'El código QR ha sido enviado exitosamente.'
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
                                align: "right",
                                position: "top"
                            },
                            offset: 20,
                            spacing: 10,
                            z_index: 3000,
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

            } else if (value.value == 'Invitado registrado') {
                // User Registered
                //enviar_registrado
                
                var methodGetUserReservation = this.ctrlActions.GetMethodGetToApi('reservation/getbyid/' + res.Data.Id);
                methodGetUserReservation.done(res_3 => {
                    console.log(res_3.Data);

                    let reservation = {
                        Id: 0,
                        FkUser: 0,
                        FkHotel: 0,
                        StartDate: new Date(),
                        EndDate: new Date(),
                        Price: 0,
                        State: email,
                        FKRoom: res_3.Data.FKRoom,
                        FkReservation: res_3.Data.FkReservation,
                        FkSubreservation: 0
                    };

                    var inviteUserQRCode = this.ctrlActions.GetMethodPostToAPI(this.service + '/enviar_registrado', reservation);
                    inviteUserQRCode.done(res_4 => {
                        // Fill QRCodes
                        var getLlavesGeneradasMethod = this.ctrlActions.GetMethodGetToApi('qrcode/llavesgeneradas?' + 'idReservation=' + res_3.Data.FkReservation);
                        getLlavesGeneradasMethod.done(res_5 => {
                            fillGeneratedQRCodesModal(res_5.Data);
                        });

                        $.notify({
                            // options
                            icon: 'glyphicon glyphicon-warning-sign',
                            title: 'Código QR Enviado',
                            message: 'El código QR ha sido enviado exitosamente.'
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
                                    align: "right",
                                    position: "top"
                                },
                                offset: 20,
                                spacing: 10,
                                z_index: 3000,
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

            }
            
        });

        methodPost.fail(res => {
            console.log('Request failed');
        });
        
        
        
        ////Hace el post al create
        //var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, customerData);

        //methodPost.done(res => {
        //    // Bootstrap notify
        //})
    }


    this.getFormValidationRules = function () {
        var rules = {
            
            Email: {
                required: true,
                email: true
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

    var vQRCode = new vQRCodeModal();
    KTFormControls.init(vQRCode.getFormValidationRules());
});