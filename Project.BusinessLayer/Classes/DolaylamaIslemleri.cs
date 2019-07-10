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
    public class DolaylamaIslemleri : DeyisIslemleriADT<Dolaylama>
    {
         public DolaylamaIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new DolaylamaHeap();
        }

        public override Dolaylama CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Expression<Func<Dolaylama, bool>> predicate = arananDolaylama => arananDolaylama.DeyisCumle == deyisCumle;
            IEnumerable<Dolaylama> istenenDolaylama = unitOfWork.Dolaylamalar.Find(predicate);
            return istenenDolaylama.First();
        }

        public override bool Ekle(Dolaylama entity)
        {
            try
            {
                unitOfWork.Dolaylamalar.Add(entity);
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
                Expression<Func<Dolaylama, bool>> predicate = arananDolaylama => arananDolaylama.Id == deyisID;
                IEnumerable<Dolaylama> istenenDolaylama = unitOfWork.Dolaylamalar.Find(predicate);
                return istenenDolaylama.First();
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
            return unitOfWork.Dolaylamalar.GetAll().ToList();
        }
    }
}
