using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FotoQuestGo.API.Common.Models;
using FotoQuestGo.API.Quest.Context;

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