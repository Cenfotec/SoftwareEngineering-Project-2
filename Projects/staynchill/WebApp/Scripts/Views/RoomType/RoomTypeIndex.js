function RoomTypeIndex() {

    this.tblRoomTypeId = 'Room_type';
    this.localStorageHotel_Selected = 'Hotel_selected'
    this.localStorageRoomType_Selected = 'Room_type_selected';
    this.service = 'roomtype';
    this.ctrlActions = new ControlActions();
    this.columns = "Name,Description,AmountPeople,AmountBeds,PetsAllowed,Price,IdHotel,State,Value,Type,HorarioCheckIn,HorarioCheckOut";

    this.getHotel = () =>
        JSON.parse(localStorage.getItem(this.localStorageHotel_Selected))

    this.getRetrieveAllByIdUrl = () => {
        var url = this.service + '/getbyhotel?Id=' + this.getHotel().Id
        return url
    }

    this.RetrieveAll = function () {
        this.FillTable(this.getRetrieveAllByIdUrl(), this.tblRoomTypeId, false);
    }

    this.ReloadTable = function () {
        this.FillTable(this.service, this.tblRoomTypeId, true);
    }

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

                                obj.Price = formatter.format(obj.Price);

                                var date = new Date(obj.HorarioCheckIn);
                                var checkIn = date.toLocaleTimeString();
                                obj.HorarioCheckIn = checkIn;

                                var date2 = new Date(obj.HorarioCheckOut);
                                var checkOut = date2.toLocaleTimeString();
                                obj.HorarioCheckOut = checkOut;

                            });
                            return data.Data;
                        }
                    }
                },
                "columns": arrayColumnsData,
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                },
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
        customerData = JSON.parse(localStorage.getItem(this.localStorageRoomType_Selected));
        console.log('Im gonna send this to database ' + customerData);
        //Hace el post al delete
        var methodPost = this.ctrlActions.GetMethodDeleteToAPI(this.service, customerData);
        return methodPost
    }

    $('#' + this.tblRoomTypeId).on('click', 'button', (x) => {
        if ($(x.target).attr('id') == 'btnDelete') {
            $('#' + this.tblRoomId).click();
            console.log('Tipo de habitación eliminada');
            this.tableLogic().done(res => {
                javascript: location.reload();
            });
        } else if ($(x.target).attr('id') == 'btnUpdate') {
            $('#' + this.tblRoomId).click();
            console.log('Tipo de habitación actualizada');
            javascript: location.href = '/dashboard/roomtypes/edit';
        }
    });

    this.Delete = function () {

        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('registroTipoHabitacion');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, customerData);
        //Refresca la tabla
        this.ReloadTable();

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('registroTipoHabitacion', data);
    }

    this.BindFieldsCustom = function () {
        ////console.log("custom", data)}
        //javascript: location.href = '/dashboard/roomtypes/edit';
        //this.ctrlActions.BindFieldsCustom('registroTipoHabitacion', data);
    }

    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2
    })

}

//ON DOCUMENT READY
$(document).ready(function () {
    var vroomtypeIndex = new RoomTypeIndex();
    vroomtypeIndex.RetrieveAll();
});