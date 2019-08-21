function vRoomUpdate() {

    this.service = 'room'
    this.ctrlActions = new ControlActions()
    this.formId = '#updateRoom'
    this.formName = 'updateRoom'
    this.currentModel = {}
    this.localStorageHotel_Selected = 'Hotel_selected'
    this.localStorageRoom_Selected = 'Room_selected'
    this.RoomTypeSelect = {}
    this.RoomTypeListOptions = []
    this.roomTypeService = 'RoomType'
    this.selectRoomTypeId = '#inputRoomType'

    this.Update = function () {

        var hotel = JSON.parse(localStorage.getItem(this.localStorageHotel_Selected));
        var room = JSON.parse(localStorage.getItem(this.localStorageRoom_Selected));
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm(this.formName);
        var RoomType = this.RoomTypeListOptions[this.RoomTypeListOptions.selectedIndex].value
        var newRoom = {
            Id: room.Id,
            RoomType,
            RoomNumber: customerData.RoomNumber,
            Description: customerData.Description,
            State: "Enabled",
            IdHotel: hotel.Id,
            Value: customerData.Value
        }

        var methodPut = this.ctrlActions.GetMethodPutToAPI(this.service, newRoom);

        methodPut.done(res => {
            javascript: location.href = '/dashboard/rooms'
        })

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

    this.Cancel = function () {
        javascript: location.href = '/dashboard/rooms';
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
    var vroom = new vRoomUpdate();
    vroom.GetAllRoomTypes().done(res => {
        var typeRoomDropdown = document.querySelector(vroom.selectRoomTypeId)
        vroom.fillDropdown(typeRoomDropdown, res.Data ? res.Data : [])
        vroom.currentModel = JSON.parse(localStorage.getItem('Room_selected'));
        vroom.ctrlActions.BindFields(vroom.formName, vroom.currentModel);
        var optionSelected = document.querySelector('#txtTipoHab').value;
        $('[name=wut]').val(optionSelected);
        KTFormControls.init(vroom.getFormValidationRules())
        let sectionImages = document.querySelector('#imageConatiner');
        if (document.querySelector('#txtImage').value != undefined) {
            let imagenNueva = document.createElement('img');
            let value = document.querySelector('#txtImage').value;
            sectionImages.appendChild(imagenNueva);
            imagenNueva.setAttribute('id', value);
            imagenUrl = "https://res.cloudinary.com/qubitscenfo/image/upload/" + value;
            document.querySelector("#" + value).src = imagenUrl;
            console.log(imagenUrl);
        }
    })
});