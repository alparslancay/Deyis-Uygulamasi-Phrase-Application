using Project.BusinessLayer.Abstract_Classes;
using Project.BusinessLayer.Classes.HeapClasses;
using Project.DataAccessLayer.Classes;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Classes
{
    public class DolaylamaIslemleri : DeyisIslemleriADT<Dolaylama>
    {public DolaylamaIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new DolaylamaHeap(unitOfWork.Dolaylamalar.GetAll().ToList());
        }

        public override Dolaylama CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            Predicate<Dolaylama> predicate = arananDolaylama => arananDolaylama.DeyisCumle == deyisCumle;
            return heapADT.Ara(predicate);
        }

        public override bool Ekle(Dolaylama entity)
        {
            try
            {
                entity.DeyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entity.DeyisCumle);
                unitOfWork.Dolaylamalar.Add(entity);
                heapADT.Ekle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Guncelle(Dolaylama entity)
        {
            try
            {
                Dolaylama eskiDolaylama = new Dolaylama();
                eskiDolaylama = unitOfWork.Dolaylamalar.Get(entity.Id);
                eskiDolaylama = entity;
                heapADT.Guncelle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override Dolaylama IDAra(int deyisID)
        {
            try
            {
                Predicate<Dolaylama> predicate = arananDolaylama => arananDolaylama.Id == deyisID;
                return heapADT.Ara(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool Sil(Dolaylama entity)
        {
            try
            {
                unitOfWork.Dolaylamalar.Remove(entity);
                heapADT.Sil(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override List<Dolaylama> TumElemanList()
        {
            return heapADT.TumElemanList();
        }
    }
}
