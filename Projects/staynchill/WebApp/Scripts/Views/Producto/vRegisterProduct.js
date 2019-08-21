﻿function vRegisterProduct() {
    this.service = 'producto'
    this.ctrlActions = new ControlActions()
    this.formId = '#registerProducto'
    this.formName = 'registerProducto'

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

    this.Create = function () {
        var data = JSON.parse(localStorage.getItem('Service_selected'));
        document.querySelector('#txtService').value = data.Id;
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('registerProducto');
        let productPrice = customerData.Price;
        var price = productPrice.replace(/,/g, '.');
        if (price > 9.99 || price == 1.000) {
            price = price.split('.').join("");
        }
        customerData.Price = price;

        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, customerData);

        methodPost.done(res => {
            javascript: location.href = '/dashboard/service/'
        })

        methodPost.fail(res => {
            alert('La cédula jurídica ya existe');
        })
    }

    this.Cancel = function () {
        javascript: location.href = '/dashboard/service';
    }

    this.getFormValidationRules = function () {
        var rules = {
            Name: {
                required: true
            },
            Description: {
                required: true
            },
            Price: {
                required: true
            },
            Cant: {
                required: true,
                number: true,
                min: 1
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
    var vproduct = new vRegisterProduct();
    KTFormControls.init(vproduct.getFormValidationRules());
});