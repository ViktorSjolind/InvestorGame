using InvestorGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorGame.UI
{
    internal class Notification
    {
        private GraphicsDevice Graphics;
        private Texture2D TextureWhite;
        private float Duration;
        private bool Display;
        private string Text;

        public Notification(GraphicsDevice graphicsDevice)
        {
            Graphics = graphicsDevice;
            TextureWhite = new Texture2D(graphicsDevice, 1, 1);
            TextureWhite.SetData(new Color[] { OwnColors.White });
        }

        public void Update(GameTime gameTime)
        {
            float timePassed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Duration -= timePassed;
            if(Duration <= 0)
            {
                Display = false;
            }
        }

        public void DisplayNotification(string text, float duration)
        {
            Display = true;
            Text = text;
            Duration = duration;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (Display)
            {
                //NOTE divide by 4 since text is being scaled down with 0.5
                float xOffset = (Graphics.Viewport.Width / 2) - (font.MeasureString(Text).X / 2) * (float)0.5;
                float yOffset = (Graphics.Viewport.Height / 2) - (font.MeasureString(Text).Y / 2) * (float)0.5;
                //Outline, simply scaling differently won't provide a good solution
                spriteBatch.DrawString(font, Text, new Vector2(xOffset-2, yOffset), OwnColors.Black, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                spriteBatch.DrawString(font, Text, new Vector2(xOffset+2, yOffset), OwnColors.Black, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                spriteBatch.DrawString(font, Text, new Vector2(xOffset, yOffset-2), OwnColors.Black, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                spriteBatch.DrawString(font, Text, new Vector2(xOffset, yOffset+2), OwnColors.Black, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);

                spriteBatch.DrawString(font, Text, new Vector2(xOffset, yOffset), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            }
        }
    }
}
