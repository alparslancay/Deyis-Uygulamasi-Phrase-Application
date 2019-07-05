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
    public class RepositoryIkileme : Repository<Ikileme>, IRepositoryIkileme
    {
        public ProjectDbContext IkilemeDbContext { get { return Context as ProjectDbContext; } }
        public RepositoryIkileme(ProjectDbContext context) : base(context)
        {

        }
    }
}
