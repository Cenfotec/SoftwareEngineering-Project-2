function vHotelIndex() {

    this.tblRolesId = "TBL_HOTELES";
    this.service = "hotel/administrador";
    this.ctrlActions = new ControlActions();
    this.columns = "LegalNumber,BusinessName,Name,HotelEmail,PhoneNumber,Stars,State,Actions,Id";
    this.formId = "#form_1";

    this.FillTable = function() {
        var arrayColumnsData = [];
        var ctrlActions = new ControlActions();
        var columns = ctrlActions.GetTableColumsDataName('TBL_HOTELES').split(',');
        $.each(columns, function(index, value) {
            var obj = {};
            obj.data = value;
            arrayColumnsData.push(obj);
        });

        $('#' + 'TBL_HOTELES').DataTable({
            "processing": true,
            "ajax": {
                "url": "http://localhost:54312/api/" + this.service,
                dataSrc: function(data) {

                    if (data.Data == null) {
                        return [];
                    } else {
                        for (let i = 0; i < data.Data.length; i++) {
                            if (data.Data[i].State == 'Enabled') {
                                data.Data[i].State = 'Habilitado';
                            }
                            if (data.Data[i].State == 'Disabled') {
                                data.Data[i].State = 'Deshabilitado';
                            }
                            if (data.Data[i].State == 'Deleted') {
                                data.Data[i].State = 'Eliminado';
                            }
                        }
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
                "defaultContent": `<button
                    type="button"
                    id="btnDecline"
                    class="btn btn-primary btn-elevate btn-icon la la-cogs" 
                    data-toggle="modal" 
                    data-target="#kt_select2_modal">
                    </button> `

            }]
        });
    }


    $('#TBL_HOTELES').on('click', 'button', (x) => {
        if ($(x.target).attr('id') == 'btnDecline') {
            //ParentNode : Para acceder a los elementos padres
            //ChildNodes : ChildNode para bajar al elemento siguiente
            //InnerText : Acceder al texto que guarda un elemento
            let number = x.target.parentNode.parentNode.childNodes[0].innerText;
            var data = {};
            data.Percentage = number;
            var methodGet = this.ctrlActions.GetMethodPostToAPI('commission/administrador', data);
            methodGet.done(res => {
                let commission = res.Data;
                document.getElementById("txtCommission").value = commission[0].Percentage;
                document.getElementById("txtHotel").value = commission[0].FkHotel;

            });
        }
    });

    this.Update = function() {
        var porcentaje = document.getElementById("txtCommission").value;
        var fkHotel = document.getElementById("txtHotel").value;
        var data = {};
        data.FkHotel = fkHotel;
        data.Percentage = porcentaje;
        data.Id = 1;
        var methodPut = this.ctrlActions.GetMethodPutToAPI('commission/administrador', data);
        $('#btnUpdate')[0].setAttribute('data-dismiss', 'modal');
        $('#btnUpdate')[0].click();
        $('#btnUpdate')[0].removeAttribute('data-dismiss');
        methodPut.done(res => {
            
        });
    }

    this.getFormValidationRules = function() {
        var rules = {
            Commission: {
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
$(document).ready(function() {

    var vhotelIndex = new vHotelIndex();
    vhotelIndex.FillTable();
    KTFormControls.init(vhotelIndex.getFormValidationRules());

});