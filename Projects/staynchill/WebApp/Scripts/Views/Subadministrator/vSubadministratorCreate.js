function vSubadministratorCreate() {

    this.tblRegisterManagersId = 'TBL_USUARIOS';
    this.service = 'user';
    this.ctrlActions = new ControlActions();
    this.formId = '#registrarSubadmin';


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
    

    this.getCorreo = function () {
        var pcorreo = "";
        $('#' + 'registrarSubadmin' + ' *').filter(':input').each(function (input) {
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

    this.Create = function () {
        var rol = "Subadministrador de hotel";
        var estado = "Habilitado";
        var keyImg = getKeyImg();
        var data = {};
        $('#' + 'registrarSubadmin' + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            if (columnDataName != "CContrasenna") {
                data[columnDataName] = this.value;
            }
        });
        data.Rol = rol;
        data.Estado = estado;
        data.Imagen = keyImg;
        // Change code to Hotel ID
        data.Codigo = JSON.parse(localStorage.getItem('Hotel_selected')).Id;
        console.log(data);
        // Hace el post al create
        var method = this.ctrlActions.GetMethodPostToAPI(this.service, data);
        method.done(res => {
            javascript: location.href = '/dashboard/subadministrators'
        })
    }

    this.Validate = function () {

        var data = {};
        $('#' + 'registrarSubadmin' + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            if (columnDataName == "Correo" || columnDataName == "Nombre") {
                data[columnDataName] = this.value;
            }
        });
        //Hace el post al create
        this.ctrlActions.PostToAPI('code', data);

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
    var vsubadmin = new vSubadministratorCreate();

    jQuery.validator.addMethod("select_custom", function (value, element) {
        return this.optional(element) || value != "";
    }, 'Este campo es obligatorio.');

    KTFormControls.init(vsubadmin.getFormValidationRules());
});

