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
    internal class Button : IInterfaceComponent
    {
        private Texture2D TextureBlack;
        private Texture2D TextureWhite;
        private Vector2 Position;
        public Rectangle Area;

        public Button(GraphicsDevice graphicsDevice, Vector2 position)
        {
            TextureBlack = new Texture2D(graphicsDevice, 1, 1);
            TextureBlack.SetData(new Color[] { OwnColors.Black });

            TextureWhite = new Texture2D(graphicsDevice, 1, 1);
            TextureWhite.SetData(new Color[] { OwnColors.White });
            Position = position;
            Area = new Rectangle(Position.ToPoint().X, Position.ToPoint().Y, 60, 35);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
