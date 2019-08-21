function vCommon() {

    this.tblCommonId = "TBL_COMMON";
    this.service = "common";
    this.ctrlActions = new ControlActions();
    this.columns = "Type,Action,Date";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblCommonId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblCommonId, true);
    }
}

//ON DOCUMENT READY
$(document).ready(function() {

    var vcommon = new vCommon();
    vcommon.RetrieveAll();

});