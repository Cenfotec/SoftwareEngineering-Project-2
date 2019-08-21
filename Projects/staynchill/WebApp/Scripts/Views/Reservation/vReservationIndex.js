function vReservationIndex() {

    this.service = 'reservation';
    this.ctrlActions = new ControlActions();

    this.LoadReservationData = function () {
        let reservationData = JSON.parse(localStorage.getItem('_reservationSearchData'));
        let searchData = JSON.parse(localStorage.getItem('_searchHotel'));
        console.log(reservationData);
        let reservationDays = this.CalcReservationDays(new Date(searchData.inicio), new Date(searchData.fin)).Days;

        $('#hotelName')[0].innerText = reservationData.Hotel.Name;
        $('#roomTypeName')[0].innerText = reservationData.AvailableRoom.Nombre;
        $('#roomNumber')[0].innerText = '#' + reservationData.AvailableRoom.RoomNumber;
        $('#startDate')[0].innerText = this.FormatDate(searchData.inicio, 'es');
        $('#endDate')[0].innerText = this.FormatDate(searchData.fin, 'es');
        $('#totalPayment')[0].innerText = 'USD ' + (reservationDays * reservationData.AvailableRoom.Precio).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        $('#cantNoches')[0].innerText = reservationDays;
    }

    this.CalcReservationDays = function (date1, date2) {
        //Get 1 day in milliseconds
        var one_day = 1000 * 60 * 60 * 24;

        // Convert both dates to milliseconds
        var date1_ms = date1.getTime();
        var date2_ms = date2.getTime();

        // Calculate the difference in milliseconds
        var difference_ms = date2_ms - date1_ms;
        //take out milliseconds
        difference_ms = difference_ms / 1000;
        var seconds = Math.floor(difference_ms % 60);
        difference_ms = difference_ms / 60;
        var minutes = Math.floor(difference_ms % 60);
        difference_ms = difference_ms / 60;
        var hours = Math.floor(difference_ms % 24);
        var days = Math.floor(difference_ms / 24);

        return {
            Days: days,
            Hours: hours,
            Minutes: minutes,
            Seconds: seconds
        };
    }

    this.FormatDate = function (date, lang) {
        // e.g. 07 0ct, 18
        let formattedDate = date.split('/');
        let m_es = ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];
        let m_en = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
         
        let day = formattedDate[1];
        let month = formattedDate[0];
        let year = formattedDate[2];
        let monthFormatted = (lang == 'es') ? m_es[(parseInt(month) - 1)] : (lang == 'en') ? m_es[(parseInt(month) + 1)] : '';
        
        formattedDate = day + ' ' + monthFormatted.substring(0, 3) + ', ' + year.substring(2, 4);

        return formattedDate;
    }
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vReservation = new vReservationIndex();
    vReservation.LoadReservationData();
});