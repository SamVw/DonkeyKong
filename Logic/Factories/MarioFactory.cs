using Common.Entities;
using Microsoft.Xna.Framework;

namespace Logic.Factories
{
    public static class MarioFactory
    {
        public static Mario Create(int height, string spritePath, Point spriteDimensions)
        {
            Mario mario = new Mario();
            mario.SetDimensions();
            mario.SetSprite(spritePath, spriteDimensions.X, spriteDimensions.Y);

            return mario;
        }
    }
}
