using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders.Cards
{
    public interface ICard
    {
        string Title { get; set; }
        int Epoch { get; set; }
        Dictionary<Resource, int> Price { get; set; }
        int MaxPlayers { get; set; }
    }
}
