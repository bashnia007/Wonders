using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders
{
    public class MilitaryBadge
    {
        public MilitaryBadgeType BadgeType { get; set; }

        public int Points
        {
            get
            {
                switch (BadgeType)
                {
                    case MilitaryBadgeType.VictoryFirstEpoch: return 1;
                    case MilitaryBadgeType.VictorySecondEpoch: return 3;
                    case MilitaryBadgeType.VictoryThirdEpoch: return 5;
                    default: return -1;
                }
            }
        }

        public MilitaryBadge(MilitaryBadgeType type)
        {
            BadgeType = type;
        }
    }
}
