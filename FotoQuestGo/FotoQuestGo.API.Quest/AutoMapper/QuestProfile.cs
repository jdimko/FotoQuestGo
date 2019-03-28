using AutoMapper;
using FotoQuestGo.API.Quest.ViewModels;

namespace FotoQuestGo.API.Quest.AutoMapper
{
    public class QuestProfile : Profile
    {
        public QuestProfile()
        {
            CreateMap<QuestAddViewModel, Common.Models.Quest>();
        }
    }
}