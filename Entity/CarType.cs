using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CarType
    {
        public int Id { get; set; }
        public string CarTypeName { get; set; }
        public List<Car> cars { get; set; }
    }
}
