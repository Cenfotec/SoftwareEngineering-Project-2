using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper {
    internal interface ISqlStaments {
        SqlOperation GetCreateStatement(BaseEntity entity);
        SqlOperation GetRCreateStatement(BaseEntity entity);
        SqlOperation GetRetriveStatement(BaseEntity entity);
        SqlOperation GetRetriveAllStatement();
        SqlOperation GetRetriveAllByNameStatement(BaseEntity entity);
        SqlOperation GetUpdateStatement(BaseEntity entity);
        SqlOperation GetDeleteStatement(BaseEntity entity);
    }
}