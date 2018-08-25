using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorGame.Models
{
    internal class Street : IMapComponents
    {
        public Vector2 Position;
        public Texture2D Texture;
        public Rectangle Area;

        public void Initialize(GraphicsDevice graphicsDevice, Vector2 position)
        {
            Position = position;
            Texture = new Texture2D(graphicsDevice, 1, 1);
            Texture.SetData(new Color[] { OwnColors.White });
            Area = new Rectangle(Position.ToPoint().X, Position.ToPoint().Y, 50, 50);
        }

        public void Update()
        {

        }


        public void Draw(SpriteBatch spriteBatch, SpriteFont font, Texture2D spriteSheet)
        {
            spriteBatch.Draw(spriteSheet, new Rectangle((int)Position.X + 0, (int)Position.Y + 0, 50, 50), new Rectangle(0, 700, 50, 50), Color.White);

        }

        public Rectangle CollisionCheck()
        {
            return Area;
        }

        public void UpdateValue()
        {
           
        }
    }
}
