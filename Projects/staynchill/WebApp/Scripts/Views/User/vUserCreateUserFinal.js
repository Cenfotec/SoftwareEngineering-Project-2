function vUserCreateUserFinal() {
    this.service = 'user';
    this.ctrlActions = new ControlActions();
    this.formId = '#registrarAdminPlataforma';


    this.PostValidar = function(pcorreo) {
        var correo = pcorreo.replace(/\./g, 'dotrepl-8');
        var methodPost = this.ctrlActions.GetMethodPostToAPI('user/validar', { correo });
        methodPost.done(res => {
            console.log(res.Data);
            if (res.Data == true) {
                this.Create();
            } else {
                $.notify({
                    // options
                    icon: 'glyphicon glyphicon-warning-sign',
                    title: 'Registro inválido',
                    message: 'El correo ingresado ya existe.'
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
            }
        })

    }
 
    this.getCorreo = function() {
        var pcorreo = "";
        $('#' + 'registrarAdminPlataforma' + ' *').filter(':input').each(function(input) {
            let columnDataName = $(this).attr("ColumnDataName");
            if (columnDataName == "Correo") {
                pcorreo = this.value;
            }
        });
        this.PostValidar(pcorreo);
    }
 
    function getKeyImg() {
        let imagenUrl = document.querySelector("#image_preview").src;
        let urlArray = imagenUrl.split('/');
        imagenUrl = urlArray[6];
        return imagenUrl;
    }

    this.Create = function() {
        var rol = "Usuario final";
        var estado = "Habilitado";
        var keyImg = getKeyImg();
        var data = {};
        $('#' + 'registrarAdminPlataforma' + ' *').filter(':input').each(function(input) {
            var columnDataName = $(this).attr("ColumnDataName");
            if (columnDataName != "CContrasenna") {
                data[columnDataName] = this.value;
            }
        });
        data.Rol = rol;
        data.Estado = estado;
        data.Imagen = keyImg
        console.log(data);
        //    //Hace el post al create
        var method = this.ctrlActions.GetMethodPostToAPI(this.service, data);
        method.done(res => {
            console.log(res.Messsage);
            if (res.Message == "2") {
                $.notify({
                    // options
                    icon: 'glyphicon glyphicon-warning-sign',
                    title: 'Registro inválido',
                    message: 'El código de confirmación no coincide.'
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
            } else if (res.Message == "2") {
                $.notify({
                    // options
                    icon: 'glyphicon glyphicon-warning-sign',
                    title: 'Registro inválido',
                    message: 'Uno o más se encuentran vacíos.'
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
            } else if (res.Message == 1) {
                location.href = 'http://localhost:54388/dashboard';
            }
        })
    }

    this.Cancel = function () {
        javascript: location.href = '/';
    }

    this.Validate = function() {

        var data = {};
        $('#' + 'registrarAdminPlataforma' + ' *').filter(':input').each(function(input) {
            var columnDataName = $(this).attr("ColumnDataName");
            if (columnDataName == "Correo" || columnDataName == "Nombre") {
                data[columnDataName] = this.value;
            }
        });
        //Hace el post al create
        if(data.Correo == ""){
            $.notify({
                    // options
                    icon: 'glyphicon glyphicon-check',
                    title: 'Código no enviado',
                    message: 'Ingrese su correo electrónico para que su código sea enviado.'
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
        }else{
        var ctrlActions = new ControlActions();
        ctrlActions.PostToAPI('code', data);
        $.notify({
                    // options
                    icon: 'glyphicon glyphicon-check',
                    title: 'Código enviado',
                    message: 'El código de confirmación ha sido enviado a su correo.'
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

    this.getFormValidationRules = function() {
        var rules = {
            Cedula: {
                required: true
            },
            Nombre: {
                required: true,
            },
            Apellido: {
                required: true
            },
            SegApellido: {
                required: true
            },
            Correo: {
                required: true,
                email: true
            },
            Telefono: {
                required: true
            },
            Codigo: {
                required: true
            },
            vProvincia: {
                required: true,
                select_custom: true
            },
            vCanton: {
                required: true,
                select_custom: true
            },
            vDistrito: {
                required: true,
                select_custom: true
            },
            Direccion: {
                required: true
            },
            Contrasenna: {
                required: true
            },
            CContrasenna: {
                equalTo: '#txtContrasenna'
            }
        }
        var onSubmitCallback = this.getCorreo.bind(this)
        var formId = this.formId
        return {
            rules,
            onSubmitCallback,
            formId
        }
    }
}

//ON DOCUMENT READY
$(document).ready(function() {
    var vuserCreate = new vUserCreateUserFinal();

    jQuery.validator.addMethod("select_custom", function(value, element) {
        return this.optional(element) || value != "";
    }, 'Este campo es obligatorio.');
    
    KTFormControls.init(vuserCreate.getFormValidationRules());
});