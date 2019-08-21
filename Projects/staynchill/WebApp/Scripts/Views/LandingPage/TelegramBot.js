function TelegramBot() {

    this.service = 'telegram';
    this.ctrlActions = new ControlActions();
    this.formId = '#telegramForm'
    this.formName = 'telegramForm'

    this.Create = function () {
        var user = JSON.parse(localStorage.getItem('_userLogged'));
        if (user.Rol == 'Administrador de plataforma' || user.Rol == 'Administrador de hotel') {

        } else {
            var reservacion = JSON.parse(localStorage.getItem('_userReservation')).Subreservacion;

            if (reservacion == undefined) {
                console.log('sin reservacion')
            } else {
                var data = {};
                data.telegramUsername = $('#txtUsuario')[0].value;
                data.FK_Subreservacion = reservacion;
                var telegramPost = this.ctrlActions.GetMethodPostToAPI(this.service, data);
                telegramPost.done(res => {
                    window.open('https://web.telegram.org/#/im?p=@FranciscaBot', '_blank')
                });
            }
        }
    }

    this.getFormValidationRules = function () {
        var rules = {
            Usuario: {
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
    var telegram = new TelegramBot();
    KTFormControls.init(telegram.getFormValidationRules());
});
