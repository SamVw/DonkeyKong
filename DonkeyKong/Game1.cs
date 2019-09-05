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
        private Texture2D myTexture;
        private Texture2D rect;
        private int x = 1;
        private int xPositionMario = 0;

        private Mario _mario;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1000;

            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 24);

            _mario = (Mario)CharacterFactory.Create("Mario");
            _mario.Width = int.Parse(Math.Round(220 * (_mario.Scale / 10.0), MidpointRounding.ToEven) + "");
            _mario.Heigth = int.Parse(Math.Round(337 * (_mario.Scale / 10.0), MidpointRounding.ToEven) + "");
            _mario.Position = new Point(0,
                int.Parse(700 - _mario.Heigth - 60 + string.Empty));
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
            myTexture = Content.Load<Texture2D>("mario");
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
                _mario.Position.X += 10;
            if (state.IsKeyDown(Keys.Left))
                _mario.Position.X -= 10;


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
            x++;
            spriteBatch.Begin();
            spriteBatch.Draw(rect, new Vector2(0, GraphicsDevice.Viewport.Height - rect.Height), Color.HotPink);
            spriteBatch.Draw(rect, new Vector2(0, GraphicsDevice.Viewport.Height - rect.Height * x), Color.HotPink);

            double mario = (myTexture.Height * (2.0 / 10.0));
            int yPosition = int.Parse(Math.Round(GraphicsDevice.Viewport.Height - mario, MidpointRounding.ToEven) - rect.Height + string.Empty);
            spriteBatch.Draw(myTexture, _mario.Position.ToVector2(), scale: new Vector2(.2f));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
