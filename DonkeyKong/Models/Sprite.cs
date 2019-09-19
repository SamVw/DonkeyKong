using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace DonkeyKong.Models
{
    public class Sprite
    {
        public string Path { get; set; }

        public Texture2D Texture { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
