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
    internal class Navbar
    {
        private Texture2D Texture;
        private Vector2 Position;
        private BuySellButton buySellButton;
        private Lot SelectedLot;

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            Texture = new Texture2D(graphicsDevice, 1, 1);
            Texture.SetData(new Color[] { OwnColors.Black });
            Position = new Vector2(0, 620);
            buySellButton = new BuySellButton();
            buySellButton.Initialize(graphicsDevice);
            SelectedLot = null;
        }

        public void UpdateSelected(Lot lot)
        {
            SelectedLot = lot;
        }

        public Lot GetSelected()
        {
            return SelectedLot;
        }


        public void Update()
        {

        }
        
        public void Draw(SpriteBatch spriteBatch, SpriteFont bigFont)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, 1280, 100), Color.White);
            buySellButton.Draw(spriteBatch, bigFont);
            

            if (SelectedLot != null)
            {
                spriteBatch.DrawString(bigFont, "Value:", new Vector2(Position.X + 200, Position.Y + 30), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                spriteBatch.DrawString(bigFont, SelectedLot.Value.ToString(), new Vector2(Position.X + 280, Position.Y + 30), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            }
            
        }
    }
}
