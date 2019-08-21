function vReservacionIndex() {
    var idUsuario = JSON.parse(localStorage.getItem('_userLogged')).Id;
    this.tblProductsId = 'TBL_RESERVAS';
    this.service = 'reservation' + '/' + idUsuario;
    this.ctrlActions = new ControlActions();
    this.columns = "User,Hotel,RoomNum,BeginDate,EndDate,Price,Status";

    this.FillTable = function (service, tableId, refresh) {
        if (!refresh) {
            columns = this.ctrlActions.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "processing": false,
                "ajax": {
                    "url": this.ctrlActions.GetUrlApiService(service),
                    dataSrc: function (data) {

                        if (data.Data == null) {
                            return [];
                        }
                        else {
                                data.Data.forEach(function (obj) {
                                var begin = new Date(obj.BeginDate);
                                obj.BeginDate = begin.toLocaleDateString();
                                var end = new Date(obj.EndDate);
                                obj.EndDate = end.toLocaleDateString();
                            });

                            data.Data.forEach(function (obj) {
                                if (obj.Status == 'Enabled') {
                                    obj.Status = 'Activa';
                                } else if (obj.Status == 'Finished') {
                                    obj.Status = 'Finalizada';
                                }
                            });

                            data.Data.forEach(function (obj) {
                                obj.Price = '$' + obj.Price;
                            });

                            return data.Data;
                        }
                    }
                },
                "columns": arrayColumnsData,
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                }
            });
        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();
        }

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

    var vuserIndex = new vReservacionIndex();
    var idUsuario = JSON.parse(localStorage.getItem('_userLogged')).Id;
    var tblProductsId = 'TBL_RESERVAS';
    var service = 'reservation' + '/' + idUsuario;
    vuserIndex.FillTable(service, tblProductsId, false);

});

