using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using DataAccess.Dao;
using DataAccess.Mapper;
using DataAccess.Exceptions;

namespace DataAccess.Crud {
    /// <summary>
    /// Parent class. Generic CRUD operations for child class.
    /// </summary>
    public class CrudFactory {
        protected ObjectMapper EntityObjectMapper { get; set; }
        /// <summary>
        /// EntityMapperGeneric holds all generic basic CRUD operations for class type destination.
        /// </summary>
        protected EntityMapperGeneric EntityMapperGeneric { get; set; }
        
        public CrudFactory(ObjectMapper entityObjectMapper, EntityMapperGeneric entityMapperGeneric) {

            this.EntityObjectMapper = entityObjectMapper ?? throw new ArgumentNullException(nameof(entityObjectMapper));
            this.EntityMapperGeneric = entityMapperGeneric ?? throw new ArgumentNullException(nameof(entityMapperGeneric));

        }
        
        public bool Create(BaseEntity entity) {
            try {
                var instance = SqlDao.GetInstance();
                var operation = EntityMapperGeneric.GetCreateStatement(entity);
                instance.ExecuteProcedure(operation);

            } catch (Exception e) {
                ManageException(e);
            }

            return true;
        }


        

        public T Retrieve<T>(BaseEntity entity) {
   
            try {

                var instance = SqlDao.GetInstance();
                var operation = EntityMapperGeneric.GetRetriveStatement(entity);
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];

            } catch (Exception e) {
                ManageException(e);
            }

            return default(T);
        }

        public List<T> RetrieveAll<T>() {

            try {

                var lstResult = SqlDao.GetInstance()
                    .ExecuteQueryProcedure(
                        EntityMapperGeneric.GetRetriveAllStatement()
                    );

                if (lstResult.Count <= 0) return default(List<T>);

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<T>().ToList();

            } catch (Exception e) {
                ManageException(e);
            }

            return null;
        }
        
        public bool Update(BaseEntity entity) {

            try {
                var operation = EntityMapperGeneric.GetUpdateStatement(entity);
                var instance = SqlDao.GetInstance();
                instance.ExecuteProcedure(operation);

                return true;

            } catch (Exception e) {
                ManageException(e);
            }

            return false;
        }

        public bool Delete(BaseEntity entity) {

            try {

                var operation = EntityMapperGeneric.GetDeleteStatement(entity);
                var instance = SqlDao.GetInstance();
                instance.ExecuteProcedure(operation);

                return true;

            }
            catch (Exception e) {
                ManageException(e);
            }

            return false;
        }

        protected void ManageException(Exception ex) {
            var exceptionManagment = ExceptionManagment.GetInstance();
            exceptionManagment.ManageException(ex);
            throw ex;
        }

        // public List<T> RetrieveAllByName<T>(BaseEntity entity) {

        //     try {
        //         var lstResult = SqlDao.GetInstance()
        //             .ExecuteQueryProcedure(
        //                 EntityMapper.GetRetriveAllByNameStatement(entity)
        //             );

        //         if (lstResult.Count <= 0) return default(List<T>);

        //         var obj = EntityMapper.BuildObjects(lstResult);

        //         return obj.Cast<T>().ToList();
        //     }
        //     catch (Exception e) {
        //         ManageException(e);
        //     }

        //     return null;

        // }

        // public T RCreate<T>(BaseEntity entity)
        // {

        //     try
        //     {

        //         var instance = SqlDao.GetInstance();
        //         var operation = EntityMapper.GetRCreateStatement(entity);
        //         var lstResult = instance.ExecuteQueryProcedure(operation);

        //         if (lstResult.Count <= 0) return default(T);

        //         var objs = EntityMapper.BuildObjects(lstResult);
        //         return objs.Cast<T>().ToList()[0];

        //     }
        //     catch (Exception e)
        //     {
        //         ManageException(e);
        //     }

        //     return default(T);
        // }
    }
}
