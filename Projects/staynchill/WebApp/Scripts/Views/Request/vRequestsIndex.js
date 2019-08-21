function padDate(dt, formatter) {
    var useDt = dt || new Date(),
        d = useDt.getDate(),
        m = useDt.getMonth() + 1,
        y = useDt.getFullYear(),
        h = useDt.getHours(),
        n = useDt.getMinutes(),
        s = useDt.getSeconds(),
        z = useDt.getMilliseconds(),
        f = formatter || function (fyr, fmo, fdy, fhr, fmn, fse, fms) {
            return fyr + '/' + fmo + '/' + fdy;
        },
        r = f('' + y, (m < 10 && '0' || '') + m, (d < 10 && '0' || '') + d, (h < 10 && '0' || '') + h, (n < 10 && '0' || '') + n, (s < 10 && '0' || '') + s, (z < 10 && '000' || z < 100 && '00' || z < 1000 && '0') + z);
    return r;
}

function vRequests() {

    this.tblRequestsId = 'kt_table_1';
    this.service = 'request';
    this.ctrlActions = new ControlActions();
    this.columns = "Hotel,HotelName,Date,DailySales,MonthlySales,Email,Actions";

    this.MembershipService = 'membership'
    this.membershipFormId = '#CreateMembership'
    this.membershipFormName = 'CreateMembership'

    this.commissionService = 'commission'
    this.commissionFormId = '#CreateCommission'
    this.commissionFormName = 'CreateMembership'
    this.membership = {}

    this.CreateMembership = function () {
        console.log(this)
        var formData = {};
        formData = this.ctrlActions.GetDataForm(this.membershipFormName);


        //Hace el post al create
        this.membership.FkHotel = JSON.parse(localStorage.getItem('kt_table_1_selected')).Hotel
        console.log("FK_HOTEL", this.membership.FkHotel)
        this.membership.NumberMonths = formData.NumberMonths
        this.membership.Price = formData.Price
        this.membership.State = "enabled"
        var endDate = new Date()
        endDate.setMonth(endDate.getMonth() + this.membership.NumberMonths)
        this.membership.StartDate = new Date().toUTCString()
        this.membership.EndDate = endDate.toUTCString()
        var newMembership = JSON.parse(JSON.stringify(this.membership))
        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.MembershipService, newMembership);
        return methodPost

    }

    this.RetrieveAll = function () {
        this.FillTableWithButtons(this.service, this.tblRequestsId, false);
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
                            data.Data.forEach(function (obj) {
                                obj.DailySales = formatter.format(obj.DailySales);
                                obj.MonthlySales = formatter.format(obj.MonthlySales);
                                var date = new Date(obj.Date);
                                obj.Date = date.toLocaleDateString();
                            });
                            return data.Data;
                        }
                    },
                },
                "columns": arrayColumnsData,
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
                },
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

    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2
    })

    this.ReloadTable = function () {
        this.ctrlActions.FillTableWithButtons(this.service, this.tblRequestsId, true);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('kt_form_1', data);
    }

    this.tableLogic = () => {
        var customerData = {};
        this.customerData = this.ctrlActions.GetDataForm('kt_form_1'); //fix this
        console.log('Im gonna send this to database ' + customerData);
        //Hace el post al put
        var methodPost = this.ctrlActions.GetMethodPutToAPI(this.service, this.customerData); //fix this
        return methodPost
    }

    this.PostCommission = () => {
        var formData = {}
        formData = this.ctrlActions.GetDataForm(this.commissionFormName)
        var newCommission = {}

        //Hace el post al create
        newCommission.FkHotel = JSON.parse(localStorage.getItem('kt_table_1_selected')).Hotel
        console.log("FK_HOTEL", newCommission.FkHotel)
        newCommission.Percentage = formData.Commission
        console.log('Datos de comision: ', newCommission)
        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.commissionService, newCommission);
        return methodPost
    }

    this.SendEmail = () => {
        var email = {}
        email.Percentage = JSON.parse(localStorage.getItem('kt_table_1_selected')).Email;
        email.FkHotel = JSON.parse(localStorage.getItem('kt_table_1_selected')).Hotel

        email.membershipPrice = this.membership.Price
        email.membershipMonths = this.membership.NumberMonths
        email.membershipStartDate = this.membership.StartDate
        email.membershipEndDate = this.membership.EndDate

        console.log(email)
        var service = this.commissionService + "/email"
        //Hace el post al create
        var methodPost = this.ctrlActions.GetMethodPostToAPI(service, email);
        methodPost.done(res => {
            console.log(res.Message);
        });
        return methodPost
    }

    this.Onsubmit = function () {
        document.querySelector('#txtState').value = 'Approved';
        var methodPost = this.CreateMembership()
        methodPost.done(res => {
            this.tableLogic().done(res => {
                this.PostCommission().done(res => {
                    this.SendEmail().done(res => {
                        javascript: location.href = '/dashboard/requests'
                    })
                })
            })
        })
    }

    this.getFormValidationRules = function () {
        var rules = {
            Price: {
                required: true,
                number: true
            },
            NumberMonths: {
                required: true,
                number: true,
                range: [1, 12]
            },
            Commission: {
                required: true,
                number: true,
                range: [0, 100]
            }
        }
        var onSubmitCallback = this.Onsubmit.bind(this)
        var formId = this.membershipFormId
        return {
            rules,
            onSubmitCallback,
            formId
        }
    }

    $('#kt_table_1').on('click', 'button', (x) => {
        if ($(x.target).attr('id') == 'btnDecline') {
            console.log('Hotel rechazado');
            swal.fire({
                title: 'Rechazar hotel',
                text: "¿Está seguro que desea rechazar la solicitud de este hotel?",
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Rechazar',
                cancelButtonText: 'Cancelar'
            }).then(function (result) {
                if (result.value) {
                    document.querySelector('#txtState').value = 'Disapproved';

                    let dSales = document.querySelector('#txtDailySales').value
                    var price = dSales.replace(/,/g, '.');
                    price = price.replace(/\$/g, '');
                    price = price.split('.').join("");
                    price = price.split('.').join("");
                    console.log(price);
                    document.querySelector('#txtDailySales').value = price;
            
                    let mSales = document.querySelector('#txtMonthlySales').value;
                    var price2 = mSales.replace(/,/g, '.');
                    price2 = price2.replace(/\$/g, '');
                    price2 = price2.split('.').join("");
                    document.querySelector('#txtMonthlySales').value = price2;

                    var vrequests = new vRequests();
                    vrequests.tableLogic().done(res => {
                    javascript: location.reload();
                    });
                }
            });
        }
    });

    //ON DOCUMENT READY
}

$(document).ready(function () {

    var vrequests = new vRequests();
    KTFormControls.init(vrequests.getFormValidationRules());
    vrequests.RetrieveAll();
    $('#txtNumberMonths')[0].min = 1;

});