using InvestorGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Random random;
        public List<IMapComponents> Map1;

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            Graphics = graphicsDevice;
            GridTexture = new Texture2D(graphicsDevice, 1, 1);
            GridTexture.SetData(new Color[] { OwnColors.Red });
            Width = graphicsDevice.Viewport.Width;
            Height = graphicsDevice.Viewport.Height;
            random = new Random();
            Map1 = new List<IMapComponents>();
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
                    // && random.Next(0,2)>0
                    if (x % 3 == 0 && y % 3 == 0 && x > -columns+1 && x < columns/2 && y >= -rows/2 && y < rows/2 && random.Next(0, 2) > 0)
                    {
                        Lot lot = new Lot();
                        lot.Initialize(Graphics, new Vector2((int)(Width / 2 + x * gridSize), (int)(Height / 2 + y * gridSize)));
                        lots.Add(lot);

                    }
                }                
            }
            return lots;
        }

        public List<IMapComponents> CreateMap1()
        {
            int gridSize = 50;
            int columns = 24;
            int rows = 12;
            int runs = 0;
            Map1 = new List<IMapComponents>();

            for (float x = -columns; x < columns; x++)
            {
                for (float y = -rows; y < rows; y++)
                {
                    // && random.Next(0,2)>0
                    if (x % 3 == 0 && y % 3 == 0 && x > -columns + 1 && x < columns / 2 && y >= -rows / 2 && y < rows / 2 && random.Next(0, 2) > 0)
                    {
                        Lot lot = new Lot();
                        lot.Initialize(Graphics, new Vector2((int)(Width / 2 + x * gridSize), (int)(Height / 2 + y * gridSize)));
                        Map1.Add(lot);

                    }
                }
            }

            Map1 = new List<IMapComponents>();

            for (int y = 10; y < Height; y+= gridSize)
            {
                Debug.WriteLine("new row");
                for(int x = 40; x < Width; x+= gridSize)
                {
                    if(y == 60)
                    {
                        if (x == 40 || x == 40 + (50*6) || x== 40 + (50 * 9) || x == 40 + (50 * 11) || x == 40 + (50 * 13) || x == 40 + (50 * 16) || x == 40 + (50 * 20))
                        {
                            Lot lot = new Lot();
                            lot.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(lot);
                        }
                    }

                    

                    if(y == 210)
                    {
                        if(x == 40 + (gridSize * 1) || x == 40 + (gridSize * 4) || x == 40 + (gridSize * 9) || x == 40 + (gridSize *  11) || x == 40 + (gridSize * 13) || x == 40 + (gridSize * 15) || x == 40 + (gridSize * 18))
                        {
                            Lot lot = new Lot();
                            lot.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(lot);
                        }
                    }

                    if (y == 10 + (gridSize * 5))
                    {
                        if (x == 40 + (gridSize * 6))
                        {
                            Lot lot = new Lot();
                            lot.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(lot);
                        }
                    }

                    if (y == 10 + (gridSize * 6))
                    {
                        if (x == 40 + (gridSize * 1) || x == 40 + (gridSize * 4))
                        {
                            Lot lot = new Lot();
                            lot.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(lot);
                        }
                    }

                    if (y == 10 + (gridSize * 7))
                    {
                        if (x == 40 + (gridSize * 9) || x == 40 + (gridSize * 12) || x == 40 + (gridSize * 12) || x == 40 + (gridSize * 14) || x == 40 + (gridSize * 18))
                        {
                            Lot lot = new Lot();
                            lot.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(lot);
                        }
                    }

                    if (y == 10 + (gridSize * 8))
                    {
                        if (x == 40 + (gridSize * 6))
                        {
                            Lot lot = new Lot();
                            lot.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(lot);
                        }
                    }

                    if (y == 10 + (gridSize * 10))
                    {
                        if (x == 40 + (gridSize * 8) || x == 40 + (gridSize * 13) || x == 40 + (gridSize * 16))
                        {
                            Lot lot = new Lot();
                            lot.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(lot);
                        }
                    }


                    //Roads

                    if (y == 160 && x < 40 + (50 * 24))
                    {
                        Street street = new Street();
                        street.Initialize(Graphics, new Vector2(x, y));
                        Map1.Add(street);
                    }

                    if (y >= 10 + (gridSize * 4) && y <= 10 + (gridSize * 7))
                    {
                        if (x == 40 + (gridSize * 3))
                        {
                            Street street = new Street();
                            street.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(street);
                        }
                    }

                    if (y >= 10 + (gridSize * 4) && y <= 10 + (gridSize * 9))
                    {
                        if (x == 40 + (gridSize * 8))
                        {
                            Street street = new Street();
                            street.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(street);
                        }
                    }

                    if (y >= 10 + (gridSize * 4) && y <= 10 + (gridSize * 9))
                    {
                        if (x == 40 + (gridSize * 17))
                        {
                            Street street = new Street();
                            street.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(street);
                        }
                    }

                    if (y == 10 + (gridSize * 9))
                    {
                        if (x >= 40 + (gridSize * 8) && x <= 40 + (gridSize * 17))
                        {
                            Street street = new Street();
                            street.Initialize(Graphics, new Vector2(x, y));
                            Map1.Add(street);
                        }
                            
                    }

                }
            }
            
            return Map1;
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
