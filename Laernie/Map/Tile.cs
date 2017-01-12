using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{
    enum ETile
    {
        Wall,
        Sky
    }
    class Tile
    {
        Vector2 position;
        Texture2D texture;
        ETile type;

        public Tile(Texture2D _texture, Vector2 _position, ETile _id)
        {
            texture = _texture;
            position = _position;
            type = _id;
        }

        public void Update(GameTime gameTime)
        {

        }

        public bool Walkable()
        {
            return type != ETile.Wall;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
