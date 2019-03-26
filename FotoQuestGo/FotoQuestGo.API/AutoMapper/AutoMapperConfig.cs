using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void InitMaps()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfiles(new[] {
                    typeof(QuestProfile),
                });
            });
        }
    }
}