using FotoQuestGo.API.Quest.Context;
using System.Linq;

namespace FotoQuestGo.API.Quest.Repository
{
    public class QuestRepository : IQuestRepository
    {
        private readonly FotoQuestContext _context;

        public QuestRepository(FotoQuestContext context)
        {
            _context = context;
        }

        public Common.Models.Quest Add(Common.Models.Quest quest)
        {
            _context.Quests.Add(quest);
            return quest;
        }

        public IQueryable<Common.Models.Quest> GetAll()
        {
            return _context.Quests;
        }
    }
}