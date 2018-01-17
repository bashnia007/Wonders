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
        public DbSet<DbCard> DbCards { get; set; }
    }
}
