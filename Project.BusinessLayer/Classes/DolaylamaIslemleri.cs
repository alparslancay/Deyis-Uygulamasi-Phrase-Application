using Project.BusinessLayer.Abstract_Classes;
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

        public override bool IDAra(int deyisID)
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
