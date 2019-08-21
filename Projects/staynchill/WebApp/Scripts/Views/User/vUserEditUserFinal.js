function vUserEditUserFinal() {
    this.service = 'user';
    this.ctrlActions = new ControlActions();
    this.formId = '#registrarAdminPlataforma';

    function getKeyImg() {
        let imagenUrl = document.querySelector("#image_preview").src;
        let urlArray = imagenUrl.split('/');
        imagenUrl = urlArray[6];
        return imagenUrl;
    }

    this.Update = function() {
        var user = JSON.parse(localStorage.getItem('_userLogged'));
        var imagen = getKeyImg();
        var data = {};
        data.Id = 1;
        data.Codigo = "";
        data.Contrasenna = "";
        data.Estado = "Habilitado";
        data.Rol = "";
        $('#' + 'registrarAdminPlataforma' + ' *').filter(':input').each(function(input) {
            var columnDataName = $(this).attr("ColumnDataName");
                data[columnDataName] = this.value;
        });
        data.Imagen = imagen;
        data.Correo = user.Correo;
        console.log(data);
        var method = this.ctrlActions.GetMethodPutToAPI(this.service, data);
        method.done(res => {
            location.href = '/'
        })
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

//ON DOCUMENT READY
$(document).ready(function() {
    var vuserCreate = new vUserEditUserFinal();
    var user = JSON.parse(localStorage.getItem('_userLogged'));
    var data = {};
    data.Correo = user.Correo;
    var method = vuserCreate.ctrlActions.GetMethodPostToAPI('user/correo', data);
        method.done(res => {
        user = res.Data;
        document.getElementById("txtCedula").value = user.Cedula;
        document.getElementById("txtPrimerNombre").value = user.Nombre;
        document.getElementById("txtSegundoNombre").value = user.SegNombre;
        document.getElementById("txtPrimerApellido").value = user.Apellido;
        document.getElementById("txtSegundoApellido").value = user.SegApellido;
        document.getElementById("txtTelefono").value = user.Telefono;
        document.getElementById("txtDireccion").value = user.Direccion; 

        var slctProvinces = new SelectProvinces();
        console.log(slctProvinces);
        document.getElementById("txtHiddenProvincia").value = user.Provincia;
        document.getElementById("txtHiddenCanton").value = user.Canton;
        document.getElementById("txtHiddenDistrito").value = user.Distrito;
        document.querySelector('#inputProvincia').value = document.querySelector('#txtHiddenProvincia').value
        slctProvinces.popularCanton();
        document.querySelector('#inputCanton').value = document.querySelector('#txtHiddenCanton').value;
        slctProvinces.popularDistrito();
        document.querySelector('#inputDistrito').value = document.querySelector('#txtHiddenDistrito').value;
    })
    
    jQuery.validator.addMethod("select_custom", function(value, element) {
        return this.optional(element) || value != "";
    }, 'Este campo es obligatorio.');
    
    KTFormControls.init(vuserCreate.getFormValidationRules());
});