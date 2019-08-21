function vRoomIndex() {

    this.tblRoomId = 'Room'
    this.localStorageHotel_Selected = 'Hotel_selected'
    this.localStorageRoom_Selected = 'Room_selected';
    this.service = 'room'
    this.ctrlActions = new ControlActions();
    this.columns = "Id,RoomType,RoomTypeName,RoomNumber,Description,State,IdHotel,Value,Type";

    //arrow function
    this.getHotel = () =>
        JSON.parse(localStorage.getItem(this.localStorageHotel_Selected))

    this.getRetrieveAllByIdUrl = () => {
        var url = this.service + '?Id=' + this.getHotel().Id
        return url
    }
    this.RetrieveAll = function () {
        this.FillTableWithButtons(this.getRetrieveAllByIdUrl(), this.tblRoomId, false);
    }

    this.FillTableWithButtons = function (service, tableId, refresh) {
        if (!refresh) {
            columns = this.ctrlActions.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];

            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "processing": true,
                "ajax": {
                    "url": this.ctrlActions.GetUrlApiService(service),
                    dataSrc: function (data) {

                        if (data.Data == null) {
                            return [];
                        }
                        else {
                            return data.Data;
                        }
                    },
                },
                "columns": arrayColumnsData,
                "columnDefs": [{
                    "targets": -1,
                    "data": null,
                    "defaultContent": `
                    <button
                    type="button"
                    id="btnUpdate"
                    class="btn btn-label-primary btn-pill">
                        <i class="flaticon-edit">
                        </i>
                        Editar
                    </button>
                    <button
                    type="button"
                    id="btnDelete"
                    class="btn btn-label-danger btn-pill">
                        <i class="flaticon-delete">
                        </i>
                        Eliminar
                    </button>`
                }]
            });

        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();
        }
    }

    this.tableLogic = () => {
        var customerData = {};
        customerData = JSON.parse(localStorage.getItem(this.localStorageRoom_Selected));
        console.log('Im gonna send this to database ' + customerData);
        //Hace el post al delete
        var methodPost = this.ctrlActions.GetMethodDeleteToAPI(this.service, customerData);
        return methodPost
    }

    $('#' + this.tblRoomId).on('click', 'button', (x) => {
        if ($(x.target).attr('id') == 'btnDelete') {
            $('#' + this.tblRoomId).click();
            console.log('Habitación eliminada');
            this.tableLogic().done(res => {
                javascript: location.reload();
            });
        } else if ($(x.target).attr('id') == 'btnUpdate') {
            $('#' + this.tblRoomId).click();
            console.log('Habitación actualizada');
            javascript: location.href = '/dashboard/rooms/edit';
        }
    });

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.getRetrieveAllByIdUrl(), this.tblRoomId, true, [0, 1, 5, 6, 7]);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('registroHabitacion', data);
    }

    this.BindFieldsCustom = function () {
        //console.log("custom", data)
        //javascript: location.href = '/dashboard/rooms/edit';
        //this.ctrlActions.BindFieldsCustom('registroTipoHabitacion', data);
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vroomIndex = new vRoomIndex();
    vroomIndex.RetrieveAll();


});