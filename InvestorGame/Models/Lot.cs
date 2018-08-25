using InvestorGame.Models;
using InvestorGame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorGame.Models
{
    /// <summary>
    /// Land area that can developed to house or office 
    /// </summary>
    internal class Lot : IMapComponents
    {
        public Vector2 Position;
        public Rectangle Area;
        public Texture2D Texture;

        public LotState State;
        //1, 1.5, 2
        public float PriceGroup;
        public int LotVariant;
        public Player Owner;
        
        public int Value;
        public int Investment;

        public bool Selected;

        public void Initialize(GraphicsDevice graphicsDevice, Vector2 position)
        {
            Position = position;
            Area = new Rectangle(Position.ToPoint().X, Position.ToPoint().Y, 100, 100);
            Texture = new Texture2D(graphicsDevice, 1, 1);
            Texture.SetData(new Color[] { OwnColors.Green });
            State = LotState.Empty;
            LotVariant = RandomGenerator.GetInteger(0, 3);
            Owner = Player.AI;
            Value = RandomGenerator.GetInteger(500, 1000);
            Investment = 0;
            Selected = false;
                
        }

        public void Update()
        {

        }        

        public Rectangle CollisionCheck()
        {
            return Area;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font, Texture2D spriteSheet)
        {
            if (Owner == Player.Human)
            {
                spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, 100, 100), OwnColors.DarkGreen);
            }

            if (Selected)
            {
                spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, 100, 100), OwnColors.Black);
            }

            //spriteBatch.Draw(Texture, new Rectangle((int)Position.X+5, (int)Position.Y+5, 90, 90), Color.White);
            spriteBatch.Draw(spriteSheet, new Rectangle((int)Position.X+5, (int)Position.Y+5, 90, 90), new Rectangle(0+(LotVariant * 100), 0, 100, 100), Color.White);
            switch (State)
            {
                case LotState.Empty:
                    break;

                case LotState.House:
                    spriteBatch.Draw(spriteSheet, new Rectangle((int)Position.X + 5, (int)Position.Y + 5, 90, 90), new Rectangle(0, 100, 100, 100), Color.White);
                    break;

                case LotState.Shop:
                    spriteBatch.Draw(spriteSheet, new Rectangle((int)Position.X + 5, (int)Position.Y + 5, 90, 90), new Rectangle(0, 200, 100, 100), Color.White);
                    break;

                case LotState.Office:
                    spriteBatch.Draw(spriteSheet, new Rectangle((int)Position.X + 5, (int)Position.Y + 5, 90, 90), new Rectangle(0, 300, 100, 100), Color.White);
                    break;

                case LotState.Factory:
                    spriteBatch.Draw(spriteSheet, new Rectangle((int)Position.X + 5, (int)Position.Y + 5, 90, 90), new Rectangle(0, 400, 100, 100), Color.White);
                    break;
            }


            spriteBatch.DrawString(font, "$" + Value.ToString(), new Vector2(Position.X + 10, Position.Y + 10), OwnColors.Black, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            

        }        
        
    }
}
