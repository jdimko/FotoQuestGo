using FotoQuestGo.API.Quest.Context;
using FotoQuestGo.API.Quest.Repository;
using System;

namespace FotoQuestGo.API.Quest.UnitOfWork
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