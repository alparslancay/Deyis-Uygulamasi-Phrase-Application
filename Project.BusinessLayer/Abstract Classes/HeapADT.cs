using Project.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Abstract_Classes
{
    public abstract class HeapADT<TEntity> where TEntity : class
    {
        protected List<TEntity> agacDugumleri;
        public abstract void Ekle(TEntity entity);
        public abstract void Guncelle(TEntity entity);
        public abstract TEntity Ara(Predicate<TEntity> predicate);
        public abstract void Sil(TEntity entity);
        public abstract List<TEntity> TumElemanList();

    }
}
