using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{

    class SimpleScript : IBotScript
    {

        MoveInformation move;

        public void Initialize()
        {
            move = new MoveInformation(new Vector2(1, -1), 40);
        }

        public void OnDead(IBot bot)
        {
            if (move.Speed < 100)
                move = new MoveInformation(move.Move, move.Speed * 10f + 1);
                
        }

        public void OnFly(IBot bot)
        {

        }

        public void OnReachPlattform(IBot bot)
        {

        }

        public MoveInformation Think(IBot bot)
        {
            return move;
        }

        public override string ToString()
        {
            return "SimpleBot";
        }
    }
}
