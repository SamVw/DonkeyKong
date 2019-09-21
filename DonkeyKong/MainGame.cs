using System;
using System.Collections.Generic;
using Common.Dtos;
using Common.Entities;
using Common.Interfaces;
using Logic;
using Logic.Builders;
using Logic.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DonkeyKong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        private readonly IContentManager _contentManager;
        private readonly GameScreenManager _gameScreenManager;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private RectangleBuilder _rectangleBuilder;
        private DonkeyKongGame _game;


        public MainGame(DonkeyKongGame game, ContentManager contentManager, GameScreenManager gameScreenManager)
        {
            _contentManager = contentManager;
            _gameScreenManager = gameScreenManager;
            _game = game;
            

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            InitWindow();

            SetFramesPerSecond(24);

            _rectangleBuilder = new RectangleBuilder(graphics);
        }

        private void InitWindow()
        {
            _gameScreenManager.SetGameScreen(800, 1000);
            graphics.PreferredBackBufferHeight = _gameScreenManager.Height;
            graphics.PreferredBackBufferWidth = _gameScreenManager.Width;
        }

        private void SetFramesPerSecond(int fps)
        {
            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / fps);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _game.Init();

            _contentManager.SetInternalManager(Content);

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

            // TODO: use this.Content to load your game content here
            _game.LoadContent();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState state = Keyboard.GetState();
            
            _game.Update(state);


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(30, 30, 30));

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            DrawData data = _game.GetDrawData();
            DrawScene(data);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawScene(DrawData data)
        {
            if (data == null || data.Objects == null)
            {
                return;
            }

            foreach (var obj in data.Objects)
            {
                var texture = _contentManager.GetTexture(obj.Sprite);

                if (obj.Scale == null)
                {
                    spriteBatch.Draw(texture, obj.Position);
                }
                else
                {
                    spriteBatch.Draw(texture, obj.Position, scale: new Vector2((float)obj.Scale));
                }
            }
        }
    }
}
