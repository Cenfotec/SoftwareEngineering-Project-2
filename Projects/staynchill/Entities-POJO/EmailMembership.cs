using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class EmailMembership : BaseEntity
    {
        public int FkHotel { get; set; }
        public string Percentage { get; set; }
        public string membershipPrice { get; set; }
        public string membershipMonths { get; set; }
        public string membershipStartDate { get; set; }
        public string membershipEndDate { get; set; }

        public EmailMembership()
        {

        }

        public EmailMembership(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 1)
            {
                FkHotel = Int32.Parse(infoArray[1]);
                Percentage = infoArray[2];
                membershipPrice = infoArray[3];
                membershipMonths = infoArray[4];
                membershipStartDate = infoArray[5];
                membershipEndDate = infoArray[6];

            }
            else
            {
                throw new Exception("All values are require[code,name,description,ArrivalDate, taxes]");
            }

        }
    }
}
