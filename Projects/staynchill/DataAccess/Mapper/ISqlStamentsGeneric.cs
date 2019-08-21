using DataAccess.Dao;

namespace DataAccess.Mapper {
    internal interface ISqlStamentsGeneric  {
        SqlOperationGeneric GetCreateStatement<TEntity>(TEntity entity) where TEntity : class;
        SqlOperationGeneric GetRetriveStatement<TEntity>(TEntity entity) where TEntity : class;
        SqlOperationGeneric GetRetriveAllStatement();
        SqlOperationGeneric GetUpdateStatement<TEntity>(TEntity entity) where TEntity : class;
        SqlOperationGeneric GetDeleteStatement<TEntity>(TEntity entity) where TEntity : class;
    }
}