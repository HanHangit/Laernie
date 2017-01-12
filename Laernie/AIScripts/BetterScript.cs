﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{
    class BetterScript : IBotScript
    {
        public void OnDead(IBot bot)
        {
        }

        public void OnFly(IBot bot)
        {
        }

        public void OnReachPlattform(IBot bot)
        {
        }

        public MoveInformation Think(IBot bot)
        {
            return new MoveInformation(new Vector2(1, -1), 70);
        }

        public override string ToString()
        {
            return "BetterScript";
        }
    }
}
