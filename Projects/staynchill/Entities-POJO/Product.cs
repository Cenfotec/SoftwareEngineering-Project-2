using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Product : BaseEntity
    {
        [PrimaryKey]
        [DbColumn("DIFFERENT_NAME")]
        public string Code { get; set; }
        [DbColumn("NAME")]
        public string Name { get; set; }
        [DbColumn("DESCRIPTION")]
        public string Description { get; set; }
        [DbColumn("ARRIVAL_DATE")]
        public DateTime ArrivalDate { get; set; }
        public string State { get; set; }

        public Product() {

        }

        public Product(string[] infoArray)
        {
            if(infoArray!=null && infoArray.Length >= 3){
                Code = infoArray[0];
                Name = infoArray[1];
                Description = infoArray[2];
                ArrivalDate = Convert.ToDateTime(infoArray[3]);
                State = "Available";        
            }
            else
            {
                throw new Exception("All values are require[code,name,description,ArrivalDate, taxes]");
            }

        }
    } 
}
