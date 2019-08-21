using DataAccess.Crud;
using Entities_POJO;
using System.Collections.Generic;


namespace CoreAPI
{
    public class IncomeStatsManagement
    {
        private CantVentasByDayStatsCrud BaseCrud;

        public IncomeStatsManagement() => BaseCrud = new CantVentasByDayStatsCrud();

        public List<CantVentasByDayStats> RetrieveCantVentasByDayStats() {
            return BaseCrud.RetrieveCantVentasByDayStats();
        }
    }
}
