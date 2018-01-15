using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Cards;
using Wonders.Database;

namespace Wonders
{
    public static class DatabaseProvider
    {
        public static List<ICard> GetCards(int epoch)
        {
            var result = new List<ICard>();
            for (int i = 0; i < 49; i++)
            {
                //result.Add(new MilitaryCard());
            }
            return result;
        }

        public static void ReadCards()
        {
            using (var db = new WondersContext())
            {
                db.MilitaryCards.Load();
                var militaryCards = db.MilitaryCards.Local.ToBindingList();

                foreach (var militaryCard in militaryCards)
                {
                        
                }
            }
        }

        public static void AddMilitaryCards(MilitaryCard dbCard)
        {
            using (var db = new WondersContext())
            {
                db.MilitaryCards.Add(dbCard);
                db.SaveChanges();
            }
        }
    }
}
