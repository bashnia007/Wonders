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
        int Id { get; set; }
        string Title { get; set; }
        int Epoch { get; set; }
        int MinPlayers { get; set; }
        int Wood { get; set; }
        int Stone { get; set; }
        int Gold { get; set; }
        int Brick { get; set; }
        int Papirus { get; set; }
        int Glass { get; set; }
        int Cloth { get; set; }
    }
}
