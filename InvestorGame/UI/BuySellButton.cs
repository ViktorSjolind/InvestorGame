using InvestorGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorGame.UI
{
    internal class BuySellButton
    {
        private Texture2D Texture;
        private Texture2D TextureWhite;
        private Vector2 Position;
        public BuySellButtonState State;
        public Rectangle Area;

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            Texture = new Texture2D(graphicsDevice, 1, 1);
            Texture.SetData(new Color[] { OwnColors.Black });

            TextureWhite = new Texture2D(graphicsDevice, 1, 1);
            TextureWhite.SetData(new Color[] { OwnColors.White });

            Position = new Vector2(0, 620);
            State = BuySellButtonState.None;
            Area = new Rectangle(Position.ToPoint().X+190, Position.ToPoint().Y+30, 62, 35);
        }


        public void Update()
        {

        }

        public Rectangle CollisionCheck()
        {
            return Area;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont bigFont)
        {
            

            //Font size is compiled as 36px, scaled down for better quality
            if (State == BuySellButtonState.None)
            {

            }
            if (State == BuySellButtonState.Buy)
            {
                //Highlight button
                spriteBatch.Draw(TextureWhite, Area, OwnColors.White);
                spriteBatch.Draw(Texture, new Rectangle(Area.X + 2, Area.Y + 2, Area.Width - 4, Area.Height - 4), OwnColors.White);
                spriteBatch.DrawString(bigFont, "Buy", new Vector2(200, 655), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            }
            if (State == BuySellButtonState.Sell)
            {
                //Highlight button
                spriteBatch.Draw(TextureWhite, Area, OwnColors.White);
                spriteBatch.Draw(Texture, new Rectangle(Area.X + 2, Area.Y + 2, Area.Width - 4, Area.Height - 4), OwnColors.White);
                spriteBatch.DrawString(bigFont, "Sell", new Vector2(200, 655), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            }
            
        }
    }
}
