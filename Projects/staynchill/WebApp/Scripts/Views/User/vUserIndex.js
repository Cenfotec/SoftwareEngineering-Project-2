function vUserIndex() {
    
    this.tblProductsId = 'TBL_USUARIOS';
    this.service = 'user/getAll';
    this.ctrlActions = new ControlActions();
    this.columns = "Cedula,Nombre,Apellido,Correo,Telefono,Provincia,Estado,Rol";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblProductsId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblProductsId, true);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('kt_form_1', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vuserIndex = new vUserIndex();
    vuserIndex.RetrieveAll();

});

