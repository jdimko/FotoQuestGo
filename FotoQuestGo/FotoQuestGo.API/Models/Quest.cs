using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Models
{
    public class Quest
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime SubmissionTime { get; set; }
    }
}