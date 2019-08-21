using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreAPI {
    public class CheckManagement {

        private CheckCrud crudCheck;

        public CheckManagement() => crudCheck = new CheckCrud();

        public Check hacerCheck(string decoded)
        {
            
            List<string> ids = decoded.Split(',').ToList<string>();
            Check check = new Check()
            {
                FkSubReservacion = ids[1]
            };
            int subReservationId = Int32.Parse(check.FkSubReservacion);

            Check retorno = Retrieve(check);

            if (retorno.FkSubReservacion.Equals("CAN_CHECK_OUT"))
            {
                List<RelatedSubReservation> subReservaciones = RetrieveRelatedSubReservations(subReservationId);
                int count = subReservaciones.Count;
                Boolean noSalir = false;
                int i = 0;
                do
                {
                    int num = subReservaciones.ElementAt(i).ID_SUBRESERVATION;
                    Check validate;
                    validate = ValidatePays(num);
                    if (validate == null)
                    {
                        noSalir = true;
                    }
                    i++;
                } while (noSalir == false && i < count);

                if(noSalir == false)
                {
                    ActionCheck action = new ActionCheck()
                    {
                        FkSubReservacion = subReservationId,
                        Action = "OUT"
                    };
                    DoCheck(action);
                    retorno.FkSubReservacion = "¡Check-out exitoso!";
                }
                else if (count == 1 && noSalir == true)
                {
                    retorno.FkSubReservacion = "No puede realizar check-out " +
                        "por que usted no han cancelado su cuenta. Si tiene algún inconveniente " +
                        "favor comunicarse con el hotel";
                }
                else if (count > 1 && noSalir == true)
                {
                    retorno.FkSubReservacion = "No puede realizar check-out " +
                        "por que uno o mas invitados no han cancelado su cuenta. Si tiene algún inconveniente " +
                        "favor comunicarse con el hotel";
                }
            }
            else if (retorno.FkSubReservacion.Equals("CAN_CHECK_IN"))
            {
                ActionCheck action = new ActionCheck()
                {
                    FkSubReservacion = subReservationId,
                    Action = "IN"
                };
                DoCheck(action);
                retorno.FkSubReservacion = "¡Check-in exitoso!";
            }

            return retorno;
        }
        public Check Retrieve(Check check) => crudCheck.Retrieve<Check>(check);
        public void Update(Check check) => crudCheck.Update(check);

        public List<RelatedSubReservation> RetrieveRelatedSubReservations(int subReservationId) =>
            crudCheck.RetrieveAllRelatedSubReservation(subReservationId);

        public void DoCheck(ActionCheck action) => crudCheck.DoCheck(action);

        public Check ValidatePays(int subReservacion) => crudCheck.ValidatePays(subReservacion);

        public Check getDateOut(int fkSubReservacion) => crudCheck.getDateOut(fkSubReservacion);

        public void changeOut(int fkSubReservacion) => crudCheck.changeOut(fkSubReservacion);

        public void deleteCar(int fkCarrito) => crudCheck.deleteCar(fkCarrito);
        
    }
}
