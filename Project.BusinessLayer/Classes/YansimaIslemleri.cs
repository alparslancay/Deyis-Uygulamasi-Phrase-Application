using Project.BusinessLayer.Abstract_Classes;
using Project.BusinessLayer.Classes.HeapClasses;
using Project.DataAccessLayer.Classes;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Classes
{
    public class YansimaIslemleri : DeyisIslemleriADT<Yansima>
    {public YansimaIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new YansimaHeap(unitOfWork.Yansimalar.GetAll().ToList());
        }

        public override Yansima CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Predicate<Yansima> predicate = arananYansima => arananYansima.DeyisCumle == deyisCumle;
            return heapADT.Ara(predicate);
        }

        public override bool Ekle(Yansima entity)
        {
            try
            {
                unitOfWork.Yansimalar.Add(entity);
                heapADT.Ekle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Guncelle(Yansima entity)
        {
            try
            {
                Yansima eskiYansima = new Yansima();
                eskiYansima = unitOfWork.Yansimalar.Get(entity.Id);
                eskiYansima = entity;
                heapADT.Guncelle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override Yansima IDAra(int deyisID)
        {
            try
            {
                Predicate<Yansima> predicate = arananYansima => arananYansima.Id == deyisID;
                return heapADT.Ara(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool Sil(Yansima entity)
        {
            try
            {
                unitOfWork.Yansimalar.Remove(entity);
                heapADT.Sil(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override List<Yansima> TumElemanList()
        {
            return heapADT.TumElemanList();
        }
    }
}
