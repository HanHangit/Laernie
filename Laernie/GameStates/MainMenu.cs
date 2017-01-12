using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Laernie
{
    class MainMenu : IGameState
    {

        SpriteFont font;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font, "Druecke B um zu Starten!", new Vector2(100, 100), Color.Red);

            spriteBatch.End();
        }

        public void DrawGUI(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();



            spriteBatch.End();
        }

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("SimpleFont");
        }

        public void UnloadContent()
        {
        }

        public EGameState Update(GameTime gTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.B))
                return EGameState.PlayState;

            return EGameState.Mainmenu;
        }
    }
}
