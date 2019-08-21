function vProductCreate() {

    this.service = 'product'
    this.ctrlActions = new ControlActions()
    this.formId = '#registroProductos'
    this.formName = 'registroProductos'

    this.Create = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('registroProductos');
        //Hace el post al create
        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, customerData);
        
        methodPost.done( res => {
            javascript:location.href='/dashboard/product'
        })
        
    }

    this.Update = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm(this.formName);
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, customerData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.getFormValidationRules = function() {
        var rules = {
            Name: {
                required: true
            },
            Description: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            PhoneNumber: {
                required: true
            },
            Stars: {
                required: true
            },
            Province: {
                required: true
            },
            Canton: {
                required: true
            },
            District: {
                required: true
            },
            DailySales: {
                required: true
            },
            MonthlySales: {
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

    var vproduct = new vProductCreate();
    KTFormControls.init(vproduct.getFormValidationRules());

});

