function vSMSCreate() {

    this.service = 'sms'
    this.ctrlActions = new ControlActions()
    this.formId = '#CreateSMS'
    this.formName = 'CreateSMS'

    this.Create = function () {

        var formData = {};
        formData = this.ctrlActions.GetDataForm(this.formName);
        //Hace el post al create
        formData.FkHotel = 7
        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, formData);

        methodPost.done( res => {
            javascript:location.href='/dashboard'
        })

    }

    this.Cancel = function () {
        javascript:location.href = '/dashboard';
    }

    this.getFormValidationRules = function() {
        var rules = {
            Message: {
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

    var vSMS = new vSMSCreate();
    KTFormControls.init(vSMS.getFormValidationRules());

});
