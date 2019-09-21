using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Common.Dtos
{
    public class DrawObject
    {
        public string Sprite { get; set; }

        public Vector2 Position { get; set; }

        public float? Scale { get; set; }
    }
}
