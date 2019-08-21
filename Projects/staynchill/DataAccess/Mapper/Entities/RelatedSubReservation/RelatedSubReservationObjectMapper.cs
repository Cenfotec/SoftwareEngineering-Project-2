using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    class RelatedSubReservationObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";

        public override BaseEntity BuildObject(Dictionary<string, object> row) => new RelatedSubReservation
        {
            ID_SUBRESERVATION = GetIntValue(row, DB_COL_ID)
        };

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var relatedSubReservation = BuildObject(row);
                lstResults.Add(item: relatedSubReservation);
            }

            return lstResults;
        }
    }
}
