using System;
using System.Collections.Generic;
using DonkeyKong.Builders;
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

        private RectangleBuilder _rectangleBuilder;
        private DonkeyKongGame _game;

        public Game1()
        {
            _game = new DonkeyKongGame();
            _game.SetGameScreen(800, 1000);

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = _game.ScreenHeight;
            graphics.PreferredBackBufferWidth = _game.ScreenWidth;

            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 24);

            _rectangleBuilder = new RectangleBuilder(graphics);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _game.SetMario(MarioFactory.Create(50, "mario", new Point(220, 337)));
            _game.SetLevel();

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
            var texture = Content.Load<Texture2D>(_game.MarioSpritePath);
            _game.SetMarioTexture(texture);
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
            DrawBeams(data.Beams);
            DrawLadders(data.Ladders);
            DrawMario(data.Mario);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawMario(Mario mario)
        {
            spriteBatch.Draw(mario.Texture, mario.Position.ToVector2(), scale: new Vector2(mario.SpriteScale));
        }

        private void DrawBeams(List<Beam> beams)
        {
            foreach (var beam in beams)
            {
                spriteBatch.Draw(_rectangleBuilder.BuildTexture(beam), beam.Position.ToVector2());
            }
        }

        private void DrawLadders(List<Ladder> ladders)
        {
            foreach (var ladder in ladders)
            {
                spriteBatch.Draw(_rectangleBuilder.BuildTexture(ladder), ladder.Position.ToVector2());
            }
        }
    }
}
