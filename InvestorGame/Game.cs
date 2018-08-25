using InvestorGame.Models;
using InvestorGame.UI;
using InvestorGame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace InvestorGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Lot> Lots;
        LevelGenerator levelGenerator;
        Navbar navbar;
        SpriteFont FontUIBig;
        MouseState previousMouseState;
        private float TimerDelay = 1;
        private float TimerRemaining;
        public static int Money = 5000;
        Texture2D SpriteSheet;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            Lots = new List<Lot>();
            levelGenerator = new LevelGenerator();
            levelGenerator.Initialize(graphics.GraphicsDevice);
            Lots = levelGenerator.CreateLots();
            navbar = new Navbar();
            navbar.Initialize(graphics.GraphicsDevice);
            TimerRemaining = TimerDelay;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            FontUIBig = Content.Load<SpriteFont>("FontUI");
            SpriteSheet = Content.Load<Texture2D>("SpritesheetInvestorGame");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Check mouse
            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                Debug.WriteLine("Mouse click");
                //Map 
                if (currentMouseState.Position.Y < 620)
                {
                    foreach (Lot lot in Lots)
                    {
                        if (lot.CollisionCheck().Contains(currentMouseState.Position))
                        {
                            Debug.WriteLine(lot.Value);
                            lot.Selected = true;
                            navbar.UpdateSelected(lot);
                        }
                        else
                        {
                            lot.Selected = false;
                            if (navbar.GetSelected() == lot)
                            {

                                navbar.UpdateSelected(null);
                            }

                        }

                    }
                }
                //UI begins at Y = 620
                if (navbar.buySellButton.CollisionCheck().Contains(currentMouseState.Position) && navbar.GetSelected() != null)
                {
                    Debug.WriteLine("buy sell clicked");
                    if(navbar.buySellButton.State == BuySellButtonState.Buy)
                    {
                        Lot selectedLot = navbar.GetSelected();
                        if (selectedLot.Value <= Money)
                        {
                            Money -= selectedLot.Value;
                            selectedLot.Owner = Player.Human;
                            selectedLot.Investment = selectedLot.Value;
                        }                       
                        
                    }

                    if (navbar.buySellButton.State == BuySellButtonState.Sell)
                    {
                        Lot selectedLot = navbar.GetSelected();
                        Money += selectedLot.Value;
                        selectedLot.Investment = 0;
                        selectedLot.Owner = Player.AI;
                    }


                }


                if (navbar.BuildHouseButton.CollisionCheck().Contains(currentMouseState.Position) && navbar.GetSelected() != null)
                {
                    Debug.WriteLine("build house clicked");
                    Lot selectedLot = navbar.GetSelected();
                    int price = 1000;
                    if (Money >= price && selectedLot.State != LotState.House)
                    {
                        Money -= price;
                        selectedLot.Investment += price;
                        selectedLot.Value += price;
                    }
                    
                }

                if (navbar.BuildShopButton.CollisionCheck().Contains(currentMouseState.Position) && navbar.GetSelected() != null)
                {
                    Debug.WriteLine("build shop clicked");
                    Lot selectedLot = navbar.GetSelected();
                    int price = 2000;
                    if (Money >= price && selectedLot.State != LotState.Shop)
                    {
                        Money -= price;
                        selectedLot.Investment += price;
                        selectedLot.Value += price;
                    }

                }

                if (navbar.BuildOfficeButton.CollisionCheck().Contains(currentMouseState.Position) && navbar.GetSelected() != null)
                {
                    Debug.WriteLine("build office clicked");
                    Lot selectedLot = navbar.GetSelected();
                    int price = 3000;
                    if (Money >= price && selectedLot.State != LotState.Office)
                    {
                        Money -= price;
                        selectedLot.Investment += price;
                        selectedLot.Value += price;
                    }

                }

            }
            previousMouseState = currentMouseState;
            navbar.Update();

            //Update prices
            float timePassed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TimerRemaining -= timePassed;
            if(TimerRemaining <= 0)
            {
                Debug.WriteLine("Happening!!");
                foreach(Lot lot in Lots)
                {
                    lot.UpdateValue();
                }
                TimerRemaining = TimerDelay;
            }





            //Exit game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(OwnColors.LightGreen);

            spriteBatch.Begin();
            // TODO: Add your drawing code here
            foreach(Lot lot in Lots)
            {
                lot.Draw(spriteBatch, FontUIBig, SpriteSheet);
            }
            //levelGenerator.Draw(spriteBatch);
            navbar.Draw(spriteBatch, FontUIBig, SpriteSheet);


            spriteBatch.End();
            base.Draw(gameTime);

           
        }
    }
}
