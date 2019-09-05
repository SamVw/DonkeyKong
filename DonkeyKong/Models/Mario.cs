using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DonkeyKong.Models
{
    public class Mario : Character
    {
        public int Scale = 1;

        public Mario() : base()
        {
        }

        public Mario(int width, int heigth, Point position) : base(width, heigth, position)
        {
        }
    }
}
