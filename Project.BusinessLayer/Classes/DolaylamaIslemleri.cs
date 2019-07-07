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
    public class DolaylamaIslemleri : DeyisIslemleriADT<Dolaylama>
    {
        public DolaylamaIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new DolaylamaHeap();
        }

        public override Dolaylama CumleAra(string deyisCumle)
        {
            throw new NotImplementedException();
        }

        public override bool Ekle(Dolaylama entity)
        {
            throw new NotImplementedException();
        }

        public override bool Guncelle(Dolaylama entity)
        {
            throw new NotImplementedException();
        }

        public override Dolaylama IDAra(int deyisID)
        {
            throw new NotImplementedException();
        }

        public override bool Sil(Dolaylama entity)
        {
            throw new NotImplementedException();
        }

        public override List<Dolaylama> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
