using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Abstract_Classes
{
    public abstract class HeapDugumu<TEntity> where TEntity : class
    {
        protected TEntity entity;
    }
}
