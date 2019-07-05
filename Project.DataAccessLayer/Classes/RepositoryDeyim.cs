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
    public class RepositoryDeyim : Repository<Deyim>, IRepositoryDeyim
    {
        public ProjectDbContext DeyimDbContext { get { return Context as ProjectDbContext; } }

        public RepositoryDeyim(ProjectDbContext context) : base(context)
        {

        }
    }
}
