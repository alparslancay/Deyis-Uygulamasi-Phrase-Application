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
            heapADT = new OzdeyisHeap(unitOfWork.Ozdeyisler.GetAll().ToList());
        }

        public override Ozdeyis CumleAra(string deyisCumle)
        {
            deyisCumle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(deyisCumle);
            deyisCumle = deyisCumle.ToUpper();
            Predicate<Ozdeyis> predicate = arananOzdeyis => arananOzdeyis.DeyisCumle == deyisCumle;
            return heapADT.Ara(predicate);
        }

        public override bool Ekle(Ozdeyis entity)
        {
            try
            {
                unitOfWork.Ozdeyisler.Add(entity);
                heapADT.Ekle(entity);
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
                heapADT.Guncelle(entity);
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
                Predicate<Ozdeyis> predicate = arananOzdeyis => arananOzdeyis.Id == deyisID;
                return heapADT.Ara(predicate);
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
                heapADT.Sil(entity);
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
            return heapADT.TumElemanList();
        }
    }
}
