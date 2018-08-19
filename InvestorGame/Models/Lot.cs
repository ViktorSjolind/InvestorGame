using InvestorGame.Models;
using InvestorGame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorGame.Models
{
    /// <summary>
    /// Land area that can developed to house or office 
    /// </summary>
    internal class Lot
    {
        public Vector2 Position;
        public Rectangle Area;
        public Texture2D Texture;

        public LotState State;
        public Player Owner;
        
        public int Value;
        public int Investment;

        public bool Selected;

        public void Initialize(GraphicsDevice graphicsDevice, Vector2 position)
        {
            Position = position;
            Area = new Rectangle(Position.ToPoint().X, Position.ToPoint().Y, 100, 100);
            Texture = new Texture2D(graphicsDevice, 1, 1);
            Texture.SetData(new Color[] { OwnColors.Green });
            State = LotState.Empty;
            Owner = Player.AI;
            Value = RandomGenerator.GetInteger(500, 2000);
            Investment = 0;
            Selected = false;
                
        }

        public void Update()
        {

        }

        public void UpdateValue()
        {
            Value = RandomGenerator.GetInteger(0, 1) < 1 ? LowerValue() : HigherValue(); 
        }

        private int HigherValue()
        {
            return (int)(0.1d * Value);
        }

        private int LowerValue()
        {
            return (int)(0.1d * Value);
        }

        public Rectangle CollisionCheck()
        {
            return Area;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (Selected)
            {
                spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, 100, 100), OwnColors.DarkGreen);
            }
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X+5, (int)Position.Y+5, 90, 90), Color.White);            
            spriteBatch.DrawString(font, Value.ToString(), new Vector2(Position.X + 10, Position.Y + 10), OwnColors.Black, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);

        }    
          
    }
}
