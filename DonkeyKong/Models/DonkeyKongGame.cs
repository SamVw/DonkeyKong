using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonkeyKong.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DonkeyKong.Models
{
    public class DonkeyKongGame
    {
        public Mario Mario { get; private set; }

        public Level Level { get; private set; }



        public GameScreen GameScreen { get; private set; }

        public int ScreenHeight => GameScreen.Height;
        public int ScreenWidth => GameScreen.Width;



        public string MarioSpritePath => Mario.Graphics.Path;

        public float MarioX => Mario.Position.X;

        public float MarioY => Mario.Position.Y;

        public int MarioW => Mario.Width;

        public int MarioH => Mario.Height;



        public void SetGameScreen(int width, int height)
        {
            GameScreen = new GameScreen(height, width);
        }

        public void SetMario(Mario mario)
        {
            Mario = mario;
        }

        public void SetLevel()
        {
            Level = new Level();
            Level.Beams = BeamFactory.InitializeBeams(GameScreen);
            Level.Ladders = LadderFactory.InitializeLadders(GameScreen);
        }

        public void SetMarioTexture(Texture2D texture)
        {
            Mario.Graphics.Texture = texture;
        }

        public void Update(KeyboardState state)
        {
            BoundingBox marioBb = new BoundingBox(new Vector3(MarioX, MarioY, 0), new Vector3(MarioX + MarioW, MarioY + MarioH, 0));

            if (state.IsKeyDown(Keys.Right))
            {
                if (MarioX + MarioW <= ScreenWidth)
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
                if (marioBb.Intersects(beamBb) && MarioY + MarioH <= beam.Position.Y)
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

        public DrawData GetDrawData()
        {
            return new DrawData()
            {
                Mario = Mario,
                Beams = Level.Beams,
                Ladders = Level.Ladders
            };
        }
    }
}
