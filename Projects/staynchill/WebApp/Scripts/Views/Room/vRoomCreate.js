function vRoomCreate() {

    this.service = 'room'
    this.ctrlActions = new ControlActions()
    this.formId = '#registroHabitacion'
    this.formName = 'registroHabitacion'
    this.localStorageHotel_Selected = 'Hotel_selected'
    this.RoomTypeSelect = {}
    this.RoomTypeListOptions = []
    this.roomTypeService = 'RoomType'
    this.selectRoomTypeId = '#inputRoomType'


    this.Create = function () {
        var hotel = JSON.parse(localStorage.getItem(this.localStorageHotel_Selected));
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm(this.formName);
        var RoomType = this.RoomTypeListOptions[this.RoomTypeListOptions.selectedIndex].value
        var newRoom = {
            Id: 1,
            RoomType,
            RoomNumber: customerData.RoomNumber,
            Description: customerData.Description,
            State: "Enabled",
            IdHotel: hotel.Id,
            Value: customerData.Value
        }
        var methodPost = this.ctrlActions.GetMethodPostToAPI(this.service, newRoom);
        methodPost.done(res => {
            javascript: location.href = '/dashboard/rooms/'
        })

        methodPost.fail(res => {
            res = res.responseJSON;

            $.notify({
                // options
                icon: ' glyphicon glyphicon-ok-sign ',
                title: 'Error registro de habitación',
                message: res.ExceptionMessage
            }, {
                    // settings
                    element: 'body',
                    position: null,
                    type: "danger",
                    allow_dismiss: true,
                    newest_on_top: false,
                    showProgressbar: false,
                    placement: {
                        from: "top",
                        align: "right"
                    },
                    offset: 20,
                    spacing: 10,
                    z_index: 1031,
                    delay: 5000,
                    timer: 1000,
                    url_target: '_blank',
                    mouse_over: null,
                    animate: {
                        enter: 'animated fadeInDown',
                        exit: 'animated fadeOutUp'
                    },
                    onShow: null,
                    onShown: null,
                    onClose: null,
                    onClosed: null,
                    icon_type: 'class',
                    template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                        '<button type="button" aria-hidden="true" class="close" data-notify="dismiss"></button>' +
                        '<span data-notify="icon"></span> ' +
                        '<span data-notify="title">{1}</span> ' +
                        '<span data-notify="message">{2}</span>' +
                        '<div class="progress" data-notify="progressbar">' +
                        '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                        '</div>' +
                        '<a href="{3}" target="{4}" data-notify="url"></a>' +
                        '</div>'
                });
        })
    }

    this.Cancel = function () {
        javascript: location.href = '/dashboard/hotel';
    }

    this.fillDropdown = (p_dropdown, roomTypeList) => {
        this.RoomTypeSelect = p_dropdown
        roomTypeList.map(roomType => {
            var opt = document.createElement('option')
            opt.innerHTML = roomType.Name
            opt.value = roomType.Id
            return opt
        }).forEach(option => this.RoomTypeSelect.appendChild(option))
        this.RoomTypeListOptions = this.RoomTypeSelect.options
    }

    this.GetAllRoomTypes = () => {
        var currentHotelId = JSON.parse(localStorage.getItem(this.localStorageHotel_Selected)).Id
        var methodGet = this.ctrlActions.GetMethodGetToApiReturnsJSON(this.roomTypeService + "/getbyhotel/", { Id: currentHotelId });
        return methodGet
    }

    this.getFormValidationRules = function () {
        var rules = {
            RoomType: {
                required: true

            },
            RoomNumber: {
                required: true,
                number: true
            },
            Description: {
                required: true
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
    var vRoom = new vRoomCreate();
    vRoom.GetAllRoomTypes().done(res => {
        var typeRoomDropdown = document.querySelector(vRoom.selectRoomTypeId)
        vRoom.fillDropdown(typeRoomDropdown, res.Data ? res.Data : [])
        console.log(vRoom)
        KTFormControls.init(vRoom.getFormValidationRules())
    })
});