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
        private Vector2 Position;
        public BuySellButtonState State;

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            Texture = new Texture2D(graphicsDevice, 1, 1);
            Texture.SetData(new Color[] { OwnColors.Black });
            Position = new Vector2(0, 620);
            State = BuySellButtonState.None;
        }


        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont bigFont)
        {
            //Font size is compiled as 36px, scaled down for better quality
            if(State == BuySellButtonState.None)
            {

            }
            if (State == BuySellButtonState.Buy)
            {
                spriteBatch.DrawString(bigFont, "Buy:", new Vector2(100, 650), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            }
            if (State == BuySellButtonState.Sell)
            {
                spriteBatch.DrawString(bigFont, "Sell:", new Vector2(100, 650), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            }
            
        }
    }
}
