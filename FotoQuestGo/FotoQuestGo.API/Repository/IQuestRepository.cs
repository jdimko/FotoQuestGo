using FotoQuestGo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Repository
{
    public interface IQuestRepository
    {
        Quest Add(Quest quest);

        IQueryable<Quest> GetAll();

        //TODO: Add other methods
    }
}