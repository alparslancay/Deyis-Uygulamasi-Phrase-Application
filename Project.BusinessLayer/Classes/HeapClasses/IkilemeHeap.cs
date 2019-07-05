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
    public class IkilemeHeap : HeapADT<Ikileme>
    {
        public override Ikileme Ara(Expression<Func<Ikileme, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Ekle(Ikileme entity)
        {
            throw new NotImplementedException();
        }

        public override void Guncelle(Ikileme entity)
        {
            throw new NotImplementedException();
        }

        public override void Sil(Ikileme entity)
        {
            throw new NotImplementedException();
        }

        public override List<Ikileme> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
