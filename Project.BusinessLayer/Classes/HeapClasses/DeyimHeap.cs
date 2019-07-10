using Project.BusinessLayer.Abstract_Classes;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Classes.HeapClasses
{
    public class DeyimHeap : HeapADT<Deyim>
    {
        public override Deyim Ara(Predicate<Deyim> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Ekle(Deyim entity)
        {
            throw new NotImplementedException();
        }

        public override void Guncelle(Deyim entity)
        {
            throw new NotImplementedException();
        }

        public override void Sil(Deyim entity)
        {
            throw new NotImplementedException();
        }

        public override List<Deyim> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
