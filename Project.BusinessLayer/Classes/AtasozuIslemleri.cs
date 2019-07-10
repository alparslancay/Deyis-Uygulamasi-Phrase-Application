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
            heapADT = new AtasozuHeap();
        }

        public override Atasozu CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Expression<Func<Atasozu, bool>> predicate = arananAtasozu => arananAtasozu.DeyisCumle == deyisCumle;
            IEnumerable<Atasozu> istenenAtasozu = unitOfWork.Atasozleri.Find(predicate);
            return istenenAtasozu.First();
        }

        public override bool Ekle(Atasozu entity)
        {
            try
            {
                unitOfWork.Atasozleri.Add(entity);
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
                Expression<Func<Atasozu, bool>> predicate = arananAtasozu => arananAtasozu.Id == deyisID;
                IEnumerable<Atasozu> istenenAtasozu = unitOfWork.Atasozleri.Find(predicate);
                return istenenAtasozu.First();
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
            return unitOfWork.Atasozleri.GetAll().ToList();
        }
    }
}
