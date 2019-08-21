function vProductIndex() {

    this.tblProductsId = 'TBL_PRODUCTS';
    this.service = 'product';
    this.ctrlActions = new ControlActions();
    this.columns = "Code,Name,Description,ArrivalDate,State";
    this.formId = '#registroProductos';

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblProductsId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblProductsId, true);
    }

    this.Create = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('registroProductos');
        //Hace el post al create
        this.ctrlActions.PostToAPI(this.service, customerData);
        //Refresca la tabla
        //this.ReloadTable();
    }

    this.Update = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('registroProductos');
        //Hace el post al create
        this.ctrlActions.PutToAPI(this.service, customerData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.Delete = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('registroProductos');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, customerData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('registroProductos', data);
    }

    this.BindFieldsCustom = function (data) {
        //console.log("custom", data)
        javascript: location.href = '/dashboard/product/edit';
        //this.ctrlActions.BindFieldsCustom('registroProductos', data);
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

    var vproduct = new vProductIndex();
    vproduct.RetrieveAll();
    KTFormControls.init(vproduct.getFormValidationRules());

});

