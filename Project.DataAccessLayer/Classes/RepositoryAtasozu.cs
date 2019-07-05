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
    public class RepositoryAtasozu : Repository<Atasozu>, IRepositoryAtasozu
    {
        public ProjectDbContext AtasozuDbContext { get { return Context as ProjectDbContext; } }

        public RepositoryAtasozu(ProjectDbContext context) : base(context)
        {

        }
    }
}
