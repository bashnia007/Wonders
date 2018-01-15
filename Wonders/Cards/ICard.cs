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
    }
}
