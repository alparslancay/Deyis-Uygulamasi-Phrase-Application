using Project.BusinessLayer.Abstract_Classes;
using Project.BusinessLayer.Classes.HeapClasses;
using Project.DataAccessLayer.Classes;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Classes
{
    public class OzdeyisIslemleri : DeyisIslemleriADT<Ozdeyis>
    {
        public OzdeyisIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new OzdeyisHeap();
        }

        public override Ozdeyis CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Expression<Func<Ozdeyis, bool>> predicate = arananOzdeyis => arananOzdeyis.DeyisCumle == deyisCumle;
            IEnumerable<Ozdeyis> istenenOzdeyis = unitOfWork.Ozdeyisler.Find(predicate);
            return istenenOzdeyis.First();
        }

        public override bool Ekle(Ozdeyis entity)
        {
            try
            {
                unitOfWork.Ozdeyisler.Add(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Guncelle(Ozdeyis entity)
        {
            try
            {
                Ozdeyis eskiOzdeyis = new Ozdeyis();
                eskiOzdeyis = unitOfWork.Ozdeyisler.Get(entity.Id);
                eskiOzdeyis = entity;
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override Ozdeyis IDAra(int deyisID)
        {
            try
            {
                Expression<Func<Ozdeyis, bool>> predicate = arananOzdeyis => arananOzdeyis.Id == deyisID;
                IEnumerable<Ozdeyis> istenenOzdeyis = unitOfWork.Ozdeyisler.Find(predicate);
                return istenenOzdeyis.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool Sil(Ozdeyis entity)
        {
            try
            {
                unitOfWork.Ozdeyisler.Remove(entity);
                unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override List<Ozdeyis> TumElemanList()
        {
            return unitOfWork.Ozdeyisler.GetAll().ToList();
        }
    }
}
