using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FotoQuestGo.API.Models;

namespace FotoQuestGo.API.Repository
{
    public class QuestRepository : IQuestRepository
    {
        private readonly FotoQuestContext _context;

        public QuestRepository(FotoQuestContext context)
        {
            _context = context;
        }

        public Quest Add(Quest quest)
        {
            _context.Quests.Add(quest);
            return quest;
        }

        public IQueryable<Quest> GetAll()
        {
            return _context.Quests;
        }
    }
}