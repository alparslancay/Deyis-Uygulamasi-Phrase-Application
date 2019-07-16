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
    public class YansimaHeap : HeapADT<Yansima>
    {
        private int currentSize;
        public YansimaHeap(List<Yansima> yansimaList)
        {
            currentSize = 0;
            agacDugumleri = new List<Yansima>();

            foreach (var simdikiDeyis in yansimaList)
            {
                Ekle(simdikiDeyis);
            }
        }
        public override Yansima Ara(Predicate<Yansima> predicate)
        {
            return agacDugumleri.Find(predicate);
        }

        public override void Ekle(Yansima entity)
        {
            agacDugumleri.Add(entity);
            MoveToUpYansima(currentSize++);
        }

        public override void Guncelle(Yansima entity)
        {
            Predicate<Yansima> predicate = guncellenecekYansima => guncellenecekYansima.Id == entity.Id;
            Yansima newYansima = new Yansima();
            newYansima = Ara(predicate);
            newYansima = entity;
        }

        public override void Sil(Yansima entity)
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

        public override List<Yansima> TumElemanList()
        {
            List<Yansima> yedekListYansimaHeap = new List<Yansima>();

            for (int i = 0; i < agacDugumleri.Count; i++)
            {
                yedekListYansimaHeap.Add(agacDugumleri[i]);
            }
            List<Yansima> siraliListYansimaHeap = new List<Yansima>();
            while (!IsEmpty())
            {
                siraliListYansimaHeap.Add(Remove(0));

            }
            agacDugumleri = yedekListYansimaHeap;
            return siraliListYansimaHeap;

        }
        private void MoveToUpYansima(int index)
        {
            int parent = (index - 1) / 2;
            Yansima bottom = agacDugumleri[index];
            while (index > 0 && string.Compare(agacDugumleri[parent].DeyisCumle.ToString(), bottom.DeyisCumle.ToString()) == -1)
            {
                agacDugumleri[index] = agacDugumleri[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            agacDugumleri[index] = bottom;
        }
        private void MoveToDownYansima(int index)
        {
            int largerChild;
            Yansima top = agacDugumleri[index];
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
        private Yansima Remove(int index)
        {
            Yansima root = agacDugumleri[index];
            agacDugumleri[index] = agacDugumleri[--currentSize];
            MoveToDownYansima(index);
            return root;
        }

        private bool IsEmpty()
        {
            return currentSize == 0;

        }
    }
}
