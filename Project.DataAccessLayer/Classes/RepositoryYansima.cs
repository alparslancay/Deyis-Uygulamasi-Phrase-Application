using Project.DataAccessLayer.Interfaces;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Classes
{
    public class RepositoryYansima : Repository<Yansima>,IRepositoryYansima
    {
        public ProjectDbContext YansimaDbContext { get { return Context as ProjectDbContext; } }

        public RepositoryYansima(ProjectDbContext context) : base(context)
        {

        }
    }
}
