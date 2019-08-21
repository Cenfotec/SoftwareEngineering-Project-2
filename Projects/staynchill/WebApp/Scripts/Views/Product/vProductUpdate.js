  function vProductUpdate() {

    this.service = 'product'
    this.ctrlActions = new ControlActions()
    this.formId = '#updateProduct'
    this.formName = 'updateProduct'
    this.currentModel = {}

    this.Update = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm(this.formName);

        //Hace el post al create
        //Refresca la tabla
        //this.ReloadTable();

        var methodPut = this.ctrlActions.GetMethodPutToAPI(this.service, customerData);

        methodPut.done(res => {
            javascript: location.href = '/dashboard/product'
        })

    }

    this.getFormValidationRules = function() {
        var rules = {
            Code: {
                required: true
            },
            Name: {
                required: true,
                email: true
            },
            Description: {
                required: true
            },
            ArrivalDate: {
                required: true,
                date: true
            },
            State: {
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
$(document).ready(function () {
    var vproduct = new vProductUpdate();
    vproduct.currentModel = JSON.parse(localStorage.getItem('TBL_PRODUCTS_selected'));
    vproduct.ctrlActions.BindFields(vproduct.formName, vproduct.currentModel);
    KTFormControls.init(vproduct.getFormValidationRules());

});


