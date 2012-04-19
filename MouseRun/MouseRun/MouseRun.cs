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

        Texture2D logoScreen, menuScreen, contribScreen, titleScreen, winScreen, loseScreen;
        Rectangle viewportRect, screenViewportRect;
        enum GameState { TitleScreen, Playing, PlayerWin, PlayerLose, LogoScreen, MenuScreen, ContribScreen }
        GameState gameState;

        SpriteFont scoreFont;
        Vector2 scoreDrawPoint = new Vector2(110, 0);
        int score = 7;

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

            logoScreen = Content.Load<Texture2D>("Screens/LogoScreen2D");
            menuScreen = Content.Load<Texture2D>("Screens/MenuScreen2D");
            contribScreen = Content.Load<Texture2D>("Screens/Zoidberg");
            titleScreen = Content.Load<Texture2D>("Screens/titlescreen");
            winScreen = Content.Load<Texture2D>("Screens/playerwins");
            loseScreen = Content.Load<Texture2D>("Screens/playerloses");

            scoreFont = Content.Load<SpriteFont>("Fonts/GameFont");
            // TODO: use this.Content to load your game content here

            viewportRect = new Rectangle(0, 0,
                GameConstants.WinResX,
                GameConstants.WinResY);

            screenViewportRect = new Rectangle(0, 150, 440, 299);

            gameState = GameState.LogoScreen;
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
                case GameState.LogoScreen:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        gameState = GameState.TitleScreen;
                    }
                    break;
                case GameState.TitleScreen:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        gameState = GameState.MenuScreen;
                    }
                    break;
                case GameState.MenuScreen:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
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
                        gameState = GameState.ContribScreen;
                    }
                    break;
                case GameState.PlayerLose:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        gameState = GameState.ContribScreen;
                    }
                    break;
                case GameState.ContribScreen:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
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
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (gameState)
            {
                case GameState.LogoScreen:
                    spriteBatch.Draw(logoScreen, screenViewportRect, Color.White);
                    break;
                case GameState.TitleScreen:
                    spriteBatch.Draw(titleScreen, screenViewportRect, Color.White);
                    break;
                case GameState.MenuScreen:
                    spriteBatch.Draw(menuScreen, screenViewportRect, Color.White);
                    break;
                case GameState.Playing:
                    DrawGrid();
                    spriteBatch.DrawString(scoreFont, score.ToString() + " pieces of cheese left",
                        new Vector2(scoreDrawPoint.X,scoreDrawPoint.Y), Color.Yellow);
                    break;
                case GameState.PlayerWin:
                    spriteBatch.Draw(winScreen, screenViewportRect, Color.White);
                    break;
                case GameState.PlayerLose:
                    spriteBatch.Draw(loseScreen, screenViewportRect, Color.White);
                    break;
                case GameState.ContribScreen:
                    spriteBatch.Draw(contribScreen, screenViewportRect, Color.White);
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
