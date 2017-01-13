using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{
    class GraphicOptions
    {
        public int viewX = 1280;
        public int viewY = 720;

    }

    class MapOptions
    {
        public int tileSize = 32;
        public Vector2 gravity = new Vector2(0, 0.1f);
        public Vector2 startPosition = new Vector2(0, 0);
        public Vector2 endPosition = new Vector2(1000, 100);
    }

    class BotOptions
    {
        public float IdleTime = 1;
    }

    class GameInformation
    {
        public GraphicOptions graphicOptions = new GraphicOptions();
        public MapOptions mapOptions = new MapOptions();
        public BotOptions botOptions = new BotOptions();

        static GameInformation instance;
        public static GameInformation Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameInformation();

                return instance;
            }
        }

    }
}
