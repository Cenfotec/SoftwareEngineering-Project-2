function vUpdateService() {

    this.service = 'service';
    this.ctrlActions = new ControlActions();
    this.formId = '#modifyService';
    this.formName = 'modifyService';
    this.currentModel = {};

    this.Update = function () {

        var data = JSON.parse(localStorage.getItem('Hotel_selected'));
        document.querySelector('#txtHotel').value = data.Id;
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('modifyService');
        //Hace el post al create

        var methodPost = this.ctrlActions.GetMethodPutToAPI(this.service, customerData);

        methodPost.done(res => {

            javascript: location.href = '/dashboard/hotel'
        });

        methodPost.fail(res => {
            alert('La cédula jurídica ya existe');
        });

    };

    this.Cancel = function () {
        javascript: location.href = '/dashboard/service';
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
            Type: {
                required: true
            }
        };
        var onSubmitCallback = this.Update.bind(this);
        var formId = this.formId;
        return {
            rules,
            onSubmitCallback,
            formId
        };
    };
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vservice = new vUpdateService();
    vservice.currentModel = JSON.parse(localStorage.getItem('Service_selected'));
    vservice.ctrlActions.BindFields(vservice.formName, vservice.currentModel);
    var time = document.querySelector('#kt_timepicker_3_modal').value;
    var date = new Date(time);
    var clHourTime = date.toTimeString().substr(0, 8)
    document.querySelector('#kt_timepicker_3_modal').value = clHourTime;
    KTFormControls.init(vservice.getFormValidationRules());
});