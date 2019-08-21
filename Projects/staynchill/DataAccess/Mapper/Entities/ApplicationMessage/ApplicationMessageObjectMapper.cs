using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ApplicationMessageObjectMapper : ObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_MESSAGE = "TEXT";

        public override BaseEntity BuildObject(Dictionary<string, object> row) => new ApplicationMessage
        {
            Id = GetIntValue(row, DB_COL_ID),
            Message = GetStringValue(row, DB_COL_MESSAGE)
        };

        public override List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var applicationMessage = BuildObject(row);
                lstResults.Add(item: applicationMessage);
            }

            return lstResults;
        }
    }
}