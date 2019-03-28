using AutoMapper;
using FotoQuestGo.Common.ViewModels;

namespace FotoQuestGo.Common.AutoMapperProfiles
{
    public class QuestProfile : Profile
    {
        public QuestProfile()
        {
            CreateMap<QuestAddViewModel, Models.Quest>();
        }
    }
}