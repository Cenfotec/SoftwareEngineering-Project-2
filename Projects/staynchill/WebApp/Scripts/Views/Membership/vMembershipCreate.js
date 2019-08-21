//function padDate(dt, formatter) {
//    var useDt = dt || new Date(),
//        d = useDt.getDate(),
//        m = useDt.getMonth() + 1,
//        y = useDt.getFullYear(),
//        h = useDt.getHours(),
//        n = useDt.getMinutes(),
//        s = useDt.getSeconds(),
//        z = useDt.getMilliseconds(),
//        f = formatter || function (fyr, fmo, fdy, fhr, fmn, fse, fms) {
//            return fyr + '/' + fmo + '/' + fdy;
//        },
//        r = f('' + y, (m < 10 && '0' || '') + m, (d < 10 && '0' || '') + d, (h < 10 && '0' || '') + h, (n < 10 && '0' || '') + n, (s < 10 && '0' || '') + s, (z < 10 && '000' || z < 100 && '00' || z < 1000 && '0') + z);
//    return r;
//}

function vMembershipCreate() {

    this.service = 'membership'
    this.ctrlActions = new ControlActions()
    this.formId = '#CreateMembership'
    this.formName = 'CreateMembership'

    this.Create = function () {
        console.log(this)
        var formData = {};
        formData = this.ctrlActions.GetDataForm('CreateMembership');
        //Hace el post al create
        formData.FkHotel = 7
        formData.State = "enabled"
        formData.StartDate = padDate()
        formData.EndDate = padDate(new Date(2021, -1, 31))

        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, formData);
        return methodPost

    }

    this.getFormValidationRules = function() {
        var rules = {
            Price: {
                required: true,
                number: true
            },
            NumberMonths: {
                required: true,
                number: true,
                range: [1, 12]
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

    var vMembership = new vMembershipCreate();

});

