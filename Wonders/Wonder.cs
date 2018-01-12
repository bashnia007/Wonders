using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders
{
    public class Wonder
    {
        public WonderType Name { get; set; }
        public int Side { get; set; }
        public Resource Resource { get; set; }

        public Wonder(WonderType name, int side)
        {
            Name = name;
            Side = side;
        }
    }
}
