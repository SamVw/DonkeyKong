using System;
using Common.Dtos;
using Common.Entities;
using Common.Interfaces;
using Logic.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Logic
{
    public class DonkeyKongGame : IDonkeyKongGame
    {
        private readonly IContentManager _contentManager;
        private readonly IGameScreenManager _gameScreenManager;
        public Mario Mario { get; private set; }

        public Level Level { get; private set; }


        public DonkeyKongGame(IContentManager contentManager, IGameScreenManager gameScreenManager)
        {
            _contentManager = contentManager;
            _gameScreenManager = gameScreenManager;
        }

        public void SetMario(Mario mario)
        {
            Mario = mario;
        }

        public void SetLevel(System.Collections.Generic.List<Beam> list, System.Collections.Generic.List<Ladder> list1)
        {
            Level = new Level();
            Level.Beams = BeamFactory.InitializeBeams(_gameScreenManager.Width, _gameScreenManager.Height);
            Level.Ladders = LadderFactory.InitializeLadders(_gameScreenManager.Width, _gameScreenManager.Height);
        }

        public void Update(KeyboardState state)
        {
            BoundingBox marioBb = new BoundingBox(new Vector3(Mario.X, Mario.Y, 0), new Vector3(Mario.X + Mario.Width, Mario.Y + Mario.Height, 0));

            if (state.IsKeyDown(Keys.Right))
            {
                if (Mario.X + Mario.Width <= _gameScreenManager.Width)
                {
                    Mario.MoveRight(10);
                }
            }

            if (state.IsKeyDown(Keys.Left))
                Mario.MoveLeft(10);

            bool isOnObject = false;

            foreach (var beam in Level.Beams)
            {
                BoundingBox beamBb = new BoundingBox(new Vector3(beam.Position.X, beam.Position.Y, 0), new Vector3(beam.Position.X + beam.Width, beam.Position.Y + beam.Height, 0));
                if (marioBb.Intersects(beamBb) && Mario.Y + Mario.Height <= beam.Position.Y)
                {
                    isOnObject = true;
                }
            }


            foreach (var ladder in Level.Ladders)
            {
                BoundingBox ladderBd = new BoundingBox(new Vector3(ladder.Position.X, ladder.Position.Y - 50, 0), new Vector3(ladder.Position.X + ladder.Width, ladder.Position.Y + ladder.Height, 0));

                if (marioBb.Intersects(ladderBd))
                {
                    if (state.IsKeyDown(Keys.Up))
                    {
                        Mario.MoveUp(10);
                    }
                    isOnObject = true;
                }
            }

            if (!isOnObject)
            {
                Mario.MoveDown(10);
            }
        }

        public void Init()
        {
            SetMario(MarioFactory.Create(50, "mario", new Point(220, 337)));
            SetLevel(BeamFactory.InitializeBeams(_gameScreenManager.Width, _gameScreenManager.Height), LadderFactory.InitializeLadders(_gameScreenManager.Width, _gameScreenManager.Height));
        }

        public DrawData GetDrawData()
        {
            return new DrawData();
        }

        public void LoadContent()
        {
            _contentManager.LoadTexture("mario");
        }
    }
}
