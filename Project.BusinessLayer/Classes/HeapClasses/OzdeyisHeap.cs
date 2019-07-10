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
       private int currentSize;

        public OzdeyisHeap(List<Ozdeyis> OzdeyisHeapArray)
        {
            currentSize = 0;
            agacDugumleri = OzdeyisHeapArray;
        }
        public override Ozdeyis Ara(Predicate<Ozdeyis> predicate)
        {
           return agacDugumleri.Find(predicate);
            
        }

        public override void Ekle(Ozdeyis entity)
        {
            agacDugumleri[currentSize] = entity;
            MoveToUpOzdeyis(currentSize++);
        }

        public override void Guncelle(Ozdeyis entity)
        {
            Predicate<Ozdeyis> predicate = guncellenecekOzdeyis => guncellenecekOzdeyis.Id == entity.Id;
            Ozdeyis newOzdeyis = new Ozdeyis();
            newOzdeyis = Ara(predicate);
            newOzdeyis = entity;
        }

        public override void Sil(Ozdeyis entity)
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

        public override List<Ozdeyis> TumElemanList()
        {
            List<Ozdeyis> yedekListOzdeyisHeap = new List<Ozdeyis>();

            for (int i = 0; i < agacDugumleri.Count; i++)
            {
                yedekListOzdeyisHeap.Add(agacDugumleri[i]);
            }
            List<Ozdeyis> siraliListOzdeyisHeap = new List<Ozdeyis>();
            while (!IsEmpty())
            {
                siraliListOzdeyisHeap.Add(Remove(0));
                
            }
            agacDugumleri = yedekListOzdeyisHeap;
            return siraliListOzdeyisHeap;

        }
        private void MoveToUpOzdeyis(int index)
        {
            int parent = (index - 1) / 2;
            Ozdeyis bottom = agacDugumleri[index];
            while (string.Compare(agacDugumleri[parent].DeyisCumle.ToString(), bottom.DeyisCumle.ToString()) == -1)
            {
                agacDugumleri[index] = agacDugumleri[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            agacDugumleri[index] = bottom;
        }
        private void MoveToDownOzdeyis(int index)
        {
            int largerChild;
            Ozdeyis top = agacDugumleri[index];
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
        private Ozdeyis Remove(int index) 
        {
            Ozdeyis root = agacDugumleri[index];
            agacDugumleri[index] = agacDugumleri[--currentSize];
            MoveToDownOzdeyis(index);
            return root;
        }

        private bool IsEmpty()
        {
            return currentSize == 0;

        }
    }
}
