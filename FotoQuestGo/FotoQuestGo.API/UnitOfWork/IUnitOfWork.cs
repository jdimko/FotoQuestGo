using FotoQuestGo.API.Quest.Repository;

namespace FotoQuestGo.API.Quest.UnitOfWork
{
    public interface IUnitOfWork
    {
        IQuestRepository QuestRepository { get; }

        void Save();

        void Dispose();
    }
}