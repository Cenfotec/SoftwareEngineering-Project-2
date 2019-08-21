// Class definition

var KTFormControls = function () {
    // Private functions
    var invalidHandler = function (formId) {
        var invalidFuncHandler = function (event, validator) {
            var alert = $(formId);
            alert.removeClass('kt--hide').show();
            KTUtil.scrollTop();
        }
        return invalidFuncHandler;
    }

    var submitHandler = function(callback) {
        var funcHandler = function (form) {
            callback()
        }
        return funcHandler;
    }

    var formToValidate = function (formData) {
        return {
            rules: formData.rules,
            submitHandler: submitHandler(formData.onSubmitCallback),
            invalidHandler: invalidHandler(formData.formId)
        }
    }
    

    var form = function (formData) {
        $(formData.formId).validate(formToValidate(formData));
    }

    return {
        // public functions
        init: function (formData) {
            form(formData);
        }
    };
}();

jQuery(document).ready(function () {
    
});