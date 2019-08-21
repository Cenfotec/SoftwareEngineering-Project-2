//efixhraper@gmail.com
function vRoomTypeUpdate() {

    this.service = 'roomType'
    this.ctrlActions = new ControlActions()
    this.formId = '#updateRoomType'
    this.formName = 'updateRoomType'
    this.currentModel = {}

    $("input[data-type='currency']").on({
        keyup: function () {
            formatCurrency($(this));
        },
        blur: function () {
            formatCurrency($(this), "blur");
        }
    });


    function formatNumber(n) {
        // format number 1000000 to 1,234,567
        return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }

    // Jquery Dependency

    $("input[data-type='currency']").on({
        keyup: function () {
            formatCurrency($(this));
        },
        blur: function () {
            formatCurrency($(this), "blur");
        }
    });

    function formatNumber(n) {
        // format number 1000000 to 1,234,567
        return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }


    function formatCurrency(input, blur) {
        // appends $ to value, validates decimal side
        // and puts cursor back in right position.

        // get input value
        var input_val = input.val();

        // don't validate empty input
        if (input_val === "") { return; }

        // original length
        var original_len = input_val.length;

        // initial caret position 
        var caret_pos = input.prop("selectionStart");

        // check for decimal
        if (input_val.indexOf(".") >= 0) {

            // get position of first decimal
            // this prevents multiple decimals from
            // being entered
            var decimal_pos = input_val.indexOf(".");

            // split number by decimal point
            var left_side = input_val.substring(0, decimal_pos);
            var right_side = input_val.substring(decimal_pos);

            // add commas to left side of number
            left_side = formatNumber(left_side);

            // validate right side
            right_side = formatNumber(right_side);

            // Limit decimal to only 2 digits
            right_side = right_side.substring(0, 2);

            // join number by .
            input_val = left_side + "." + right_side;

        } else {
            // no decimal entered
            // add commas to number
            // remove all non-digits
            input_val = formatNumber(input_val);
        }

        // send updated string to input
        input.val(input_val);

        // put caret back in the right position
        var updated_len = input_val.length;
        caret_pos = updated_len - original_len + caret_pos;
        input[0].setSelectionRange(caret_pos, caret_pos);
    }

    this.BindFormattedPrice = function() {
        formattedPrice = document.querySelector('#txtPrice').value;
        document.querySelector('#txtPrice').value = Number(formattedPrice.replace(/[^0-9.-]+/g, ""));
        formatCurrency($('#txtPrice'));
    }

    this.Update = function () {
        if (document.querySelector('#cbPetsAllowed').checked == true) {
            document.querySelector('#txtPetsAllowed').value = 'Permitir';
        } else {
            document.querySelector('#txtPetsAllowed').value = 'Prohibir';
        }
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm(this.formName);
        let tipoHabPrice = customerData.Price;
        var price = tipoHabPrice.replace(/,/g, '.');
        if (price > 9.99 || price == 1.000) {
            price = price.split('.').join("");
        }
        customerData.Price = price;
        var methodPut = this.ctrlActions.GetMethodPutToAPI(this.service, customerData);

        methodPut.done(res => {
            javascript: location.href = '/dashboard/roomtypes'
        })

    }

    this.Cancel = function () {
        javascript: location.href = '/dashboard/roomtypes';
    }

    this.getFormValidationRules = function () {
        var rules = {
            Name: {
                required: true

            },
            Description: {
                required: true
            },
            AmountPeople: {
                required: true,
                number: true,
                min: 1
            },
            AmountBeds: {
                required: true,
                number: true,
                min: 1
            },
            Price: {
                required: true

            },
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

$(document).ready(function () {

    var vroomType = new vRoomTypeUpdate();
    vroomType.currentModel = JSON.parse(localStorage.getItem('Room_type_selected'));
    vroomType.ctrlActions.BindFields(vroomType.formName, vroomType.currentModel);
    var checkBoxInfo = document.querySelector('#txtPetsAllowed').value;
    if (checkBoxInfo == 'Permitir') {
        document.querySelector('#cbPetsAllowed').checked = true;
    } else {
        document.querySelector('#cbPetsDenied').checked = true;
    }
    vroomType.BindFormattedPrice();
    KTFormControls.init(vroomType.getFormValidationRules());
});