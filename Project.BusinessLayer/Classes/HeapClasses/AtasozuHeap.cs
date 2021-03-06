﻿using Project.BusinessLayer.Abstract_Classes;
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
       private int currentSize;
        public AtasozuHeap(List<Atasozu> atasozuList)
        {
            currentSize = 0;
            agacDugumleri = new List<Atasozu>();

            foreach (var simdikiDeyis in atasozuList)
            {
                Ekle(simdikiDeyis);
            }
        }
        public override Atasozu Ara(Predicate<Atasozu> predicate)
        {
            return agacDugumleri.Find(predicate);
        }

        public override void Ekle(Atasozu entity)
        {
            agacDugumleri.Add(entity);
            MoveToUpAtasozu(currentSize++);
        }

        public override void Guncelle(Atasozu entity)
        {
            Predicate<Atasozu> predicate = guncellenecekAtasozu => guncellenecekAtasozu.Id == entity.Id;
            Atasozu newAtasozu = new Atasozu();
            newAtasozu = Ara(predicate);
            newAtasozu = entity;
        }

        public override void Sil(Atasozu entity)
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

        public override List<Atasozu> TumElemanList()
        {
            List<Atasozu> yedekListAtasozuHeap = new List<Atasozu>();

            for (int i = 0; i < agacDugumleri.Count; i++)
            {
                yedekListAtasozuHeap.Add(agacDugumleri[i]);
            }
            List<Atasozu> siraliListAtasozuHeap = new List<Atasozu>();
            while (!IsEmpty())
            {
                siraliListAtasozuHeap.Add(Remove(0));

            }
            agacDugumleri = yedekListAtasozuHeap;
            return siraliListAtasozuHeap;

        }
        private void MoveToUpAtasozu(int index)
        {
            int parent = (index - 1) / 2;
            Atasozu bottom = agacDugumleri[index];
            while (index > 0 && string.Compare(agacDugumleri[parent].DeyisCumle.ToString(), bottom.DeyisCumle.ToString()) == 1)
            {
                agacDugumleri[index] = agacDugumleri[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            agacDugumleri[index] = bottom;
        }
        private void MoveToDownAtasozu(int index)
        {
            int largerChild;
            Atasozu top = agacDugumleri[index];
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
        private Atasozu Remove(int index)
        {
            Atasozu root = agacDugumleri[index];
            agacDugumleri[index] = agacDugumleri[--currentSize];
            MoveToDownAtasozu(index);
            return root;
        }

        private bool IsEmpty()
        {
            return currentSize == 0;

        }
    }
}
