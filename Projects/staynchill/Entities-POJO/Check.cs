using System;
using System.Data;

namespace Entities_POJO
{
    public class Check : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("FK_SUBRESERVACION")]
        public string FkSubReservacion { get; set; }
        public Check() {

        }

        public Check(string[] infoArray)
        {
            if(infoArray!=null && infoArray.Length >= 1){
                FkSubReservacion = infoArray[0];
            }
            else
            {
                throw new Exception("All values are require[code,name,description,ArrivalDate, taxes]");
            }

        }
    }

    public class RelatedSubReservation : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("FK_SUBRESERVACION")]
        public int ID_SUBRESERVATION { get; set; }
        public RelatedSubReservation()
        {

        }
    }

    public class ActionCheck : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("FK_SUBRESERVACION")]
        public int FkSubReservacion { get; set; }
        public string Action { get; set; }

        public ActionCheck()
        {

        }
    }

}
