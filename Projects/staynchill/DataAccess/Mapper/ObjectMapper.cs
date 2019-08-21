using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper {
    public abstract class ObjectMapper : IObjectMapper {
        public abstract List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows);
        public abstract BaseEntity BuildObject(Dictionary<string, object> row);
        
        protected string GetStringValue(Dictionary<string, object> dic, string attName) {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is string)
                return (string)val;

            return "";
        }

        protected int GetIntValue(Dictionary<string, object> dic, string attName) {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is int)
                return (int)dic[attName];

            return -1;
        }
        protected decimal GetDecimalValue(Dictionary<string, object> dic, string attName) {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is decimal)
                return (decimal)dic[attName];

            return -1;
        }
        protected double GetDoubleValue(Dictionary<string, object> dic, string attName) {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is double)
                return (double)dic[attName];

            return -1;
        }

        protected DateTime GetDateValue(Dictionary<string, object> dic, string attName) {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is DateTime)
                return (DateTime)dic[attName];

            return DateTime.Now;
        }
    }
}