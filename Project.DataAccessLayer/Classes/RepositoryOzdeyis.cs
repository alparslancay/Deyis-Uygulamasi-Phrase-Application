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
    public class RepositoryOzdeyis : Repository<Ozdeyis>, IRepositoryOzdeyis
    {
        public ProjectDbContext OzdeyisDbContext { get { return Context as ProjectDbContext; } }

        public RepositoryOzdeyis(ProjectDbContext context) : base(context)
        {

        }
    }
}
