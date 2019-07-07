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
    public class YansimaIslemleri : DeyisIslemleriADT<Yansima>
    {
        public YansimaIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new YansimaHeap();
        }

        public override Yansima CumleAra(string deyisCumle)
        {
            throw new NotImplementedException();
        }

        public override bool Ekle(Yansima entity)
        {
            throw new NotImplementedException();
        }

        public override bool Guncelle(Yansima entity)
        {
            throw new NotImplementedException();
        }

        public override Yansima IDAra(int deyisID)
        {
            throw new NotImplementedException();
        }

        public override bool Sil(Yansima entity)
        {
            throw new NotImplementedException();
        }

        public override List<Yansima> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
