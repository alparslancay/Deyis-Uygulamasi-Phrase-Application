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
    public class IkilemeIslemleri : DeyisIslemleriADT<Ikileme>
    {
        public IkilemeIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new IkilemeHeap(unitOfWork.Ikilemeler.GetAll().ToList());
        }

        public override Ikileme CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Predicate<Ikileme> predicate = arananIkileme => arananIkileme.DeyisCumle == deyisCumle;
            return heapADT.Ara(predicate);
        }

        public override bool Ekle(Ikileme entity)
        {
            try
            {
                unitOfWork.Ikilemeler.Add(entity);
                heapADT.Ekle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Guncelle(Ikileme entity)
        {
            try
            {
                Ikileme eskiIkileme = new Ikileme();
                eskiIkileme = unitOfWork.Ikilemeler.Get(entity.Id);
                eskiIkileme = entity;
                heapADT.Guncelle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override Ikileme IDAra(int deyisID)
        {
            try
            {
                Predicate<Ikileme> predicate = arananIkileme => arananIkileme.Id == deyisID;
                return heapADT.Ara(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool Sil(Ikileme entity)
        {
            try
            {
                unitOfWork.Ikilemeler.Remove(entity);
                heapADT.Sil(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override List<Ikileme> TumElemanList()
        {
            return heapADT.TumElemanList();
        }
    }
}
