function PlatformDasboard() {
    this.service = 'platformstats';
    this.ctrlActions = new ControlActions();
    this.currenModel = {};

    this.InitDashboard = function () {
        this.HtmlChanges();
        this.orderStatistics();
        this.activitiesChart();
        this.RetrieveTotalEarnings();
        this.RetrieveHotels();
        this.RetrieveMembreships();
        this.RetrieveUsers();
        this.RetrieveCommissionEarning();
        this.RetrieveMembreshipsEarnings();
        this.RetrieveAmountSalesPerDay();
        this.RetrievePromEarningsCommission();
        this.RetrievePromEarningsMembreship();
    }

    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2
    })

    const monthNames = ["Ene", "Feb", "Mar", "Abr", "May", "Jun",
        "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"
    ];

    this.HtmlChanges = function () {
        var now = moment().format('LLLL');
        document.querySelector('#txtCurrentDate').textContent = now;
    }

    this.RetrieveAmountSalesPerDay = function () {
        return Promise.resolve(this.ctrlActions.GetMethodGetToApi('incomestats/' + 'getcantventasbyday'));
    }

    // Order Statistics.
    // Based on Chartjs plugin - http://www.chartjs.org/
    this.orderStatistics = function () {

        var dashboard = new PlatformDasboard();

        dashboard.RetrieveAmountSalesPerDay().then(res => {

            var totalCantProductos = 0
            var days = [];
            const d = new Date();
            var month = monthNames[d.getMonth()];
            for (let prop in res.Data) {
                days.push(res.Data[prop].DayOfMonth + ' '+month);
                parseInt(totalCantProductos += res.Data[prop].CantVentas);
            }
            console.log(days)

            var cantVentas = [];
            for (let prop in res.Data) {
                var perc = (parseInt(res.Data[prop].CantVentas) / parseInt(totalCantProductos)) * 100;
                cantVentas.push(perc.toFixed(0));
            }

            document.querySelector('#totalTransactions').innerHTML = totalCantProductos + ' Transacciones realizadas en el sistema';

            var container = KTUtil.getByID('kt_chart_order_statistics');
            if (!container) {
                return;
            }

            var MONTHS = ['1 Jan', '2 Jan', '3 Jan', '4 Jan', '5 Jan', '6 Jan', '7 Jan'];

            var color = Chart.helpers.color;
            var barChartData = {
                labels: days,
                datasets: [
                    {
                        fill: true,
                        //borderWidth: 0,
                        backgroundColor: color(KTApp.getStateColor('brand')).alpha(0.6).rgbString(),
                        borderColor: color(KTApp.getStateColor('brand')).alpha(0).rgbString(),

                        pointHoverRadius: 4,
                        pointHoverBorderWidth: 12,
                        pointBackgroundColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointBorderColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                        pointHoverBackgroundColor: KTApp.getStateColor('brand'),
                        pointHoverBorderColor: Chart.helpers.color('#000000').alpha(0.1).rgbString(),

                        data: cantVentas
                    }
                ]
            };

            var ctx = container.getContext('2d');
            var chart = new Chart(ctx, {
                type: 'line',
                data: barChartData,
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    legend: false,
                    scales: {
                        xAxes: [{
                            categoryPercentage: 0.35,
                            barPercentage: 0.70,
                            display: true,
                            scaleLabel: {
                                display: false,
                                labelString: 'Month'
                            },
                            gridLines: false,
                            ticks: {
                                display: true,
                                beginAtZero: true,
                                fontColor: KTApp.getBaseColor('shape', 3),
                                fontSize: 13,
                                padding: 10
                            }
                        }],
                        yAxes: [{
                            categoryPercentage: 0.35,
                            barPercentage: 0.70,
                            display: true,
                            scaleLabel: {
                                display: false,
                                labelString: 'Value'
                            },
                            gridLines: {
                                color: KTApp.getBaseColor('shape', 2),
                                drawBorder: false,
                                offsetGridLines: false,
                                drawTicks: false,
                                borderDash: [3, 4],
                                zeroLineWidth: 1,
                                zeroLineColor: KTApp.getBaseColor('shape', 2),
                                zeroLineBorderDash: [3, 4]
                            },
                            ticks: {
                                max: 70,
                                stepSize: 10,
                                display: true,
                                beginAtZero: true,
                                fontColor: KTApp.getBaseColor('shape', 3),
                                fontSize: 13,
                                padding: 10
                            }
                        }]
                    },
                    title: {
                        display: false
                    },
                    hover: {
                        mode: 'index'
                    },
                    tooltips: {
                        enabled: true,
                        intersect: false,
                        mode: 'nearest',
                        bodySpacing: 5,
                        yPadding: 10,
                        xPadding: 10,
                        caretPadding: 0,
                        displayColors: false,
                        backgroundColor: KTApp.getStateColor('brand'),
                        titleFontColor: '#ffffff',
                        cornerRadius: 4,
                        footerSpacing: 0,
                        titleSpacing: 0
                    },
                    layout: {
                        padding: {
                            left: 0,
                            right: 0,
                            top: 5,
                            bottom: 5
                        }
                    }
                }
            });
        })
    }

    // Activities Charts.
    // Based on Chartjs plugin - http://www.chartjs.org/
    this.activitiesChart = function () {
        if ($('#kt_chart_activities').length == 0) {
            return;
        }

        var dashboard = new PlatformDasboard();

        dashboard.RetrieveAmountSalesPerDay().then(res => {

            var totalCantProductos = 0
            var days = [];
            const d = new Date();
            var month = monthNames[d.getMonth()];
            for (let prop in res.Data) {
                days.push(res.Data[prop].DayOfMonth + ' ' + month);;
            }
            console.log(days)

            var cantVentas = [];
            for (let prop in res.Data) {
                cantVentas.push(res.Data[prop].CantVentas);
            }
            console.log(cantVentas)

        var ctx = document.getElementById("kt_chart_activities").getContext("2d");

        var gradient = ctx.createLinearGradient(0, 0, 0, 240);
        gradient.addColorStop(0, Chart.helpers.color('#e14c86').alpha(1).rgbString());
        gradient.addColorStop(1, Chart.helpers.color('#e14c86').alpha(0.3).rgbString());

        var config = {
            type: 'line',
            data: {
                labels: days,
                datasets: [{
                    label: "Ventas",
                    backgroundColor: Chart.helpers.color('#e14c86').alpha(1).rgbString(),  //gradient
                    borderColor: '#e13a58',

                    pointBackgroundColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                    pointBorderColor: Chart.helpers.color('#000000').alpha(0).rgbString(),
                    pointHoverBackgroundColor: KTApp.getStateColor('light'),
                    pointHoverBorderColor: Chart.helpers.color('#ffffff').alpha(0.1).rgbString(),

                    //fill: 'start',
                    data: cantVentas
                }]
            },
            options: {
                title: {
                    display: false,
                },
                tooltips: {
                    mode: 'nearest',
                    intersect: false,
                    position: 'nearest',
                    xPadding: 10,
                    yPadding: 10,
                    caretPadding: 10
                },
                legend: {
                    display: false
                },
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    xAxes: [{
                        display: false,
                        gridLines: false,
                        scaleLabel: {
                            display: true,
                            labelString: 'Month'
                        }
                    }],
                    yAxes: [{
                        display: false,
                        gridLines: false,
                        scaleLabel: {
                            display: true,
                            labelString: 'Value'
                        },
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                },
                elements: {
                    line: {
                        tension: 0.0000001
                    },
                    point: {
                        radius: 4,
                        borderWidth: 12
                    }
                },
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 10,
                        bottom: 0
                    }
                }
            }
        };

            var chart = new Chart(ctx, config);
        })
    }


    this.RetrieveTotalEarnings = function () {
        var methodGet = this.ctrlActions.GetMethodGetToApi(this.service + '/gettotalplatform');
        methodGet.done(res => {
            document.querySelector('#txtTotalEarnings').textContent = formatter.format(res.Data.Total);
        })
    }

    this.RetrieveHotels = function () {
        var methodGet = this.ctrlActions.GetMethodGetToApi(this.service + '/gethotels');
        methodGet.done(res => {
            document.querySelector('#txtTotalHotels').textContent = res.Data.Total + ' Hoteles registrados';
        })
    }

    this.RetrieveMembreships = function () {
        var methodGet = this.ctrlActions.GetMethodGetToApi(this.service + '/gettotalplatformemberships');
        methodGet.done(res => {
            document.querySelector('#txtTotalMembreships').textContent = res.Data.Total + ' Membresias de hotel';
            console.log(res.Data.Total+' a')
        })
    }

    this.RetrieveUsers = function () {
        var methodGet = this.ctrlActions.GetMethodGetToApi(this.service + '/getusers');
        methodGet.done(res => {
            document.querySelector('#txtTotalUsers').textContent = res.Data.Total + ' Usuarios en el sistema';
        })
    }

    this.RetrieveCommissionEarning = function () {
        var methodGet = this.ctrlActions.GetMethodGetToApi(this.service + '/gettotalplatformcommission');
        methodGet.done(res => {
            document.querySelector('#txtAverageCommissionEarnings').textContent = formatter.format(res.Data.Total);
        })
    }

    this.RetrieveMembreshipsEarnings = function () {
        var methodGet = this.ctrlActions.GetMethodGetToApi(this.service + '/gettotalganaplatformmembeship');
        methodGet.done(res => {
            document.querySelector('#txtAverageMembreshipsEarnings').textContent = formatter.format(res.Data.Total);
            console.log(res.Data.Total + ' b')
        })
    
    }

    this.RetrievePromEarningsCommission = function () {
        var methodGet = this.ctrlActions.GetMethodGetToApi(this.service + '/getplatformcommission');
        methodGet.done(res => {
            document.querySelector('#spanCommission').textContent = formatter.format(res.Data.Total);
        })
    }

    this.RetrievePromEarningsMembreship = function () {
        var methodGet = this.ctrlActions.GetMethodGetToApi(this.service + '/getplatformmembership');
        methodGet.done(res => {
            document.querySelector('#spanMembership').innerHTML = formatter.format(res.Data.Total);
            console.log(res.Data.Total + ' c')
        })
    }

}


jQuery(function () {
    if (JSON.parse(localStorage.getItem('_userLogged')).Rol == 'Administrador de plataforma') {
        //dom ready codes
        var dashboard = new PlatformDasboard();
        dashboard.InitDashboard();
    }
});