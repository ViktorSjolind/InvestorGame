﻿using InvestorGame.Models;
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
        public BuySellButton buySellButton;
        private Lot SelectedLot;
        public BuildButton BuildHouseButton;
        public BuildButton BuildShopButton;
        public BuildButton BuildOfficeButton;

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            Texture = new Texture2D(graphicsDevice, 1, 1);
            Texture.SetData(new Color[] { OwnColors.Black });
            Position = new Vector2(0, 620);
            buySellButton = new BuySellButton();
            buySellButton.Initialize(graphicsDevice);
            SelectedLot = null;

            BuildHouseButton = new BuildButton();
            BuildHouseButton.Initialize(graphicsDevice, BuildButtonState.House, new Vector2(650, 620));

            BuildShopButton = new BuildButton();
            BuildShopButton.Initialize(graphicsDevice, BuildButtonState.Shop, new Vector2(750, 620));

            BuildOfficeButton = new BuildButton();
            BuildOfficeButton.Initialize(graphicsDevice, BuildButtonState.Office, new Vector2(850, 620));
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
            if(SelectedLot == null)
            {
                buySellButton.State = BuySellButtonState.None;
            }

            if (SelectedLot != null)
            {
                if(SelectedLot.Owner == Player.Human)
                {

                    buySellButton.State = BuySellButtonState.Sell;
                }
            }

            if (SelectedLot != null)
            {
                if (SelectedLot.Owner == Player.AI)
                {
                    buySellButton.State = BuySellButtonState.Buy;
                }
            }
        }
        
        //UI begins at Y = 620
        public void Draw(SpriteBatch spriteBatch, SpriteFont bigFont, Texture2D spriteSheet, Economy economy)
        {
            //Buy sell button
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, 1280, 100), Color.White);
            buySellButton.Draw(spriteBatch, bigFont);            

            if (SelectedLot != null)
            {               
                //Lot metadata
                spriteBatch.DrawString(bigFont, "Value: " + SelectedLot.Value.ToString("N0"), new Vector2(Position.X + 160, Position.Y + 25), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                spriteBatch.DrawString(bigFont, "Investment: " + SelectedLot.Investment.ToString("N0"), new Vector2(Position.X + 160, Position.Y + 50), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);

                spriteBatch.DrawString(bigFont, "Income: " + SelectedLot.Income.ToString("N0"), new Vector2(Position.X + 350, Position.Y + 25), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                spriteBatch.DrawString(bigFont, "Total income: " + SelectedLot.TotalIncome.ToString("N0"), new Vector2(Position.X + 350, Position.Y + 50), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);

                //Build

                if (SelectedLot.Owner == Player.Human)
                {
                    spriteBatch.DrawString(bigFont, "Build: ", new Vector2(Position.X + 600, Position.Y + 35), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                    BuildHouseButton.Draw(spriteBatch, bigFont, spriteSheet);
                    spriteBatch.DrawString(bigFont, "$" + economy.BuildHousePrice.ToString("N0"), new Vector2(Position.X + 660, Position.Y + 74), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);

                    BuildShopButton.Draw(spriteBatch, bigFont, spriteSheet);
                    spriteBatch.DrawString(bigFont, "$" + economy.BuildShopPrice.ToString("N0"), new Vector2(Position.X + 760, Position.Y + 74), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);

                    BuildOfficeButton.Draw(spriteBatch, bigFont, spriteSheet);
                    spriteBatch.DrawString(bigFont, "$" + economy.BuildOfficePrice.ToString("N0"), new Vector2(Position.X + 860, Position.Y + 74), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
                }
                
            }            

            //Player money
            spriteBatch.DrawString(bigFont, "Money: " + Game.Money.ToString("N0"), new Vector2(Position.X + 1000, Position.Y + 25), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(bigFont, "Date: " + Game.Month + "/" + Game.Year, new Vector2(Position.X + 1000, Position.Y + 50), OwnColors.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
        }
    }
}
