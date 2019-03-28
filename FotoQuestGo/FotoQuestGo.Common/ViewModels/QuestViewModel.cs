using System;
using System.Collections.Generic;

namespace FotoQuestGo.Common.ViewModels
{
    public class QuestAddViewModel
    {
        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public DateTime SubmissionTime { get; set; }

        public ICollection<string> FotoURIs { get; set; }
    }
}