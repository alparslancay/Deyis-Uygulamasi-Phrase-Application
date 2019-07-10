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
    {
        public YansimaIslemleri()
        {
            unitOfWork = new UnitOfWork(new ProjectDbContext("DeyisDB"));
            heapADT = new YansimaHeap();
        }

        public override Yansima CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Expression<Func<Ozdeyis, bool>> predicate = arananYansima => arananYansima.DeyisCumle == deyisCumle;
            IEnumerable<Yansima> istenenYansima = unitOfWork.Yansimalar.Find(predicate);
            return istenenYansima.First();
        }

        public override bool Ekle(Yansima entity)
        {
            try
            {
                unitOfWork.Yansimalar.Add(entity);
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
                Expression<Func<Yansima, bool>> predicate = arananYansima => arananYansima.Id == deyisID;
                IEnumerable<Yansima> istenenYansima = unitOfWork.Yansimalar.Find(predicate);
                return istenenYansima.First();
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
            return unitOfWork.Ozdeyisler.GetAll().ToList();
        }
    }
}
