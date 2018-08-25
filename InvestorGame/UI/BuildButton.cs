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
    internal class BuildButton
    {

        private Texture2D Texture;
        private Texture2D TextureWhite;
        private Vector2 Position;
        public BuildButtonState State;
        public Rectangle Area;

        public void Initialize(GraphicsDevice graphicsDevice, BuildButtonState state, Vector2 position)
        {
            Texture = new Texture2D(graphicsDevice, 1, 1);
            Texture.SetData(new Color[] { OwnColors.Black });

            TextureWhite = new Texture2D(graphicsDevice, 1, 1);
            TextureWhite.SetData(new Color[] { OwnColors.White });

            Position = position;
            State = state;
            Area = new Rectangle(Position.ToPoint().X+10, Position.ToPoint().Y+10, 80, 80);
        }


        public void Update()
        {

        }

        public Rectangle CollisionCheck()
        {
            return Area;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont bigFont, Texture2D spriteSheet)
        {


            //Font size is compiled as 36px, scaled down for better quality
            if (State == BuildButtonState.House)
            {
                //Highlight button
                spriteBatch.Draw(TextureWhite, Area, OwnColors.Red);
                spriteBatch.Draw(spriteSheet, new Rectangle((int)Position.X, (int)Position.Y, 100, 100), new Rectangle(0, 500, 100, 100), Color.White);

            }
            
            if (State == BuildButtonState.Shop)
            {
                //Highlight button
                spriteBatch.Draw(TextureWhite, Area, OwnColors.Red);
                spriteBatch.Draw(spriteSheet, new Rectangle((int)Position.X, (int)Position.Y, 100, 100), new Rectangle(100, 500, 100, 100), Color.White);
                
            }

            if (State == BuildButtonState.Office)
            {
                //Highlight button
                spriteBatch.Draw(TextureWhite, Area, OwnColors.Red);
                spriteBatch.Draw(spriteSheet, new Rectangle((int)Position.X, (int)Position.Y, 100, 100), new Rectangle(300, 500, 100, 100), Color.White);
            }

            /*
            if (State == BuildButtonState.Factory)
            {
                //Highlight button
                spriteBatch.Draw(TextureWhite, Area, OwnColors.White);
                spriteBatch.Draw(Texture, new Rectangle(Area.X + 2, Area.Y + 2, Area.Width - 4, Area.Height - 4), OwnColors.White);
                spriteBatch.DrawString(bigFont, "Sell", new Vector2(100, 655), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            }
            */
        }
    }
}
