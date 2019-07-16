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
        private int currentSize;
        public DeyimHeap(List<Deyim> deyimList)
        {
            currentSize = 0;
            agacDugumleri = new List<Deyim>();

            foreach (var simdikiDeyis in deyimList)
            {
                Ekle(simdikiDeyis);
            }
        }
        public override Deyim Ara(Predicate<Deyim> predicate)
        {
            return agacDugumleri.Find(predicate);
        }

        public override void Ekle(Deyim entity)
        {
            agacDugumleri.Add(entity);
            MoveToUpDeyim(currentSize++);
        }

        public override void Guncelle(Deyim entity)
        {
            Predicate<Deyim> predicate = guncellenecekDeyim => guncellenecekDeyim.Id == entity.Id;
            Deyim newDeyim = new Deyim();
            newDeyim = Ara(predicate);
            newDeyim = entity;
        }

        public override void Sil(Deyim entity)
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

        public override List<Deyim> TumElemanList()
        {
            List<Deyim> yedekListDeyimHeap = new List<Deyim>();

            for (int i = 0; i < agacDugumleri.Count; i++)
            {
                yedekListDeyimHeap.Add(agacDugumleri[i]);
            }
            List<Deyim> siraliListDeyimHeap = new List<Deyim>();
            while (!IsEmpty())
            {
                siraliListDeyimHeap.Add(Remove(0));

            }
            agacDugumleri = yedekListDeyimHeap;
            return siraliListDeyimHeap;

        }
        private void MoveToUpDeyim(int index)
        {
            int parent = (index - 1) / 2;
            Deyim bottom = agacDugumleri[index];
            while (index > 0 && string.Compare(agacDugumleri[parent].DeyisCumle.ToString(), bottom.DeyisCumle.ToString()) == -1)
            {
                agacDugumleri[index] = agacDugumleri[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            agacDugumleri[index] = bottom;
        }
        private void MoveToDownDeyim(int index)
        {
            int largerChild;
            Deyim top = agacDugumleri[index];
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
        private Deyim Remove(int index)
        {
            Deyim root = agacDugumleri[index];
            agacDugumleri[index] = agacDugumleri[--currentSize];
            MoveToDownDeyim(index);
            return root;
        }

        private bool IsEmpty()
        {
            return currentSize == 0;

        }
    }
}
