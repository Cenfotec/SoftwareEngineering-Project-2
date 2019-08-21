using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class HotelAnualAverageIncome : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }

        [DbColumn("AVG_TOTAL")]
        public int AvgTotal { get; set; }
    }
    //HotelAnualTotalIncome
    public class HotelAnualTotalIncome : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }

        [DbColumn("SUM_PRECIO_BASE")]
        public int SumBasePrice { get; set; }
    }

    public class HotelTotalReservations : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }

        [DbColumn("TOTAL_RESERVACIONES")]
        public int TotalReservations { get; set; }
    }

    public class HotelTotalReservationsByMonth : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }

        [DbColumn("CANT_VENTAS")]
        public int CantSales { get; set; }

        [DbColumn("MONTH_SALE")]
        public int MonthSale { get; set; }
    }

    public class HotelTotalIncomeByMonth : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("FK_HOTEL")]
        public int FkHotel { get; set; }

        [DbColumn("SUM_GANANCIA_TOTAL")]
        public int SumTotalIncome { get; set; }

        [DbColumn("MONTH_SALE")]
        public int MonthSale { get; set; }
    }
}
