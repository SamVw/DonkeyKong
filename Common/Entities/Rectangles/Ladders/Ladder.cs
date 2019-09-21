﻿using Common.Dtos;
using Microsoft.Xna.Framework;

namespace Common.Entities
{
    public class Ladder : Rectangle
    {
        public Ladder(int width, int height, Color color, Point position) : base(width, height, color, position)
        {
        }

        public override DrawObject GetDrawData()
        {
            throw new System.NotImplementedException();
        }
    }
}