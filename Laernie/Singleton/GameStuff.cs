using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{
    class GameStuff
    {
        public Camera camera;
        public TileMap tileMap;
        static GameStuff instance;
        public static GameStuff Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameStuff();

                return instance;
            }
        }
    }
}
