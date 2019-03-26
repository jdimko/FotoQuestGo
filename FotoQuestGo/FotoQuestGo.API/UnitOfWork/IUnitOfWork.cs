using FotoQuestGo.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.UnitOfWork
{
    public interface IUnitOfWork
    {
        IQuestRepository QuestRepository { get; }

        void Save();

        void Dispose();
    }
}