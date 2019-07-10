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
            heapADT = new IkilemeHeap();
        }

        public override Ikileme CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Expression<Func<Ikileme, bool>> predicate = arananIkileme => arananIkileme.DeyisCumle == deyisCumle;
            IEnumerable<Ikileme> istenenIkileme = unitOfWork.Ikilemeler.Find(predicate);
            return istenenIkileme.First();
        }

        public override bool Ekle(Ikileme entity)
        {
            try
            {
                unitOfWork.Ikilemeler.Add(entity);
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
                Expression<Func<Ikileme, bool>> predicate = arananIkileme => arananIkileme.Id == deyisID;
                IEnumerable<Ikileme> istenenIkileme = unitOfWork.Ikilemeler.Find(predicate);
                return istenenIkileme.First();
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
             return unitOfWork.Ikilemeler.GetAll().ToList();
        }
    }
}
