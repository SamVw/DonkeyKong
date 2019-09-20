using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonkeyKong.Models;
using Microsoft.Xna.Framework;

namespace DonkeyKong.Factories
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
