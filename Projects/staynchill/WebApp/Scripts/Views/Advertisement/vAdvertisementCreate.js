

function vAdvertisementCreate() {

    this.service = 'advertisement'
    this.ctrlActions = new ControlActions()
    this.formId = '#CreateAdvertisement'
    this.formName = 'CreateAdvertisement'

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

    this.Create = function () {

        var formData = {};
        formData = this.ctrlActions.GetDataForm('CreateAdvertisement');
        //Hace el post al create
        formData.FkHotel = 7
        formData.FkRoomType = null
        formData.FkProduct = null
        formData.State = "Active"

        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, formData);

        methodPost.done( res => {
            javascript:location.href='/dashboard'
        })

    }

    this.Cancel = function () {
        javascript: location.href = '/dashboard';
    }

    this.getFormValidationRules = function() {
        var rules = {
            Value: {
                required: true,
                number: true
            },
            Name: {
                required: true
            },
            Description: {
                required: true
            },
            RemainingOffers: {
                required: true,
                number: true
            },
            StartDate: {
                required: true,
                date: true
            },
            EndDate: {
                required: true,
                date: true
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

    var vAdvertisement = new vAdvertisementCreate();
    KTFormControls.init(vAdvertisement.getFormValidationRules());

});

