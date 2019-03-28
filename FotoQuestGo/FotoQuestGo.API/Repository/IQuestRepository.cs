using System.Linq;

namespace FotoQuestGo.API.Quest.Repository
{
    public interface IQuestRepository
    {
        Common.Models.Quest Add(Common.Models.Quest quest);

        IQueryable<Common.Models.Quest> GetAll();

        //TODO: Add other methods
    }
}