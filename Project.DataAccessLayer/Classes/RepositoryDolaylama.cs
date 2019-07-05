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
    public class RepositoryDolaylama : Repository<Dolaylama>,IRepositoryDolaylama
    {
        public ProjectDbContext DolaylamaDbContext { get { return Context as ProjectDbContext; } }

        public RepositoryDolaylama(ProjectDbContext context) : base(context)
        {

        }
    }
}
