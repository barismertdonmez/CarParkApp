using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel
{
    public class CreateCarDataModel
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public DateTime EnterTime { get; set; }
        public int CarTypeId { get; set; }
    }
}
