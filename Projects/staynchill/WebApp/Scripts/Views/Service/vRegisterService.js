function vRegisterService() {
    this.service = 'service';
    this.ctrlActions = new ControlActions();
    this.formId = '#registerService'
    this.formName = 'registerService'

    this.Create = function () {
        var data = JSON.parse(localStorage.getItem('Hotel_selected'));
        document.querySelector('#txtHotel').value = data.Id;
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('registerService');
        //Hace el post al create

        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, customerData);

        methodPost.done(res => {
            javascript: location.href = '/dashboard/hotel'
        })

        methodPost.fail(res => {
            alert('La cédula jurídica ya existe');
        })

    }

    this.Cancel = function () {
        javascript: location.href = '/dashboard/hotel';
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
                number: true
            },
            Type: {
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
        var vregister = new vRegisterService();
        KTFormControls.init(vregister.getFormValidationRules());

    });