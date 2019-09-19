using System;
using DonkeyKong.Factories;
using DonkeyKong.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DonkeyKong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D rect;

        private const int HEIGHT = 700;
        private const int WIDTH = 1000;

        private Mario _mario;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.PreferredBackBufferWidth = WIDTH;

            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 24);

            InitMario();
        }

        private void InitMario()
        {
            _mario = new Mario();
            _mario.SetSprite("mario", 337, 220);
            _mario.SetDimensions();
            _mario.SetDefaultPostion(HEIGHT, 55);
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
            _mario.Graphics.Texture = Content.Load<Texture2D>(_mario.Graphics.Path);
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

            if (state.IsKeyDown(Keys.Right))
                _mario.MoveRight(10);
            if (state.IsKeyDown(Keys.Left))
                _mario.MoveLeft(10);


            rect = new Texture2D(graphics.GraphicsDevice, GraphicsDevice.Viewport.Width, 30);

            Color[] data = new Color[GraphicsDevice.Viewport.Width * 30];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);


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
            spriteBatch.Draw(rect, new Vector2(0, GraphicsDevice.Viewport.Height - rect.Height), Color.HotPink);

            // Drawing Mario
            spriteBatch.Draw(_mario.Texture, _mario.Position.ToVector2(), scale: new Vector2(_mario.SpriteScale));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
