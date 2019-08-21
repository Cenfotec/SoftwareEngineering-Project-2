using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Entities_POJO;
using System.Data;

namespace DataAccess.Dao
{
    public static class MapperCache
    {
        private static Dictionary<string, PropertyInfo[]> _propertyInfoCache = new Dictionary<string, PropertyInfo[]>();

        public static List<PropertyInfo> GetPropertyInfo<TEntity>(TEntity tmodelObj) where TEntity : class
        {
            var type = tmodelObj.GetType();

            if (!_propertyInfoCache.ContainsKey(type.FullName))
            {
                _propertyInfoCache.Add(type.FullName, type.GetProperties());
            }

            return new List<PropertyInfo>(_propertyInfoCache[type.FullName]);
        }
    }
}
