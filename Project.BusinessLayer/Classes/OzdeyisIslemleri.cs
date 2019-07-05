using Project.BusinessLayer.Abstract_Classes;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Classes
{
    public class OzdeyisIslemleri : DeyisIslemleriADT<Ozdeyis>
    {
        public override Ozdeyis CumleAra(string deyisCumle)
        {
            throw new NotImplementedException();
        }

        public override bool Ekle(Ozdeyis entity)
        {
            throw new NotImplementedException();
        }

        public override bool Guncelle(Ozdeyis entity)
        {
            throw new NotImplementedException();
        }

        public override bool IDAra(int deyisID)
        {
            throw new NotImplementedException();
        }

        public override bool Sil(Ozdeyis entity)
        {
            throw new NotImplementedException();
        }

        public override List<Ozdeyis> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
