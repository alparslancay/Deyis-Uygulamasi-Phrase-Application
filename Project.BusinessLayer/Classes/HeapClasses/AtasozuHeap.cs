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
    public class AtasozuHeap : HeapADT<Atasozu>
    {
        public override Atasozu Ara(Predicate<Atasozu> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Ekle(Atasozu entity)
        {
            throw new NotImplementedException();
        }

        public override void Guncelle(Atasozu entity)
        {
            throw new NotImplementedException();
        }

        public override void Sil(Atasozu entity)
        {
            throw new NotImplementedException();
        }

        public override List<Atasozu> TumElemanList()
        {
            throw new NotImplementedException();
        }
    }
}
