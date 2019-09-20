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

        public Mario()
        {
            
        }

        public void SetDefaultPostion(int viewPortHeight, int offset)
        {
            Position = new Point(0, viewPortHeight - Height - offset);
        }

        public void SetDimensions()
        {
            Height = 50;
        }
    }
}
