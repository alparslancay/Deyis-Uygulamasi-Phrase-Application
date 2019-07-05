using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Interfaces
{
    public interface IKullaniciIslemleri<TEntity> where TEntity : class
    {
        List<TEntity> TumElemanList();
        TEntity CumleAra(string deyisCumle);
    }
}
