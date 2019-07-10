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
    public class AtasozuIslemleri : DeyisIslemleriADT<Atasozu>
    { public AtasozuIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new AtasozuHeap(unitOfWork.Atasozleri.GetAll().ToList());
        }

        public override Atasozu CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Predicate<Atasozu> predicate = arananAtasozu => arananAtasozu.DeyisCumle == deyisCumle;
            return heapADT.Ara(predicate);
        }

        public override bool Ekle(Atasozu entity)
        {
            try
            {
                unitOfWork.Atasozleri.Add(entity);
                heapADT.Ekle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Guncelle(Atasozu entity)
        {
            try
            {
                Atasozu eskiAtasozu = new Atasozu();
                eskiAtasozu = unitOfWork.Atasozleri.Get(entity.Id);
                eskiAtasozu = entity;
                heapADT.Guncelle(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override Atasozu IDAra(int deyisID)
        {
            try
            {
                Predicate<Atasozu> predicate = arananAtasozu => arananAtasozu.Id == deyisID;
                return heapADT.Ara(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool Sil(Atasozu entity)
        {
            try
            {
                unitOfWork.Atasozleri.Remove(entity);
                heapADT.Sil(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override List<Atasozu> TumElemanList()
        {
            return heapADT.TumElemanList();
        }
    }
}
