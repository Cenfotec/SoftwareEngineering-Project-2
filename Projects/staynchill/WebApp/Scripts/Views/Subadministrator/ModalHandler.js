function fillAsignarRolData() {
    //Get roles
    var info = {}
    var idHotel = JSON.parse(localStorage.getItem("Hotel_selected")).Id;
    info.Hotel = idHotel;
    var ctrlActions = new ControlActions()
    var methodPost = ctrlActions.GetMethodPostToAPI('rol/roles', info);
        methodPost.done(res => {
            if (res.Message == "true") {
                FillSelect(res.Data);
            }
        });
}

function FillSelect(vista) {
    console.log(vista);
    var correoSubadministrador = localStorage.getItem("Subadministrator_selected_correo");
    var ctrlActions = new ControlActions();
    var methodPost = ctrlActions.GetMethodPostToAPI('rol/rolesbyuser', { Name: correoSubadministrador });
    methodPost.done(res => {
        console.log(res.Data);
        let select = document.querySelector('#select_roles');
        let vistas = vista
        select.innerHTML = "";
        for (let i = 0; i < vistas.length; i++) {
            let opt = document.createElement('option');

            // Fill existing roles
            if (res.Data != null) {
                for (let j = 0; j < res.Data.length; j++) {
                    if (res.Data[j].Name == vistas[i].Name) {
                        opt.selected = 'selected';
                    }
                }
            }

            opt.value = vistas[i].Name;
            opt.innerHTML = vistas[i].Name;
            select.appendChild(opt);
        }
    });
}


function getData (){
        select = document.querySelector('#select_roles').nextSibling.childNodes[0].childNodes[0].childNodes[0];
        var arrayRoles = [];
        var rolesString = "";
        for (let i = 0; i < select.childNodes.length; i++) {
            arrayRoles.push(select.childNodes[i].title) 
        }
        rolesString = arrayRoles.join(",");
        rolesString = rolesString.substr(0,(rolesString.length)-1);
        this.Create(rolesString);
    }

function Create(rolesString){
    var info = {};
    var idUsuario = localStorage.getItem("Subadministrator_selected_id");
    var idHotel = JSON.parse(localStorage.getItem("Hotel_selected")).Id;
    info.Name = idUsuario;
    info.Hotel = idHotel;
    info.PermisosString = rolesString
   
    //Hace el post al create
    var ctrlActions = new ControlActions()
    if(true){
        var methodPost = ctrlActions.GetMethodPostToAPI('rol/asignar', info);
        methodPost.done(res => {
       });
       $.notify({
                    // options
                    icon: 'glyphicon glyphicon-warning-sign',
                    title: 'Roles asignados',
                    message: 'Los roles han sidos asignados correctamente al subadministrador.'
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
        
    }
}

