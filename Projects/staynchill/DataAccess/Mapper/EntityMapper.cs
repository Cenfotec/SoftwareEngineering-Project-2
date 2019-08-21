using System;
using DataAccess.Dao;

namespace DataAccess.Mapper
{
    public class EntityMapperGeneric : ISqlStamentsGeneric
    {
        /// <summary>
        /// Defines the base name to be part of every procedure name.
        /// DB_PR_BASE_NAME = "PRODUCT"
        /// example: "CRE_{DB_PR_BASE_NAME}_PR" 
        /// equals to: "CRE_PRODUCT_PR"
        /// </summary>
        public string DB_PR_BASE_NAME { get; set; }
        public EntityMapperGeneric(string dB_PR_BASE_NAME) => this.DB_PR_BASE_NAME = dB_PR_BASE_NAME;
        

        public SqlOperationGeneric GetCreateStatement<TEntity>(TEntity entity) where TEntity : class {
            var operation = new SqlOperationGeneric
            {
                ProcedureName = $"CRE_{DB_PR_BASE_NAME}_PR"
            };
            operation.AddParams(entity);
            return operation;
        }

        public SqlOperationGeneric GetRetriveStatement<TEntity>(TEntity entity) where TEntity : class {
            var operation = new SqlOperationGeneric { ProcedureName = $"RET_{DB_PR_BASE_NAME}_PR" };
            operation.AddOnlyIdParam(entity);
            return operation;
        }

        public SqlOperationGeneric GetRetriveAllStatement() {
            var operation = new SqlOperationGeneric { ProcedureName = $"RET_ALL_{DB_PR_BASE_NAME}_PR" };
            return operation;
        }

        public SqlOperationGeneric GetUpdateStatement<TEntity>(TEntity entity) where TEntity : class {
            var operation = new SqlOperationGeneric { ProcedureName = $"UPD_{DB_PR_BASE_NAME}_PR" };
            operation.AddParams(entity);
            return operation;
        }

        public SqlOperationGeneric GetDeleteStatement<TEntity>(TEntity entity) where TEntity : class {
            var operation = new SqlOperationGeneric { ProcedureName = $"DEL_{DB_PR_BASE_NAME}_PR" };
            operation.AddOnlyIdParam(entity);
            return operation;
        }
    }
}