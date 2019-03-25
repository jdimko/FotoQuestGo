using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Models
{
    public class Answer
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public virtual Question Question { get; set; }

        public int QuestID { get; set; }

        public virtual Quest Quest { get; set; }

        public string Text { get; set; }
    }
}