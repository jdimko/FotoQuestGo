using AutoMapper;

namespace FotoQuestGo.API.Quest.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void InitMaps()
        {
            Mapper.Reset();
            Mapper.Initialize(x =>
            {
                x.AddProfiles(new[] {
                    typeof(QuestProfile),
                });
            });
        }
    }
}