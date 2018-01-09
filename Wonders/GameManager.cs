using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders
{
    public class GameManager
    {
        public List<Player> Players { get; set; }

        public void ProvideWonders()
        {
            var wondersList = Enum.GetValues(typeof(WonderType)).Cast<WonderType>().ToList();
            var rnd = new Random();
            foreach (var player in Players)
            {
                var selectedWonder = rnd.Next(wondersList.Count);
                var selectedSide = rnd.Next(2);

                var wonder = new Wonder(wondersList[selectedWonder], selectedSide);
                player.Wonder = wonder;
                wondersList.RemoveAt(selectedWonder);
            }
        }
    }
}
