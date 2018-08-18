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
        private GraphicsDevice Graphics;

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            Graphics = graphicsDevice;
            GridTexture = new Texture2D(graphicsDevice, 1, 1);
            GridTexture.SetData(new Color[] { OwnColors.Red });
            Width = graphicsDevice.Viewport.Width;
            Height = graphicsDevice.Viewport.Height;

        }      

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawGrid(spriteBatch);            
        }

        public List<Lot> CreateLots()
        {
            List<Lot> lots = new List<Lot>();

            int gridSize = 50;
            int columns = 24;
            int rows = 12;
            int runs = 0;

            for (float x = -columns; x < columns; x++)
            {
                for (float y = -rows; y < rows; y++)
                {
                    if (x % 3 == 0 && y % 3 == 0 && x > -columns+1 && x < columns/2 && y >= -rows/2 && y < rows/2)
                    {
                        Lot lot = new Lot();
                        lot.Initialize(Graphics, new Vector2((int)(Width / 2 + x * gridSize), (int)(Height / 2 + y * gridSize)));
                        lots.Add(lot);

                    }
                }                
            }
            return lots;
        }

        private void DrawGrid(SpriteBatch spriteBatch)
        {
            int gridSize = 50;
            Rectangle rectangle;
            int columns = 24;
            int rows = 12;

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
