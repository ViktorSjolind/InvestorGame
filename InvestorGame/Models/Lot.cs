using InvestorGame.Models;
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
        public Texture2D Texture;
        public int Value { get; private set; }
        public int Investment;
        public Player Owner;
        public LotState State;
        private Random random;


        public void Initialize(GraphicsDevice graphicsDevice)
        {
            Position = new Vector2(300, 300);
            Texture = new Texture2D(graphicsDevice, 1, 1);
            Texture.SetData(new Color[] { Color.DarkSlateGray });
            Owner = Player.AI;
            State = LotState.Empty;
            random = new Random();
            Value = random.Next(500, 2000);
        }

        public void Update()
        {

        }

        public void UpdateValue()
        {
            Value = random.Next(0, 1) < 1 ? LowerValue() : HigherValue(); 
        }

        private int HigherValue()
        {
            return (int)(0.1d * Value);
        }

        private int LowerValue()
        {
            return (int)(0.1d * Value);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, 100, 100), Color.White);
        }    
          
    }
}
