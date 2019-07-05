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
    public class OzdeyisHeap : HeapADT<Ozdeyis>
    {
        public override Ozdeyis Ara(Expression<Func<Ozdeyis, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Ekle(Ozdeyis entity)
        {
            throw new NotImplementedException();
        }

        public override void Guncelle(Ozdeyis entity)
        {
            throw new NotImplementedException();
        }

        public override void Sil(Ozdeyis entity)
        {
            throw new NotImplementedException();
        }

        public override List<Ozdeyis> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
