using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DonkeyKong.Models
{
    public abstract class Character
    {
        public Point Position;

        public int Width { get; set; }

        public int Height { get; set; }

        public float SpriteScale => (Height + 0.0f) / Graphics.Height;

        public Texture2D Texture => Graphics.Texture;

        public Sprite Graphics { get; set; }

        protected Character()
        {
            Graphics = new Sprite();
        }

        public void SetSprite(string path, int width, int height)
        {
            Graphics.Path = path;
            Graphics.Width = width;
            Graphics.Height = height;
            Width = (int)(Graphics.Width * SpriteScale);
        }

        public void MoveRight(int v)
        {
            Position.X += v;
        }

        public void MoveLeft(int v)
        {
            Position.X -= v;
        }

        public void MoveUp(int v)
        {
            Position.Y -= v;
        }

        public void MoveDown(int v)
        {
            Position.Y += v;
        }
    }
}
