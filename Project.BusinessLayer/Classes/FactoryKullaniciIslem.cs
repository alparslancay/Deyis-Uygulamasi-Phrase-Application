using Project.BusinessLayer.Interfaces;
using Project.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Classes
{
    public class FactoryKullaniciIslem
    {
        public IKullaniciIslemleri<Atasozu> AtasozuIslemiAl()
        {
            return new AtasozuIslemleri();
        }

        public IKullaniciIslemleri<Deyim> DeyimIslemiAl()
        {
            return new DeyimIslemleri();
        }

        public IKullaniciIslemleri<Dolaylama> DolaylamaIslemiAl()
        {
            return new DolaylamaIslemleri();
        }

        public IKullaniciIslemleri<Ikileme> IkilemeIslemiAl()
        {
            return new IkilemeIslemleri();
        }

        public IKullaniciIslemleri<Ozdeyis> OzdeyisIslemiAl()
        {
            return new OzdeyisIslemleri();
        }

        public IKullaniciIslemleri<Yansima> YansimaIslemiAl()
        {
            return new YansimaIslemleri();
        }
    }
}
