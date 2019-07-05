using Project.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectDbContext m_dbContext;

        public IRepositoryAtasozu Atasozleri { get; private set; }

        public IRepositoryDeyim Deyimler { get; private set; }

        public IRepositoryDolaylama Dolaylamalar { get; private set; }

        public IRepositoryIkileme Ikilemeler { get; private set; }

        public IRepositoryOzdeyis Ozdeyisler { get; private set; }

        public IRepositoryYansima Yansimalar { get; private set; }

        public UnitOfWork(ProjectDbContext dbContext)
        {
            m_dbContext = dbContext;
            Atasozleri = new RepositoryAtasozu(m_dbContext);
            Deyimler = new RepositoryDeyim(m_dbContext);
            Dolaylamalar = new RepositoryDolaylama(m_dbContext);
            Ikilemeler = new RepositoryIkileme(m_dbContext);
            Ozdeyisler = new RepositoryOzdeyis(m_dbContext);
            Yansimalar = new RepositoryYansima(m_dbContext);
        }

        public int Complete()
        {
            return m_dbContext.SaveChanges();

        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    m_dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
