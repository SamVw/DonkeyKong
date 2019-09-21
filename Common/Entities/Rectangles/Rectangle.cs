using Common.Entities.Base;
using Microsoft.Xna.Framework;

namespace Common.Entities
{
    public abstract class Rectangle : GameEntity
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }
        public Point Position { get; set; }

        protected Rectangle(int width, int height, Color color, Point position)
        {
            Width = width;
            Height = height;
            Color = color;
            Position = position;
        }
    }
}