using Project.BusinessLayer.Abstract_Classes;
using Project.BusinessLayer.Interfaces;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Classes
{
    public class FactoryYetkiliIslem
    {      
        public IYetkiliIslemleri<Atasozu> AtasozuIslemiAl()
        {
            return new AtasozuIslemleri();
        }

        public IYetkiliIslemleri<Deyim> DeyimIslemiAl()
        {
            return new DeyimIslemleri();
        }

        public IYetkiliIslemleri<Dolaylama> DolaylamaIslemiAl()
        {
            return new DolaylamaIslemleri();
        }

        public IYetkiliIslemleri<Ikileme> IkilemeIslemiAl()
        {
            return new IkilemeIslemleri();
        }

        public IYetkiliIslemleri<Ozdeyis> OzdeyisIslemiAl()
        {
            return new OzdeyisIslemleri();
        }

        public IYetkiliIslemleri<Yansima> YansimaIslemiAl()
        {
            return new YansimaIslemleri();
        }
    }
}
