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
    public class AtasozuIslemleri : DeyisIslemleriADT<Atasozu>
    {
        public AtasozuIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new AtasozuHeap();
        }

        public override Atasozu CumleAra(string deyisCumle)
        {
            throw new NotImplementedException();
        }

        public override bool Ekle(Atasozu entity)
        {
            throw new NotImplementedException();
        }

        public override bool Guncelle(Atasozu entity)
        {
            throw new NotImplementedException();
        }

        public override Atasozu IDAra(int deyisID)
        {
            throw new NotImplementedException();
        }

        public override bool Sil(Atasozu entity)
        {
            throw new NotImplementedException();
        }

        public override List<Atasozu> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
