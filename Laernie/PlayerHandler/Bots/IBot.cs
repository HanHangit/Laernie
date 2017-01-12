using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{
    struct MoveInformation
    {
        public Vector2 move { get; private set; }
        public float speed { get; private set; }

        /// <summary>
        /// Erstellt ein Paket mit den benötigten BewegungsInformationen
        /// </summary>
        /// <param name="_move">Die "Abschuss"-Richtung</param>
        /// <param name="Geschwindigkeit">Die Kraft des "Abschuss". Range[0,100]</param>
        public MoveInformation(Vector2 _move, float _speed)
        {
            move = _move;
            speed = MathHelper.Clamp(_speed, 0, 100) / 10f;
        }


    }


    enum EBotStatus
    {
        WaitForInput,
        Flying,
        Dead,
        Idle,
        Finish
    }

    class IBot
    {
        #region MemberVariables

        Texture2D botTexture;
        Vector2  position, move, forceMove;
        IBotScript aiScript;
        double timer;
        EBotStatus afterIdle;
        SpriteFont font;
        float highestDistance;

        #endregion

        #region Properties
        public EBotStatus botStatus { get; private set; }
        public Vector2 Position { get { return position; } }
        public Vector2 Move { get { return forceMove; } }
        public float HighestDistance { get { return highestDistance; } }
        #endregion

        public IBot(Texture2D _botTexture, IBotScript _aiScript, SpriteFont _font)
        {
            botTexture = _botTexture;
            position = GameInformation.Instance.mapOptions.startPosition;
            botStatus = EBotStatus.WaitForInput;
            aiScript = _aiScript;
            font = _font;
        }


        //Setzt die Kraft aus der MoveInformation, dem Bot hinzu
        void SetForce(MoveInformation moveInf)
        {
            move = Vector2.Normalize(moveInf.move);
            move *= moveInf.speed;
            forceMove = move;
            botStatus = EBotStatus.Flying;
            while (!GameStuff.Instance.tileMap.Walkable(position + new Vector2(GameInformation.Instance.mapOptions.tileSize / 2, GameInformation.Instance.mapOptions.tileSize / 2) + move))
            {
                position.Y -= 1;
            }
        }

        void CalculatePhysic(GameTime gTime)
        {
            if(GameStuff.Instance.tileMap.OutOfMap(position + new Vector2(GameInformation.Instance.mapOptions.tileSize) + move))
            {
                botStatus = EBotStatus.Dead;
                return;
            }
            if (!GameStuff.Instance.tileMap.Walkable(position + new Vector2(GameInformation.Instance.mapOptions.tileSize / 2, GameInformation.Instance.mapOptions.tileSize / 2) + move))
            {
                while (GameStuff.Instance.tileMap.Walkable(position + new Vector2(GameInformation.Instance.mapOptions.tileSize / 2, GameInformation.Instance.mapOptions.tileSize / 2)))
                {
                    position.Y += 1;
                }
                aiScript.OnReachPlattform(this);
                botStatus = EBotStatus.WaitForInput;
                move = new Vector2(0, 0);
                return;

            }
            position += move;
            move += GameInformation.Instance.mapOptions.gravity;
            if (highestDistance < position.X - GameInformation.Instance.mapOptions.startPosition.X)
                highestDistance = position.X - GameInformation.Instance.mapOptions.startPosition
                    .X;
            aiScript.OnFly(this);

        }

        void ResetPosition()
        {
            aiScript.OnDead(this);
            position = GameInformation.Instance.mapOptions.startPosition;
            botStatus = EBotStatus.Idle;
            afterIdle = EBotStatus.WaitForInput;
        }

        void Idle(GameTime gTime)
        {
            timer += gTime.ElapsedGameTime.TotalSeconds;

            if (timer >= GameInformation.Instance.botOptions.IdleTime)
            {
                timer = 0;
                botStatus = afterIdle;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(botTexture, position, Color.White);
            spriteBatch.DrawString(font, ToString(), position - new Vector2(35,35), Color.Red);
        }
        public void Update(GameTime gTime)
        {
            switch (botStatus)
            {
                case EBotStatus.WaitForInput:
                    SetForce(aiScript.Think(this));
                    break;
                case EBotStatus.Flying:
                    CalculatePhysic(gTime);
                    break;
                case EBotStatus.Dead:
                    ResetPosition();
                    break;
                case EBotStatus.Idle:
                    Idle(gTime);
                    break;
            }
        }
        public override string ToString()
        {
            return aiScript.ToString();
        }

    }
}
