function vRoles() {

    this.tblRolesId = "TBL_ROLES";
    this.service = "rol";
    this.ctrlActions = new ControlActions();
    this.columns = "Name,Action,Hotel";
    this.formId = "#form_1";

    this.GetTableColumsDataName = function(tblRolesId) {
        var val = $('#' + tblRolesId).attr("ColumnsDataName");
        return val;
    }

    this.FillTable = function () {
        var idHotel = JSON.parse(localStorage.getItem('Hotel_selected')).Id;
        var arrayColumnsData = [];
        var ctrlActions = new ControlActions();
        var columns = ctrlActions.GetTableColumsDataName('TBL_ROLES').split(',');
        $.each(columns, function(index, value) {
            var obj = {};
            obj.data = value;
            arrayColumnsData.push(obj);
        });

        $('#' + 'TBL_ROLES').DataTable({
            "processing": true,
            "ajax": {
                "url": "http://localhost:54312/api/rol/" + idHotel,
                dataSrc: function (data) {

                    if (data.Data == null) {
                        return [];
                    }
                    else {
                        return data.Data;
                    }
                }

            },
            "columns": arrayColumnsData,
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
            },
            "columnDefs": [{
                    "targets": -1,
                    "data": null,
                    "defaultContent": `<button
                    type="button"
                    id="btnDecline"
                    class="btn btn-label-danger btn-pill">
                        <i class="flaticon-delete">
                        </i>
                        Eliminar
                    </button>`
                }]
        });
    }

    $('#TBL_ROLES').on('click', 'button', (x) => {
        if ($(x.target).attr('id') == 'btnDecline') {
            //ParentNode : Para acceder a los elementos padres
            //ChildNodes : ChildNode para bajar al elemento siguiente
            //InnerText : Acceder al texto que guarda un elemento
            let rolName = x.target.parentNode.parentNode.childNodes[0].innerText;
            let idHotel = JSON.parse(localStorage.getItem('Hotel_selected')).Id;
            //console.log("Eliminar el rol " + rolName + " con Id de Hotel " + idHotel)
            var data = {};
            data.Name = rolName;
            data.Hotel = idHotel;
            var methodDelete = this.ctrlActions.GetMethodDeleteToAPI(this.service, data);
            methodDelete.done(res => {
                    location.reload();
                });
            }
    });

    this.ReloadTable = function() {
        this.FillTable();
    }

    this.getRol = function() {
        var pRol = "";
        $('#' + 'form_1' + ' *').filter(':input').each(function(input) {
            let columnDataName = $(this).attr("ColumnDataName");
            if (columnDataName == "Name") {
                pRol = this.value;
            }
        });
        this.PostValidar(pRol);
    }

    this.PostValidar = function(pRol) {
        var data = {};
        var idHotel = JSON.parse(localStorage.getItem('Hotel_selected')).Id;
        data.Name = pRol;
        data.Hotel = idHotel;
        var methodPost = this.ctrlActions.GetMethodPostToAPI('rol/get', data);
        methodPost.done(res => {
            console.log(res.Data);
            if (res.Data == true) {
                this.getData();
            } else {
                $.notify({
                    // options
                    icon: 'glyphicon glyphicon-warning-sign',
                    title: 'Registro inválido',
                    message: 'El rol ingresado ya existe.'
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
            }
        })

    }

    this.Create = function(permisosString) {
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('form_1');
        var idHotel = JSON.parse(localStorage.getItem('Hotel_selected')).Id;
        customerData.Hotel = idHotel;
        customerData.PermisosString = permisosString;
        //Hace el post al create
        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, customerData);
        //Refresca la tabla
        methodPost.done(res => {
            location.reload();
        });
    }

    this.getPermission = function(){
    
    var methodPost = this.ctrlActions.GetMethodGetToApi('rol/permisos', "");
        methodPost.done(res => {
            if (res.Message == "true") {
                this.FillSelect(res.Data);
            }
        });
    }

    this.FillSelect = function(vista){

        let select = document.querySelector('#select_permisos');
        let vistas = vista

        for (let i = 0; i < vistas.length; i++) {
            let opt = document.createElement('option');
            opt.value = vistas[i].Name;
            opt.innerHTML = vistas[i].Name;
            select.appendChild(opt);
        }
    }

    this.getData = function(){
        select = document.querySelector('#select_permisos').nextSibling.childNodes[0].childNodes[0].childNodes[0];
        var arrayPermisos = [];
        var permisosString = "";
        for (let i = 0; i < select.childNodes.length; i++) {
            arrayPermisos.push(select.childNodes[i].title) 
        }
        permisosString = arrayPermisos.join(",");
        permisosString = permisosString.substr(0,(permisosString.length)-1);
        this.Create(permisosString);
    }

    this.getFormValidationRules = function() {
        var rules = {
            Name: {
                required: true
            },
            Multiselect: {
                required: true,
                multiselect_custom: true
            }
        }
        var onSubmitCallback = this.getRol.bind(this)
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

    var vrol = new vRoles();
    vrol.FillTable();
    vrol.getPermission();

    jQuery.validator.addMethod("multiselect_custom", function (value, element) {
        return this.optional(element) || document.querySelector('#select_permisos').nextSibling.childNodes[0].childNodes[0].childNodes[0].childNodes.length > 1;
    }, 'Este campo es obligatorio.');

    KTFormControls.init(vrol.getFormValidationRules());

});