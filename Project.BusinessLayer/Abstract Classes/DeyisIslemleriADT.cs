using Project.BusinessLayer.Interfaces;
using Project.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Abstract_Classes
{
    public abstract class DeyisIslemleriADT<TEntity> : IYetkiliIslemleri<TEntity> where TEntity : class
    {
        protected IUnitOfWork unitOfWork;
        protected HeapADT<TEntity> heapADT;

        public abstract TEntity CumleAra(string deyisCumle);


        public abstract bool Ekle(TEntity entity);

        public abstract bool Guncelle(TEntity entity);


        public abstract TEntity IDAra(int deyisID);


        public abstract bool Sil(TEntity entity);


        public abstract List<TEntity> TumElemanList();
    }
}
