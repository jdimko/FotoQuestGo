using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.ViewModels
{
    public class QuestAddViewModel
    {
        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public DateTime SubmissionTime { get; set; }
    }
}