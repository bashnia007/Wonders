using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Cards;

namespace Wonders
{
    public static class DatabaseProvider
    {
        public static List<ICard> GetCards(int epoch)
        {
            var result = new List<ICard>();
            for (int i = 0; i < 49; i++)
            {
                result.Add(new MilitaryCard());
            }
            return result;
        }
    }
}
