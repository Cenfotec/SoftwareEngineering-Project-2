function vUserCreate() {

    this.tblRegisterManagersId = 'TBL_USUARIOS';
    this.service = 'user';
    this.ctrlActions = new ControlActions();
    this.formId = '#kt_form';


    this.PostValidar = function (pcorreo) {
        var correo = pcorreo.replace(/\./g, 'dotrepl-8');
        var methodPost = this.ctrlActions.GetMethodPostToAPI('user/validar', { correo });
        methodPost.done(res => {
            console.log(res.Data);
            if (res.Data == true) {
                this.Create();
            } else {
                console.log("Su correo esta repetida");
            }
        })

    }

    //function PostValidarCodigo(data) {
    //    var methodPost = this.ctrlActions.GetMethodPostToAPI('code/validar', data);
    //    methodPost.done(res => {
    //        console.log(res.Data);
    //        this.Create(); 
    //    })
    //}

    this.getCorreo = function () {
        var pcorreo = "";
        $('#' + 'kt_form' + ' *').filter(':input').each(function (input) {
            let columnDataName = $(this).attr("ColumnDataName");
            if (columnDataName == "Correo") {
                pcorreo = this.value;
            }
        });
        this.PostValidar(pcorreo);
    }

    //function getCodigo() {
    //    var pcodigo = ""
    //    $('#' + 'kt_form_1' + ' *').filter(':input').each(function (input) {
    //        let columnDataName = $(this).attr("ColumnDataName");
    //        if (columnDataName == "Codigo") {
    //            pcodigo = this.value;
    //        }
    //    });
    //    PostValidarCodigo(pcodigo);
    //}

    function getKeyImg() {
        let imagenUrl = document.querySelector("#image_preview").src;
        let urlArray = imagenUrl.split('/');
        imagenUrl = urlArray[6];
        return imagenUrl;
    }

    this.Create = function () {
        var rol = "Administrador de plataforma";
        var estado = "Habilitado";
        var keyImg = getKeyImg();
        var data = {};
        $('#' + 'kt_form' + ' *').filter(':input').each(function (input) {
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
            console.log(res.Data);
            if (res.Data == true) {
                console.log("Registro exitoso");
            } else {
                console.log("Codigo incorrecto");
            }
        })
    }

    this.Validate = function () {

        var data = {};
        $('#' + 'kt_form' + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            if (columnDataName == "Correo" || columnDataName == "Nombre") {
                data[columnDataName] = this.value;
            }
        });
        //Hace el post al create
        this.ctrlActions.PostToAPI('code', data);

    }

    this.SetAdminEmail = function () {
        let url = location.href;
        let tmpCodigo = url.split('?')[1].split('&')[0].split('=')[1];
        var method = this.ctrlActions.GetMethodPostToAPI('request/hotel', { Id: tmpCodigo });
        method.done((res) => {
            console.log(res);
            // Set correo data & readonly
            $('#txtEmail').attr('readonly', true);
            $('#txtEmail').val(res.Data[0].Email);
        });
    }

    this.getFormValidationRules = function () {
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
$(document).ready(function () {
    var vuserCreate = new vUserCreate();
    vuserCreate.SetAdminEmail();

    jQuery.validator.addMethod("select_custom", function (value, element) {
        return this.optional(element) || value != "";
    }, 'Este campo es obligatorio.');

    KTWizard2.init();
});

