using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{
    class TileMap
    {
        Tile[,] tileMap;
        int tileSize;

        public TileMap(Texture2D[] textures, Texture2D bitMap, int _tileSize)
        {
            tileSize = _tileSize;
            tileMap = new Tile[bitMap.Width, bitMap.Height];

            BuildMap(textures, bitMap);
        }

        private void BuildMap(Texture2D[] textures, Texture2D bitMap)
        {
            Color[] colores = new Color[bitMap.Width * bitMap.Height];

            bitMap.GetData(colores);

            for (int y = 0; y < tileMap.GetLength(1); y++)
            {
                for (int x = 0; x < tileMap.GetLength(0); x++)
                {
                    if (colores[y * tileMap.GetLength(0) + x] == Color.White)
                    {
                        // Grass
                        tileMap[x, y] = new Tile(textures[0], new Vector2(x * tileSize, y * tileSize), ETile.Sky);
                    }
                    else if(colores[y * tileMap.GetLength(0) + x] == new Color(34,177,76))
                    {
                        //StartPosition
                        tileMap[x, y] = new Tile(textures[0], new Vector2(x * tileSize, y * tileSize), ETile.Sky);
                        GameInformation.Instance.mapOptions.startPosition = new Vector2(x * tileSize, y * tileSize);
                    }
                    else if (colores[y * tileMap.GetLength(0) + x] == new Color(237,28,36))
                    {
                        //EndPosition
                        tileMap[x, y] = new Tile(textures[0], new Vector2(x * tileSize, y * tileSize), ETile.Sky);
                        GameInformation.Instance.mapOptions.endPosition = new Vector2(x * tileSize, y * tileSize);
                    }
                    else
                    {
                        // Stein
                        tileMap[x, y] = new Tile(textures[1], new Vector2(x * tileSize, y * tileSize), ETile.Wall);
                    }
                }
            }
        }

        public bool Walkable(Vector2 currentPosition)
        {
            try
            {
                return tileMap[(int)(currentPosition.X / tileSize), (int)(currentPosition.Y / tileSize)].Walkable();
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public bool OutOfMap(Vector2 currentPosition)
        {
            try
            {
                tileMap[(int)(currentPosition.X / tileSize), (int)(currentPosition.Y / tileSize)].Walkable();
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < tileMap.GetLength(1); y++)
            {
                for (int x = 0; x < tileMap.GetLength(0); x++)
                {
                    tileMap[x, y].Draw(spriteBatch);
                }
            }
        }
    }
}
