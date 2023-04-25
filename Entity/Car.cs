using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Car
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public DateTime EnterTime { get; set; }

        //Navigation property
        public CarType CarType { get; set; }
        public int CarTypeId { get; set; }
    }
}
