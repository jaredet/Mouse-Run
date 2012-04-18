using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MouseRun
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MouseRun : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D gridFree, gridBlock;

        Texture2D titleScreen, winScreen, loseScreen;
        Rectangle viewportRect, titleViewportRect, winViewportRect, loseViewportRect;
        enum GameState { TitleScreen, Playing, PlayerWin, PlayerLose }
        GameState gameState;

        public MouseRun()
        {
            graphics = new GraphicsDeviceManager(this);
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
            this.graphics.PreferredBackBufferWidth  = GameConstants.WinResX;
            this.graphics.PreferredBackBufferHeight = GameConstants.WinResY;
            this.graphics.ApplyChanges();
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

            gridBlock = Content.Load<Texture2D>("Sprites/gridBlock");
            gridFree  = Content.Load<Texture2D>("Sprites/gridFree");
            // TODO: use this.Content to load your game content here

            viewportRect = new Rectangle(0, 0,
                GameConstants.WinResX,
                GameConstants.WinResY);

            gameState = GameState.TitleScreen;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            switch (gameState)
            {
                case GameState.TitleScreen:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        gameState = GameState.Playing;
                    }
                    break;
                case GameState.Playing:
                    {
                        //Gametime logic
                    }
                    break;
                case GameState.PlayerWin:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        gameState = GameState.TitleScreen;
                    }
                    break;
                case GameState.PlayerLose:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        gameState = GameState.TitleScreen;
                    }
                    break;
            }

            switch (gameState) 
            { 
                case GameState.TitleScreen: 
                    if (Keyboard.GetState().IsKeyDown(Keys.Space)) 
                    { 
                        gameState = GameState.Playing; 
                    } 
                    break; 
                case GameState.Playing: 
                    //Gametime logic 
                    break; 
                case GameState.PlayerWin: 
                case GameState.PlayerLose: 
                    if (Keyboard.GetState().IsKeyDown(Keys.Space)) 
                    { 
                        gameState = GameState.TitleScreen; 
                    } 
                    break; 
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            if (gameState == GameState.TitleScreen)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(titleScreen, titleViewportRect, Color.Black);
                spriteBatch.End();
            }
            if (gameState == GameState.Playing)
            {
                spriteBatch.Begin();
                //Gametime drawing
                spriteBatch.End();
            }
            if (gameState == GameState.PlayerWin)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(winScreen, winViewportRect, Color.Black);
                spriteBatch.End();
            }
            if (gameState == GameState.PlayerLose)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(loseScreen, loseViewportRect, Color.Black);
                spriteBatch.End();
            }

            spriteBatch.Begin();
            switch (gameState)
            {
                case GameState.TitleScreen:
                    //spriteBatch.Draw(titleScreen, titleViewportRect, Color.Black);
                    break;
                case GameState.Playing:
                    DrawGrid();
                    break;
                case GameState.PlayerWin:
                    spriteBatch.Draw(winScreen, winViewportRect, Color.Black);
                    break;
                case GameState.PlayerLose:
                    spriteBatch.Draw(loseScreen, loseViewportRect, Color.Black);
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawGrid()
        {
            for (int x = 0; x < 22; x++)
            {
                for (int y = 0; y < 30; y++)
                {
                    spriteBatch.Draw(
                        (GameGrid.Free(new Point(x, y)) ? gridFree : gridBlock),
                        new Vector2(x * 20, y * 20),
                        Color.White);
                }
            }
        }
    }
}
