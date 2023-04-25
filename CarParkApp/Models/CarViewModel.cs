using Entity;

namespace CarParkApp.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime TimeSpan { get; set; }
        public int CarTypeId { get; set; }
    }
}
