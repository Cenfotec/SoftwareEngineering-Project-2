function ControlActions() {
    this.URL_API = "http://localhost:54312/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }

    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");
        return val;
    }

    this.GetTableDataId = function (tableId) {
        return $('#' + tableId).attr("DataId");
    }

    this.FillTable = function (service, tableId, refresh) {
        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "processing": false,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: function (data) {

                        if (data.Data == null) {
                            return [];
                        }
                        else {
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

    this.FillTableWithButtons = function (service, tableId, refresh) {
        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];

            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "processing": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
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
                    "defaultContent": `<button
                        id="btnAccept"
                        type="button"
                        class="btn btn-label-primary btn-pill"
                        data-toggle="modal"
                        data-target="#kt_modal_4">
                            <i class="flaticon2-checkmark">
                            </i>
                            Procesar
                    </button>
                    <button
                    type="button"
                    id="btnDecline"
                    class="btn btn-label-danger btn-pill">
                        <i class="flaticon-delete">
                        </i>
                        Rechazar
                    </button>`
                }]
            });

        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();
        }
    }

    this.GetSelectedRow = function () {
        var data = sessionStorage.getItem(tableId + '_selected');

        return data;
    };

    this.BindFields = function (formId, data) {
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            this.value = data[columnDataName];
        });
    }

    // BindFields Custom
    this.BindFieldsCustom = function (formId, data) {
        console.log('Data: ', data);
        console.log($(this));
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            this.value = data[columnDataName];
        });
    }

    this.GetDataForm = function (formId) {
        var data = {};
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            data[columnDataName] = this.value;
        });
        console.log(data);
        return data;
    }

    this.ShowMessage = function (type, message) {
        if (type == 'E') {
            $("#alert_container").removeClass("alert alert-success alert-dismissable")
            $("#alert_container").addClass("alert alert-danger alert-dismissable");
            $("#alert_message").text(message);
        } else if (type == 'I') {
            $("#alert_container").removeClass("alert alert-danger alert-dismissable")
            $("#alert_container").addClass("alert alert-success alert-dismissable");
            $("#alert_message").text(message);
        }
        $('.alert').show();
    };

    this.PostToAPI = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
    };

    this.GetMethodPostToAPI = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data)
            .done(function (response) {
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('I', response.Message);
            })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            });

        return jqxhr;
    };

    this.PutToAPI = function (service, data) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
    };

    this.GetMethodPutToAPI = function (service, data) {
        var jqxhr = $.put(this.GetUrlApiService(service), data)
            .done(function (response) {
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('I', response.Message);
            })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            });
        return jqxhr;
    };

    this.DeleteToAPI = function (service, data) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
    };

    this.GetMethodDeleteToAPI = function (service, data) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data)
            .done(function (response) {
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('I', response.Message);
            })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
        return jqxhr;
    };


    this.GetToApi = function (service, callbackFunction) {
        var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            console.log("Response " + response);
            callbackFunction(response.Data);
        });
    }


    this.GetMethodGetToApi = function (service, data) {
        var jqxhr = $.get(this.GetUrlApiService(service), data)
            .done(function (response) {
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('I', response.Message);
            })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            });

        return jqxhr;
    };

    this.GetMethodGetToApiReturnsJSON = function (service, data) {
        var jqxhr = $.get(this.GetUrlApiService(service), data, "json")
            .done(function (response) {
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('I', response.Message);
            })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            });

        return jqxhr;
    };
}

//Custom jquery actions
$.put = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'PUT',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}

$.delete = function (url, data, callback) {
    if ($.isFunction(data)) {
        type = type || callback,
            callback = data,
            data = {}
    }
    return $.ajax({
        url: url,
        type: 'DELETE',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'
    });
}