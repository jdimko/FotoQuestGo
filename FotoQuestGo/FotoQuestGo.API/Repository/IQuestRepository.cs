using FotoQuestGo.API.Quest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Quest.Repository
{
    public interface IQuestRepository
    {
        Common.Models.Quest Add(Common.Models.Quest quest);

        IQueryable<Common.Models.Quest> GetAll();

        //TODO: Add other methods
    }
}