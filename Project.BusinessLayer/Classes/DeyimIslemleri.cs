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
    public class DeyimIslemleri : DeyisIslemleriADT<Deyim>
    {
        public DeyimIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new DeyimHeap();
        }

        public override Deyim CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Expression<Func<Deyim, bool>> predicate = arananDeyim => arananDeyim.DeyisCumle == deyisCumle;
            IEnumerable<Deyim> istenenDeyim = unitOfWork.Deyimler.Find(predicate);
            return istenenDeyim.First();
        }

        public override bool Ekle(Deyim entity)
        {
            try
            {
                unitOfWork.Deyimler.Add(entity);
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
                Expression<Func<Deyim, bool>> predicate = arananDeyim => arananDeyim.Id == deyisID;
                IEnumerable<Deyim> istenenDeyim = unitOfWork.Deyimler.Find(predicate);
                return istenenDeyim.First();
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
            return unitOfWork.Deyimler.GetAll().ToList();
        }
    }
}
