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

        GameScreen baseScreen = new GameScreen(1000, 800);

        private Texture2D rect;

        private Mario _mario;

        private List<Beam> beams;
        private List<Ladder> ladders;

        private RectangleBuilder _rectangleBuilder;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = baseScreen.Height;
            graphics.PreferredBackBufferWidth = baseScreen.Width;

            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 24);

            _rectangleBuilder = new RectangleBuilder(graphics);

            InitMario();
        }

        private void InitMario()
        {
            _mario = new Mario();
            _mario.SetDimensions();
            _mario.SetSprite("mario", 220, 337);
            _mario.SetDefaultPostion(baseScreen.Height, 50);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            beams = BeamFactory.InitializeBeams(baseScreen);
            ladders = LadderFactory.InitializeLadders(baseScreen);

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
            BoundingBox marioBb = new BoundingBox(new Vector3(_mario.Position.X, _mario.Position.Y, 0), new Vector3(_mario.Position.X + _mario.Width, _mario.Position.Y + _mario.Height, 0));

            if (state.IsKeyDown(Keys.Right))
            {
                if (_mario.Position.X + _mario.Width <= baseScreen.Width)
                {
                   _mario.MoveRight(10); 
                }
            }

            if (state.IsKeyDown(Keys.Left))
                _mario.MoveLeft(10);

            bool isOnObject = false;

            foreach (var beam in beams)
            {
                BoundingBox beamBb = new BoundingBox(new Vector3(beam.Position.X, beam.Position.Y, 0), new Vector3(beam.Position.X + beam.Width, beam.Position.Y + beam.Height, 0));
                if (marioBb.Intersects(beamBb) && _mario.Position.Y + _mario.Height <= beam.Position.Y)
                {
                    isOnObject = true;
                }
            }

            
            foreach (var ladder in ladders)
            {
                BoundingBox ladderBd = new BoundingBox(new Vector3(ladder.Position.X, ladder.Position.Y - 50, 0), new Vector3(ladder.Position.X + ladder.Width, ladder.Position.Y + ladder.Height, 0));

                if (marioBb.Intersects(ladderBd))
                {
                    if (state.IsKeyDown(Keys.Up))
                    {
                        //if (ladder.Position.Y >= _mario.Position.Y + _mario.Height)
                        //{
                        //    _mario.Position.Y = ladder.Position.Y - 50 - _mario.Height;
                        //}
                        //else
                        //{
                        //    _mario.MoveUp(10);
                        //}
                        _mario.MoveUp(10);
                    }
                    isOnObject = true;
                }
            }

            if (!isOnObject)
            {
                _mario.MoveDown(10);
            }


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
            DrawBeams();
            DrawLadders();
            // Drawing Mario
            spriteBatch.Draw(_mario.Texture, _mario.Position.ToVector2(), scale: new Vector2(_mario.SpriteScale));

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawBeams()
        {
            foreach (var beam in beams)
            {
                spriteBatch.Draw(_rectangleBuilder.BuildTexture(beam), beam.Position.ToVector2());
            }
        }

        private void DrawLadders()
        {
            foreach (var ladder in ladders)
            {
                spriteBatch.Draw(_rectangleBuilder.BuildTexture(ladder), ladder.Position.ToVector2());
            }
        }
    }
}
