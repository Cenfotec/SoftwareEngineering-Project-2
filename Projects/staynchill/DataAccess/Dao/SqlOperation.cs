using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DataAccess.Dao
{
    public class SqlOperation
    {

        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }
        public void AddParam(string paramName, string paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.VarChar)
            {
                Value = paramValue
            };
            Parameters.Add(param);

        }
        public void AddVarcharParam(string paramName, string paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.VarChar)
            {
                Value = paramValue
            };
            Parameters.Add(param);

        }

        public void AddIntParam(string paramName, int paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Int)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddDoubleParam(string paramName, double paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Decimal)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddDateParam(string paramName, DateTime paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Date)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }
        public void AddDecimalParam(string paramName, decimal paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Decimal)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }
        public void AddParamsGeneric(string paramName, string paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.VarChar)
            {
                Value = paramValue
            };
            Parameters.Add(param);

        }
    }
    public class SqlOperationGeneric {

        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SqlOperationGeneric() {
            Parameters = new List<SqlParameter>();
        }

        public void AddOnlyIdParam<TEntity>(TEntity tmodelObj) where TEntity : class {
            
            List<PropertyInfo> properties = MapperCache.GetPropertyInfo(tmodelObj);

            var property = properties.FirstOrDefault( 
                p => p.GetCustomAttributes(false).Any( 
                    a => a.GetType() == typeof(PrimaryKeyAttribute)
                )
            );

            if (property != null) {

                AddParam(property, tmodelObj);
            }
        }

        private void AddParam<TEntity>(PropertyInfo property, TEntity tmodelObj) where TEntity : class
        {
            var paramName = "@P_" + GetDBColumnFromProperty(property);
            var sqlType = ClrTypeToSqlDbTypeMapper.GetSqlDbTypeFromClrType(property.PropertyType);

            var param = new SqlParameter(paramName, sqlType)
            {

                Value = property.GetValue(tmodelObj).ToString()

            };

            Parameters.Add(param);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="tmodelObj"></param>
        public void AddParams<TEntity>(TEntity tmodelObj) where TEntity : class {

            List<PropertyInfo> properties = MapperCache.GetPropertyInfo(tmodelObj);

            foreach (PropertyInfo property in properties)
                AddParam(property, tmodelObj);
          
        }
        /// <summary>
        /// standard of naming convention for columns in the database. 
        /// example:
        /// class attribute: ArrivalDate
        /// database column name: ARRIVAL_DATE
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private string GetDBColumnFromProperty(PropertyInfo property)
        {
            var normalizedDBColumnName = "";
            var attributes = property.GetCustomAttributes(false);

            var columnMapping = attributes
                .FirstOrDefault(
                    a => a.GetType() == typeof(DbColumnAttribute)
                );

            if (columnMapping != null) {

                var mapsTo = columnMapping as DbColumnAttribute;
                normalizedDBColumnName = mapsTo.Name;          
                
            } else {

                var propertyName = property.Name;
                normalizedDBColumnName = string.Concat(
                    propertyName.Select(
                        c => (
                        char.IsUpper(c) &&
                        propertyName.LastIndexOf(c) != 0
                        ) ? "_" + c.ToString() : c.ToString().ToUpper()
                    )
                ).TrimStart();

            }

            return normalizedDBColumnName;
        }
    }
}
