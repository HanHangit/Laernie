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
    class PlayState : IGameState
    {
        PlayerHandler playerHandler;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: GameStuff.Instance.camera.GetViewMatrix());

            GameStuff.Instance.tileMap.Draw(spriteBatch);
            playerHandler.Draw(spriteBatch);

            spriteBatch.End();
        }

        public void DrawGUI(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            playerHandler.DrawGUI(spriteBatch);

            spriteBatch.End();
        }

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager content)
        {
            GameStuff.Instance.tileMap = new TileMap(
                new[] { content.Load<Texture2D>("Map/Sky32"), content.Load<Texture2D>("Map/Block32") }, 
                content.Load<Texture2D>("Map/Map01"), 
                GameInformation.Instance.mapOptions.tileSize);

            GameStuff.Instance.camera = new Camera();

            playerHandler = new PlayerHandler(
                new[] { content.Load<Texture2D>("Player/Player_blue32"), content.Load<Texture2D>("Player/Player_green32"), content.Load<Texture2D>("Player/Player_red32"), content.Load<Texture2D>("Player/Player_yellow32") },
                new IBotScript[] { new SimpleScript(), new BetterScript(), new BestOfScripts() }, content.Load<SpriteFont>("SimpleFont"));
        }

        public void UnloadContent()
        {
        }

        public EGameState Update(GameTime gTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                return EGameState.Mainmenu;

            GameStuff.Instance.tileMap.Update(gTime);
            playerHandler.Update(gTime);

            return EGameState.PlayState;
        }
    }
}
