using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Classes
{
    public class ProjectDbContext : DbContext
    {
        public virtual DbSet<Atasozu> Atasozleri { get; set; }
        public virtual DbSet<Deyim> Deyimler { get; set; }
        public virtual DbSet<Dolaylama> Dolaylamalar { get; set; }
        public virtual DbSet<Ikileme> Ikilemeler { get; set; }
        public virtual DbSet<Ozdeyis> Ozdeyisler { get; set; }
        public virtual DbSet<Yansima> Yansimalar { get; set; }

        public ProjectDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}
