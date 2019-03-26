using AutoMapper;
using FotoQuestGo.API.Models;
using FotoQuestGo.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.AutoMapper
{
    public class QuestProfile : Profile
    {
        public QuestProfile()
        {
            CreateMap<QuestAddViewModel, Quest>();
        }
    }
}