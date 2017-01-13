using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{
    class PlayerHandler
    {
        IBot[] bots;
        SpriteFont font;
        public PlayerHandler(Texture2D[] botTexture, IBotScript[] aiScripts, SpriteFont _font)
        {
            bots = new IBot[aiScripts.Length];
            for (int i = 0; i < aiScripts.Length; ++i)
            {
                aiScripts[i].Initialize();
                bots[i] = new IBot(botTexture[MathHelper.Clamp(i, 0, botTexture.Length)], aiScripts[i], _font);
            }

            font = _font;

        }

        public void Update(GameTime gTime)
        {
            foreach(IBot bot in bots)
            {
                bot.Update(gTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < bots.Length; ++i)
            {
                bots[i].Draw(spriteBatch);
                
            }
        }

        public void DrawGUI(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < bots.Length; ++i)
            {
                Vector2 stringPos = new Vector2(10 + 300*i, 0);
                spriteBatch.DrawString(font, bots[i].ToString(), stringPos + new Vector2(0, 15),Color.Black);
                spriteBatch.DrawString(font, "Position: " + bots[i].Position.ToPoint().ToString(), stringPos + new Vector2(0, 30), Color.Black);
                spriteBatch.DrawString(font, "Letzter Sprung-Move: " + bots[i].Move.ToPoint().ToString(), stringPos + new Vector2(0, 45), Color.Black);
                spriteBatch.DrawString(font, "Hoechste Distanz: " + bots[i].HighestDistance, stringPos + new Vector2(0, 60), Color.Black);
                spriteBatch.DrawString(font, bots[i].botStatus.ToString(), stringPos + new Vector2(0, 75), Color.Black);

            }
        }
    }
}
