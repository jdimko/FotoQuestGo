using AutoMapper;
using FotoQuestGo.API.Quest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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