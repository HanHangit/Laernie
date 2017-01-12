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
        public void OnDead(IBot bot)
        {
            Console.WriteLine("On Dead!");
        }

        public void OnFly(IBot bot)
        {
            //Console.WriteLine("On Fly!");
        }

        public void OnReachPlattform(IBot bot)
        {
            Console.WriteLine("OnPlattform");
        }

        public MoveInformation Think(IBot bot)
        {
            return new MoveInformation(new Vector2(1, -1), 50);
        }

        public override string ToString()
        {
            return "SimpleBot";
        }
    }
}
