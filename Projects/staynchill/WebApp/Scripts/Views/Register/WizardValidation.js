"use strict";

// Class definition
var KTWizard2 = function () {
    // Base elements
    var wizardEl;
    var formEl;
    var validator;
    var wizard;
    var oneEntry = false;
    var service = 'user';

    // Private functions
    var initWizard = function () {
        // Initialize form wizard
        wizard = new KTWizard('kt_wizard_v2', {
            startStep: 1,
        });

        // Validation before going to next page
        wizard.on('beforeNext', function (wizardObj) {
            if (validator.form() !== true) {
                wizardObj.stop();  // don't go to the next step
            }
        });

        wizard.on('beforePrev', function (wizardObj) {
            if (validator.form() !== true) {
                wizardObj.stop();  // don't go to the next step
            }
        });

        // Change event
        wizard.on('change', function (wizard) {
            KTUtil.scrollTop();
        });
    }

    var initValidation = function () {
        validator = formEl.validate({
            // Validate only visible fields
            ignore: ":hidden",

            // Validation rules
            rules: {
                //= Step 1
                Cedula: {
                    required: true
                },
                Nombre: {
                    required: true,
                },
                Apellido: {
                    required: true
                },
                SegApellido: {
                    required: true
                },
                Correo: {
                    required: true,
                    email: true
                },
                Telefono: {
                    required: true
                },
                Codigo: {
                    required: true
                },
                vProvincia: {
                    required: true,
                    select_custom: true
                },
                vCanton: {
                    required: true,
                    select_custom: true
                },
                vDistrito: {
                    required: true,
                    select_custom: true
                },
                Direccion: {
                    required: true
                },
                Contrasenna: {
                    required: true
                },
                CContrasenna: {
                    equalTo: '#txtContrasenna'
                }
            },

            // Display error  
            invalidHandler: function (event, validator) {
                KTUtil.scrollTop();
            },

            // Submit valid form
            submitHandler: function (form) {
                
            }
        });
    }

    var initSubmit = function () {
        var btn = formEl.find('[data-ktwizard-type="action-submit"]');

        btn.on('click', function (e) {
            e.preventDefault();

            if (validator.form()) {
                // See: src\js\framework\base\app.js
                KTApp.progress(btn);
                //KTApp.block(formEl);

                // See: http://malsup.com/jquery/form/#ajaxSubmit
                formEl.ajaxSubmit({
                    success: function () {
                        KTApp.unprogress(btn);
                        //KTApp.unblock(formEl);

                         // Once time registry entry
                        if (!oneEntry) {  
                            oneEntry = true;

                            //var rol = "Administrador de hotel";
                            //var estado = "Habilitado";
                            //var keyImg = getKeyImg();
                            //var data = {};
                            //$('#' + 'kt_form' + ' *').filter(':input').each(function (input) {
                            //    var columnDataName = $(this).attr("ColumnDataName");
                            //    if (columnDataName != "CContrasenna") {
                            //        data[columnDataName] = this.value;
                            //    }
                            //});
                            //data.Rol = rol;
                            //data.Estado = estado;
                            //data.Imagen = keyImg
                            //// Change code to Hotel ID
                            //data.Codigo = JSON.parse(localStorage.getItem('Hotel_selected')).Id;
                            //console.log(data);
                            ////    //Hace el post al create
                            //var method = new ControlActions().GetMethodPostToAPI(service, data);
                            //method.done(res => {
                            //    console.log(res.Data);
                            //    if (res.Data == true) {
                            //        console.log("Registro exitoso");
                            //    } else {
                            //        console.log("Codigo incorrecto");
                            //    }
                            //})


                        }
                        
                    }
                });
            }
        });
    }

    var getKeyImg = function() {
        let imagenUrl = document.querySelector("#image_preview").src;
        let urlArray = imagenUrl.split('/');
        imagenUrl = urlArray[6];
        return imagenUrl;
    }

    return {
        // public functions
        init: function () {
            wizardEl = KTUtil.get('kt_wizard_v2');
            formEl = $('#kt_form');

            initWizard();
            initValidation();
            initSubmit();
        }
    };
}();

jQuery(document).ready(function () {
    KTWizard2.init();
});