using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud {
    public class CheckCrud : CrudFactory {
        public CheckCrud() : base(entityObjectMapper: new CheckObjectMapper(), entityMapperGeneric: new CheckMapper()) {
        }

        public List<RelatedSubReservation> RetrieveAllRelatedSubReservation(int idSubReservation) {

            try
            {
                var myMapper = new RelatedSubReservationObjectMapper();
                RelatedSubReservationMapper relatedSubMapper = new RelatedSubReservationMapper();
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure
                    (
                    relatedSubMapper.GetRetriveAllStatement(idSubReservation)
                    );

                if (lstResult.Count <= 0) return default(List<RelatedSubReservation>);

                var obj = myMapper.BuildObjects(lstResult);

                return obj.Cast<RelatedSubReservation>().ToList();

            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

        public void DoCheck(ActionCheck action)
        {
            try
            {
                CheckMapper checkMapper = new CheckMapper();
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure
                    (
                    checkMapper.GetActionCheckStatement(action)
                    );

            }
            catch (Exception e)
            {
                ManageException(e);
            }
        }

        public Check ValidatePays(int subReservacion)
        {

            try
            {
                CheckMapper mapper = new CheckMapper();
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure
                    (
                    mapper.GetValidatePaysStatement(subReservacion)
                    );
                if (lstResult.Count <= 0) return null;

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Check>().ToList().FirstOrDefault();


            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

        public Check getDateOut(int fkSubReservacion)
        {

            try
            {
                CheckMapper mapper = new CheckMapper();
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure
                    (
                    mapper.GetDateOutStatement(fkSubReservacion)
                    );
                if (lstResult.Count <= 0) return null;

                var obj = EntityObjectMapper.BuildObjects(lstResult);

                return obj.Cast<Check>().ToList().FirstOrDefault();


            }
            catch (Exception e)
            {
                ManageException(e);
            }

            return null;
        }

        public void changeOut(int fkSubReservacion)
        {

            try
            {
                CheckMapper mapper = new CheckMapper();
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure
                    (
                    mapper.GetChangeOutStatement(fkSubReservacion)
                    );
            }
            catch (Exception e)
            {
                ManageException(e);
            }
        }

        public void deleteCar(int fkCarrito)
        {

            try
            {
                CheckMapper mapper = new CheckMapper();
                var lstResult = SqlDao.GetInstance().ExecuteQueryProcedure
                    (
                    mapper.GetDeleteCarStatement(fkCarrito)
                    );
            }
            catch (Exception e)
            {
                ManageException(e);
            }
        }
    }
}
