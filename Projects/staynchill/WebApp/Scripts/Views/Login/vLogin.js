function vLogin() {

    this.service = 'loginvalidate'
    this.ctrlActions = new ControlActions()
    this.formId = '#loginForm'

    this.Login = function() {
        var email = $('#txtEmail').val();
        var password = $('#txtPassword').val();
        var data = {};
        data.Correo = email;
        data.Contrasenna = password;
        var userLoginRequest = this.ctrlActions.GetMethodPostToAPI(this.service, data);

        userLoginRequest.done(response => {
            let userLogged = response.Data;

            var isCheckedInRequest = this.ctrlActions.GetMethodGetToApi('userreservation' + '/' + response.Data.Id);
            isCheckedInRequest.done(res_2 => {
                userLogged.IsCheckedIn = (res_2.Data == null) ? 0 : 1;
                console.log(userLogged);
                $.post('http://localhost:54388/dashboard/login', userLogged)
                    .done(() => {
                        localStorage.setItem('_userLogged', JSON.stringify(userLogged));
                        location.replace('.');
                    });
            });

        });

        // Fail
        userLoginRequest.fail(function (res) {
            res = res.responseJSON;

            $.notify({
                // options
                icon: 'glyphicon glyphicon-warning-sign',
                title: 'Error inicio de sesión',
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
        }
        );
    }

    this.getFormValidationRules = function () {
        var rules = {
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: true
            }
        }
        var onSubmitCallback = this.Login.bind(this)
        var formId = this.formId
        return {
            rules,
            onSubmitCallback,
            formId
        }
    }
}

function forgotPassword() {
    var email = $('#txtRecoverEmail').val();
    if (validateEmail(email)) {
        sendEmail(email);
    }
}

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function sendEmail(email) {
    var ctrlActions = new ControlActions();
    var data = {
        Correo: email
    };
    ctrlActions.GetMethodPostToAPI('forgotpassword', data);
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vlogin = new vLogin();
    KTFormControls.init(vlogin.getFormValidationRules());
    sessionStorage.clear();
    localStorage.clear();
});