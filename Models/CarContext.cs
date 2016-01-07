using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebAppDevQuiz.Models
{
    public class CarContext : DbContext
    {
        public CarContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
