using DataAccess.Dao;
using DataAccess.Mapper;
using DataAccess.Mapper.Entities.PlatformStats;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace DataAccess.Crud
{
    public class PlatformStatsCrud : CrudFactory
    {

        public PlatformStatsCrud() : base(entityObjectMapper: new PlatformStatsObjectMapper(), entityMapperGeneric: new PlatformStatsMapper()) { }

        PlatformStatsMapper platStatsMapper = new PlatformStatsMapper();

        public T RetAllPromGanaciasComision<T>()
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = platStatsMapper.GetRetAllPromGanaciasComision();
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

        public T RetAllPromGanaciasMembresia<T>()
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = platStatsMapper.GetRetAllPromGanaciasMembresia();
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

        public T RetAllGanaciasComision<T>()
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = platStatsMapper.GetRetAllGanaciasComision();
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

        public T RetAllGanaciasMembresia<T>()
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = platStatsMapper.GetRetAllGanaciasMembresia();
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

        public T RetAllGanaciasPlataforma<T>()
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = platStatsMapper.GetRetAllGanaciasPlataforma();
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

        public T RetAllHoteles<T>()
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = platStatsMapper.GetRetAllHoteles();
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

        public T RetAllMembresiaPlataforma<T>()
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = platStatsMapper.GetRetAllMembresiaPlataforma();
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

        public T RetAllUsuarios<T>()
        {
            try
            {
                var instance = SqlDao.GetInstance();
                var operation = platStatsMapper.GetRetAllUsuarios();
                var lstResult = instance.ExecuteQueryProcedure(operation);

                if (lstResult.Count <= 0) return default(T);

                var objs = EntityObjectMapper.BuildObjects(lstResult);

                return objs.Cast<T>().ToList()[0];
            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return default(T);
        }

    }
}
