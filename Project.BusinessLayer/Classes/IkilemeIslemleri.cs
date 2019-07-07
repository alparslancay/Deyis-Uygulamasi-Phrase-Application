using Project.BusinessLayer.Abstract_Classes;
using Project.BusinessLayer.Classes.HeapClasses;
using Project.DataAccessLayer.Classes;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Classes
{
    public class IkilemeIslemleri : DeyisIslemleriADT<Ikileme>
    {
        public IkilemeIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new IkilemeHeap();
        }

        public override Ikileme CumleAra(string deyisCumle)
        {
            throw new NotImplementedException();
        }

        public override bool Ekle(Ikileme entity)
        {
            throw new NotImplementedException();
        }

        public override bool Guncelle(Ikileme entity)
        {
            throw new NotImplementedException();
        }

        public override Ikileme IDAra(int deyisID)
        {
            throw new NotImplementedException();
        }

        public override bool Sil(Ikileme entity)
        {
            throw new NotImplementedException();
        }

        public override List<Ikileme> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
