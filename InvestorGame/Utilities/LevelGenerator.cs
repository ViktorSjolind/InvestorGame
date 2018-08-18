using InvestorGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorGame.Utilities
{
    internal class LevelGenerator
    {
        public Texture2D GridTexture;
        public int Width;
        public int Height;

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            GridTexture = new Texture2D(graphicsDevice, 1, 1);
            GridTexture.SetData(new Color[] { OwnColors.Red });
            Width = graphicsDevice.Viewport.Width;
            Height = graphicsDevice.Viewport.Height;

        }      

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawGrid(spriteBatch);            
        }

        private void DrawGrid(SpriteBatch spriteBatch)
        {
            int gridSize = 100;
            Rectangle rectangle;
            int columns = 12;
            int rows = 6;

            for (float x = -columns; x < columns; x++)
            {
                rectangle = new Rectangle((int)(Width/2 + x * gridSize), 0, 1, Height);
                spriteBatch.Draw(GridTexture, rectangle, Color.Red);
            }

            for (float y = -rows; y < rows; y++)
            {
                rectangle = new Rectangle(0, (int)(Height/2 + y * gridSize), Width, 1);
                spriteBatch.Draw(GridTexture, rectangle, Color.Red);
            }
        }
    }
}
