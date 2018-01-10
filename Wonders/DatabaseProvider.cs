using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonders
{
    public static class DatabaseProvider
    {
        public static List<Card> GetCards(int epoch)
        {
            var result = new List<Card>();
            for (int i = 0; i < 49; i++)
            {
                result.Add(new Card());
            }
            return result;
        }
    }
}
