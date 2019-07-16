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
       private int currentSize;
        public IkilemeHeap(List<Ikileme> ikilemeList)
        {
            currentSize = 0;
            agacDugumleri = new List<Ikileme>();

            foreach (var simdikiDeyis in ikilemeList)
            {
                Ekle(simdikiDeyis);
            }
        }
        public override Ikileme Ara(Predicate<Ikileme> predicate)
        {
            return agacDugumleri.Find(predicate);
        }

        public override void Ekle(Ikileme entity)
        {
            agacDugumleri.Add(entity);
            MoveToUpIkileme(currentSize++);
        }

        public override void Guncelle(Ikileme entity)
        {
            Predicate<Ikileme> predicate = guncellenecekIkileme => guncellenecekIkileme.Id == entity.Id;
            Ikileme newIkileme = new Ikileme();
            newIkileme = Ara(predicate);
            newIkileme = entity;
            
        }

        public override void Sil(Ikileme entity)
        {
            for (int index = 0; index < agacDugumleri.Count; index++)
            {
                if (agacDugumleri[index].Id == entity.Id)
                {
                    Remove(index);
                    break;
                }
            }
        }

        public override List<Ikileme> TumElemanList()
        {
            List<Ikileme> yedekListIkilemeHeap = new List<Ikileme>();

            for (int i = 0; i < agacDugumleri.Count; i++)
            {
                yedekListIkilemeHeap.Add(agacDugumleri[i]);
            }
            List<Ikileme> siraliListIkilemeHeap = new List<Ikileme>();
            while (!IsEmpty())
            {
                siraliListIkilemeHeap.Add(Remove(0));

            }
            agacDugumleri = yedekListIkilemeHeap;
            return siraliListIkilemeHeap;

        }
        private void MoveToUpIkileme(int index)
        {
            int parent = (index - 1) / 2;
            Ikileme bottom = agacDugumleri[index];
            while (index > 0 && string.Compare(agacDugumleri[parent].DeyisCumle.ToString(), bottom.DeyisCumle.ToString()) == -1)
            {
                agacDugumleri[index] = agacDugumleri[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            agacDugumleri[index] = bottom;
        }
        private void MoveToDownIkileme(int index)
        {
            int largerChild;
            Ikileme top = agacDugumleri[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;

                if (rightChild < currentSize && string.Compare(agacDugumleri[leftChild].DeyisCumle, agacDugumleri[rightChild].DeyisCumle) == 1)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (string.Compare(top.DeyisCumle, agacDugumleri[largerChild].DeyisCumle) == -1)
                    break;
                agacDugumleri[index] = agacDugumleri[largerChild];
                index = largerChild;
            }
            agacDugumleri[index] = top;
        }
        private Ikileme Remove(int index)
        {
            Ikileme root = agacDugumleri[index];
            agacDugumleri[index] = agacDugumleri[--currentSize];
            MoveToDownIkileme(index);
            return root;
        }

        private bool IsEmpty()
        {
            return currentSize == 0;

        }
    }
}
