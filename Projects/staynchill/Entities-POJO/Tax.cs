using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Tax : BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }

        [DbColumn("NAME")]
        public string Name { get; set; }

        [DbColumn("PERCENTAGE")]
        public decimal Percentage { get; set; }

        [DbColumn("ESTADO")]
        public string State { get; set; }

        public Tax()
        {
        }

        public Tax(int id, string name, decimal percentage)
        {
            Id = id;
            Name = name;
            Percentage = percentage;
            State = "Enable";
        }

        public Tax(string name, decimal percentage)
        {
            Name = name;
            Percentage = percentage;
            State = "Enable";
        }

        public Tax(string[] infoArray)
        {
            if (infoArray?.Length >= 3)
            {
                Id = Convert.ToInt32(infoArray[0]);
                Name = infoArray[1];
                Percentage = Convert.ToDecimal(infoArray[2]);
                State = "available";
            }
            else
            {
                throw new Exception("all values are require[Id,Name,Percentage]");
            }

        }
    }
}
