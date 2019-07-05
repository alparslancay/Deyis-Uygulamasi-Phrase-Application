using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryAtasozu Atasozleri { get; }
        IRepositoryDeyim Deyimler { get; }
        IRepositoryDolaylama Dolaylamalar { get; }
        IRepositoryIkileme Ikilemeler { get; }
        IRepositoryOzdeyis Ozdeyisler { get; }
        IRepositoryYansima Yansimalar { get; }
        int Complete();
    }
}
