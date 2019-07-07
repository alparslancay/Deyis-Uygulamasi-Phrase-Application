using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLayer.Interfaces
{
    public interface IYetkiliIslemleri<TEntity> : IKullaniciIslemleri<TEntity> where TEntity : class
    {
        bool Guncelle(TEntity entity);
        bool Sil(TEntity entity);
        TEntity IDAra(int deyisID);
        bool Ekle(TEntity entity);
    }
}
