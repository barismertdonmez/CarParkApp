using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class CarParkContext : DbContext
    {
        public DbSet<Car> cars { get; set; }
        public DbSet<CarType> carTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CarPark.Db;User Id=sa;Password=123WsX.456;Encrypt=False");
        }
    }
}
