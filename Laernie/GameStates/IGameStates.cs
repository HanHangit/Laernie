﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{

    enum EGameState
    {
        None = -1,
        Mainmenu,
        PlayState,
        CreateGame,
    }

    interface IGameState
    {

        void Initialize();
        void LoadContent(ContentManager content);
        void UnloadContent();
        void Draw(SpriteBatch spriteBatch);

        void DrawGUI(SpriteBatch spriteBatch);
        EGameState Update(GameTime gTime);

    }
}
