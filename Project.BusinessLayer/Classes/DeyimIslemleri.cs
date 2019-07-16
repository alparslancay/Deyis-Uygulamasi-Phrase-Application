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
    public class DeyimIslemleri : DeyisIslemleriADT<Deyim>
    {public DeyimIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new DeyimHeap(unitOfWork.Deyimler.GetAll().ToList());
        }

        public override Deyim CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            Predicate<Deyim> predicate = arananDeyim => arananDeyim.DeyisCumle == deyisCumle;
            return heapADT.Ara(predicate);
        }

        public override bool Ekle(Deyim entity)
        {
            try
            {
                entity.DeyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entity.DeyisCumle);
                unitOfWork.Deyimler.Add(entity);
                heapADT.Ekle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Guncelle(Deyim entity)
        {
            try
            {
                Deyim eskiDeyim = new Deyim();
                eskiDeyim = unitOfWork.Deyimler.Get(entity.Id);
                eskiDeyim = entity;
                heapADT.Guncelle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override Deyim IDAra(int deyisID)
        {
            try
            {
                Predicate<Deyim> predicate = arananDeyim => arananDeyim.Id == deyisID;
                return heapADT.Ara(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool Sil(Deyim entity)
        {
            try
            {
                unitOfWork.Deyimler.Remove(entity);
                heapADT.Sil(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override List<Deyim> TumElemanList()
        {
            return heapADT.TumElemanList();
        }
    }
}
