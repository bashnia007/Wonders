﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonders.Enums;

namespace Wonders
{
    public class Decision
    {
        public Card SelectedCard { get; set; }
        public DecisionType DecisionType { get; set; }
    }
}