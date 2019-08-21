using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class PlatformStatsObjectMapper : ObjectMapper
    {
        private const string DB_COL_TOTAL = "TOTAL";

        public override BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var platformStats = new PlatformStats
            {
                Total = GetDecimalValue(row, DB_COL_TOTAL)
            };
            return platformStats;
        }

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var product = BuildObject(row);
                lstResults.Add(item: product);
            }

            return lstResults;
        }
    }
}
