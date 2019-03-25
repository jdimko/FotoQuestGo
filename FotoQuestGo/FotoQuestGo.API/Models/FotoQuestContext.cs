using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoQuestGo.API.Models
{
    public class FotoQuestContext : DbContext
    {
        public FotoQuestContext(DbContextOptions<FotoQuestContext> options) : base(options)
        {
        }

        public DbSet<Quest> Quests { get; set; }
    }
}