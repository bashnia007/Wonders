using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Cards;

namespace Wonders.Database
{
    public class WondersContext : DbContext
    {
        public WondersContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<MilitaryCard> MilitaryCards { get; set; }
        public DbSet<Card> CultureCards { get; set; }
        public DbSet<ResourceCard> ResourceCards { get; set; }
        public DbSet<ScienceCard> ScienceCards { get; set; }
    }
}
