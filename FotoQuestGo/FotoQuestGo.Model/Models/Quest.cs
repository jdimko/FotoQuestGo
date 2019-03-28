using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Common.Models
{
    public class Quest
    {
        public int ID { get; set; }

        //We can use Spatial data-types
        public string Longitude { get; set; }

        //We can use Spatial data-types
        public string Latitude { get; set; }

        public DateTime SubmissionTime { get; set; }

        public virtual ICollection<Foto> Fotos { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}