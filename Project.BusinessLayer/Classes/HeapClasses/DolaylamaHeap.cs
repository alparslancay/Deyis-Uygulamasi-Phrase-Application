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
    public class DolaylamaHeap : HeapADT<Dolaylama>
    {
         private int currentSize;
        public DolaylamaHeap(List<Dolaylama> DolaylamaHeapArray)
        {
            currentSize = 0;
            agacDugumleri = DolaylamaHeapArray;
        }
        public override Dolaylama Ara(Predicate<Dolaylama> predicate)
        {
            return agacDugumleri.Find(predicate);
        }

        public override void Ekle(Dolaylama entity)
        {
            agacDugumleri[currentSize] = entity;
            MoveToUpDolaylama(currentSize++);
        }

        public override void Guncelle(Dolaylama entity)
        {
            Predicate<Dolaylama> predicate = guncellenecekDolaylama => guncellenecekDolaylama.Id == entity.Id;
            Dolaylama newDolaylama = new Dolaylama();
            newDolaylama = Ara(predicate);
            newDolaylama = entity;
        }

        public override void Sil(Dolaylama entity)
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

        public override List<Dolaylama> TumElemanList()
        {
            List<Dolaylama> yedekListDolaylamaHeap = new List<Dolaylama>();

            for (int i = 0; i < agacDugumleri.Count; i++)
            {
                yedekListDolaylamaHeap.Add(agacDugumleri[i]);
            }
            List<Dolaylama> siraliListDolaylamaHeap = new List<Dolaylama>();
            while (!IsEmpty())
            {
                siraliListDolaylamaHeap.Add(Remove(0));

            }
            agacDugumleri = yedekListDolaylamaHeap;
            return siraliListDolaylamaHeap;

        }
        private void MoveToUpDolaylama(int index)
        {
            int parent = (index - 1) / 2;
            Dolaylama bottom = agacDugumleri[index];
            while (string.Compare(agacDugumleri[parent].DeyisCumle.ToString(), bottom.DeyisCumle.ToString()) == -1)
            {
                agacDugumleri[index] = agacDugumleri[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            agacDugumleri[index] = bottom;
        }
        private void MoveToDownDolaylama(int index)
        {
            int largerChild;
            Dolaylama top = agacDugumleri[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;

                if (rightChild < currentSize && string.Compare(agacDugumleri[leftChild].DeyisCumle, agacDugumleri[rightChild].DeyisCumle) == -1)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (string.Compare(top.DeyisCumle, agacDugumleri[largerChild].DeyisCumle) == 1)
                    break;
                agacDugumleri[index] = agacDugumleri[largerChild];
                index = largerChild;
            }
            agacDugumleri[index] = top;
        }
        private Dolaylama Remove(int index)
        {
            Dolaylama root = agacDugumleri[index];
            agacDugumleri[index] = agacDugumleri[--currentSize];
            MoveToDownDolaylama(index);
            return root;
        }

        private bool IsEmpty()
        {
            return currentSize == 0;

        }
    }
}
