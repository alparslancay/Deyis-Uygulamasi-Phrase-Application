using Project.BusinessLayer.Abstract_Classes;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Classes
{
    public class DeyimIslemleri : DeyisIslemleriADT<Deyim>
    {
        public override Deyim CumleAra(string deyisCumle)
        {
            throw new NotImplementedException();
        }

        public override bool Ekle(Deyim entity)
        {
            throw new NotImplementedException();
        }

        public override bool Guncelle(Deyim entity)
        {
            throw new NotImplementedException();
        }

        public override bool IDAra(int deyisID)
        {
            throw new NotImplementedException();
        }

        public override bool Sil(Deyim entity)
        {
            throw new NotImplementedException();
        }

        public override List<Deyim> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
