using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DonkeyKong.Models
{
    public abstract class Character
    {
        public Point Position;
        public int Width;
        public int Heigth;

        protected Character()
        {
        }

        protected Character(int width, int heigth, Point position)
        {
            Width = width;
            Heigth = heigth;
            Position = position;
        }
    }
}
