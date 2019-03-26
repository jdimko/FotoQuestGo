using FotoQuestGo.API.Models;
using FotoQuestGo.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private FotoQuestContext _context;

        public UnitOfWork(FotoQuestContext context)
        {
            _context = context;
        }

        private IQuestRepository _questRepository;

        public virtual IQuestRepository QuestRepository
        {
            get
            {
                if (_questRepository == null)
                {
                    _questRepository = new QuestRepository(_context);
                }
                return _questRepository;
            }
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}